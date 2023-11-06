package org.techtown.mp3player;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.core.content.FileProvider;

import android.graphics.Color;
import android.os.Build;
import android.os.SystemClock;
import android.provider.DocumentsContract;
import android.util.SparseBooleanArray;
import android.view.ActionMode;
import android.view.Menu;
import android.view.MenuItem;

import android.Manifest;
import android.app.AlertDialog;
import android.app.DownloadManager;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.MediaMetadataRetriever;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.util.SparseBooleanArray;
import android.view.ActionMode;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.webkit.DownloadListener;
import android.webkit.URLUtil;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.SeekBar;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.ByteOrder;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;


public class MainActivity extends AppCompatActivity {

    static final int REQUEST_AUDIO_GET = 1;
    private MediaPlayer mp;
    private int isPlaying = 2;

    private ImageButton btnBack;
    private ImageButton btnPlay;
    private ImageButton btnFor;
    private ImageButton btnFor10;
    private ImageButton btnBack10;
    private ImageView imageView;
    private TextView curAlbum;
    private TextView curArtist;
    private TextView txtEnd;
    private TextView txtCur;
    private ImageButton curImg;
    private TextView curText;
    private SeekBar curSeekBar;
    private int curSongIndex = -1;

    private List<String> curSongsList;
    private CurListAdapter curAdapter;
    private List<String> curSongsKey;
    private HashMap<String, String> curSongsMap;
    SimpleDateFormat timeFormat;
    private TabHost tabHost;

    private WebView webView;
    private String downFileName;

    private List<String> savedList;
    private SaveListAdapter saveAdapter;

    private final long FINISH_INTERVAL_TIME = 2000;
    private long backPressedTime = 0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

//        SharedPreferences pref = getSharedPreferences("SavedList", MODE_PRIVATE);
//        SharedPreferences.Editor editor = pref.edit();
//        editor.clear();
//        editor.commit();

        timeFormat = new SimpleDateFormat("mm:ss");
        ActivityCompat.requestPermissions(MainActivity.this, new String[]{android.Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1004);
        ActivityCompat.requestPermissions(MainActivity.this, new String[]{android.Manifest.permission.READ_EXTERNAL_STORAGE}, 1004);
        initTab();

        try {
            FileInputStream inFs = openFileInput("CurList.txt");
            byte[] txt = new byte[300];
            inFs.read(txt);
            String musics = new String(txt);
            musics.trim();
            String[] music = musics.split("##");
            for (int i = 0; i < music.length - 1; i++) { // 맨 뒤에 쓰레기값이 들어가므로 -1
                curSongsMap.put(music[i], "true");
                curSongsList.add(new File(music[i]).getName());
                curSongsKey.add(music[i]);
            }
            inFs.close();
            Toast.makeText(getApplicationContext(), "저장된 재생목록을 불러옵니다.", Toast.LENGTH_SHORT).show();
        } catch (FileNotFoundException e) {
            Toast.makeText(getApplicationContext(), "저장된 재생목록이 없습니다.", Toast.LENGTH_SHORT).show();
        } catch (IOException e) {
            e.printStackTrace();
        }

        SharedPreferences prefMap = getSharedPreferences("SavedList", MODE_PRIVATE);
        if (prefMap != null) {
            Map<String, ?> keys = prefMap.getAll();
            for (Map.Entry<String, ?> entry : keys.entrySet()) {
                savedList.add(entry.getKey().replace(".txt", ""));
            }
        }
    }


    public static String getPathFromUri(Context context, final Uri uri) {

        final String docId = DocumentsContract.getDocumentId(uri);
        final String[] split = docId.split(":");

        final String type = split[0];
        final String data = split[1];
        File[] file = context.getExternalMediaDirs();

        if (type.contains("pri")) {
            String s = file[0].getParentFile().getParentFile().getParent();//  /storage/emulated/0/
            return s + "/" + data;
        } else {
            return uri.toString();
        }

    }


    private BroadcastReceiver completeReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            try {
                File file = new File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS) + "/" + downFileName);
                Toast.makeText(context, "다운로드가 완료되어 재생합니다.", Toast.LENGTH_SHORT).show();
                if (file.exists())
                    playMusic(Uri.parse(file.getAbsolutePath()), -1, true);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

    };

    @Override
    public void onResume() {
        super.onResume();
        IntentFilter completeFilter = new IntentFilter(DownloadManager.ACTION_DOWNLOAD_COMPLETE);
        registerReceiver(completeReceiver, completeFilter);
    }


    @Override
    protected void onPause() {
        super.onPause();
        if (completeReceiver.isOrderedBroadcast()) {
            unregisterReceiver(completeReceiver); // 파일 다운로드 감지를 위한 Broadcast
        }

        if (!curSongsMap.isEmpty()) {
            String s = null;
            for (int i = 0; i < curSongsMap.size(); i++) {
                if (curSongsMap.get(curSongsKey.get(i)) == "true") {
                    try {
                        ActivityCompat.requestPermissions(MainActivity.this, new String[]{android.Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1004);
                        FileOutputStream outFs = openFileOutput("CurList.txt", MODE_PRIVATE);
                        if (s == null) {
                            s = curSongsKey.get(i);
                        } else if (s.contains(curSongsKey.get(i)))
                            continue;
                        else
                            s += curSongsKey.get(i);
                        s += "##";
                        outFs.write(s.getBytes());
                        outFs.close();
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
            }
        }
    }

    @Override
    protected void onDestroy() {
        endMusic();
        mp.release();
        mp = null;
        super.onDestroy();
    }

    @Override
    public void onBackPressed() {
        long tempTime = System.currentTimeMillis();
        long intervalTime = tempTime - backPressedTime;

        if (0 <= intervalTime && FINISH_INTERVAL_TIME >= intervalTime) {

            super.onBackPressed();
        } else {
            if (tabHost.getCurrentTabTag() != "WEB")
                tabHost.setCurrentTabByTag("WEB");
            else if (webView.canGoBack()) {
                webView.goBack();
            } else {
                backPressedTime = tempTime;
                Toast.makeText(getApplicationContext(), "한번 더 누르면 종료됩니다.", Toast.LENGTH_SHORT).show();
            }
        }

    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {

        if (requestCode == REQUEST_AUDIO_GET && resultCode == RESULT_OK) {
            Uri audioUri = data.getData();
            try {
                playMusic(audioUri, null, true);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

    public void selectAudio() {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
        intent.setType("audio/*");
        if (intent.resolveActivity(getPackageManager()) != null)
            startActivityForResult(intent, REQUEST_AUDIO_GET);
    }

    private void endMusic(){
        if(isPlaying != 2){
            try {
                curSongIndex = -1;
                mp.stop();
                curAlbum.setText("노래 제목");
                curArtist.setText("가수명");
                imageView.setImageResource(R.drawable.ic_cur_img);
                curText.setText("현재 재생중인 곡이 없습니다.");
                isPlaying = 2;
            }catch (Exception e){
                e.printStackTrace();
            }
        }
    }
    private void playMusic(Uri audioUri, Integer index, boolean type) throws IOException {//type = 리스트에서 가져온 경우 or 핸드폰에 있는 파일을 가져온 경우
        File file = null;
        ActivityCompat.requestPermissions(MainActivity.this, new String[]{Manifest.permission.READ_EXTERNAL_STORAGE}, 1004);
        if (!type) { //리스트에서 파일을 선택한 경우
            file = new File(curSongsKey.get(index));
            curSongIndex = index;
        } else if (type) { // 핸드폰에 있는 파일을 리스트에 추가한 경우
            if (index == null)
                file = new File(getPathFromUri(getApplicationContext(), audioUri));
            else {
                file = new File(audioUri.getPath());
            }
            if(curSongIndex < 0)
                curSongIndex = 0;
            else
                curSongIndex ++;
        }

        if (isPlaying != 2) {
            mp.stop(); // 재생중인 경우
            mp.reset();
        } else {
            mp = new MediaPlayer();
            mp.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
                @Override
                public void onCompletion(MediaPlayer mp) {
                    if(curSongsKey.size() > 1){
                        if(curSongIndex != (curSongsKey.size()-1)){
                            curSongIndex += 1;
                            try {
                                playMusic(null, curSongIndex, false);
                            } catch (IOException e) {
                                throw new RuntimeException(e);
                            }
                        }else{
                            endMusic();
                            return;
                        }
                    }
                }
            });
        }
        MediaMetadataRetriever mmr = new MediaMetadataRetriever();
        if (file.exists()) {// content uri(audioUri)를 이용해 파일을 만들 경우, 경로를 못 불러올 수 있다.
            try {
                mmr.setDataSource(file.getAbsolutePath());
                mp.setDataSource(file.getAbsolutePath());
                if (!curSongsList.contains(file.getName())) {
                    curSongsMap.put(file.getAbsolutePath(), "true");
                    curSongsKey.add(file.getAbsolutePath());
                    curSongsList.add(file.getName());
                    type = false;
                }
            } catch (IOException e) {
                mmr = null;
                e.printStackTrace();
            }
        } else { // audioUri 이용해 경로를 불러오지 못하는 경우
            try {
                if (index == null) { // 새로 음악을 추가한경우
                    mmr.setDataSource(getApplicationContext(), audioUri);
                    mp.setDataSource(getApplicationContext(), audioUri);
                    if (curSongsList.contains(mmr.extractMetadata(MediaMetadataRetriever.METADATA_KEY_TITLE))) {
                        // 핸드폰에서 파일을 불러왔을 때, 이미 재생목록에 존재하는 경우
                        Toast.makeText(getApplicationContext(), "목록에 존재하는 음악을 재생합니다.", Toast.LENGTH_SHORT).show();
                    } else {
                        curSongsMap.put(audioUri.toString(), "false");
                        curSongsKey.add(audioUri.toString());
                        curSongsList.add(mmr.extractMetadata(MediaMetadataRetriever.METADATA_KEY_TITLE));
                    }
                } else if (index != null) { // 리스트에 존재하는 음악을 불러오는 경우
                    mmr.setDataSource(getApplicationContext(), Uri.parse(curSongsKey.get(index)));
                    mp.setDataSource(getApplicationContext(), Uri.parse(curSongsKey.get(index)));
                }
            } catch (IOException e) {
                mmr = null;
                e.printStackTrace();
            }
        }
        if (mmr != null) {
            String album = mmr.extractMetadata(MediaMetadataRetriever.METADATA_KEY_TITLE);
            String artist = mmr.extractMetadata(MediaMetadataRetriever.METADATA_KEY_ARTIST);
            final String dur = mmr.extractMetadata(MediaMetadataRetriever.METADATA_KEY_DURATION);

            byte[] img = mmr.getEmbeddedPicture();

            if (album == null && artist == null) {
                album = file.getName();
            }
            curAlbum.setText(album);
            curArtist.setText(artist);
            curText.setText(album + " - " + artist);
            txtEnd.setText(timeFormat.format(Integer.parseInt(dur)));

            try {
                mp.prepare();
            } catch (IOException e) {
                e.printStackTrace();
            }
            mp.start();
            if (img != null) {
                Bitmap bitmap = BitmapFactory.decodeByteArray(img, 0, img.length);
                imageView.setImageBitmap(bitmap);
            } else {
                imageView.setImageResource(R.drawable.ic_cur_img); //태그 안에 이미지가 없는 경우
            }

            if (type) { // 핸드폰에서 목록을 가져온 경우
                Toast.makeText(getApplicationContext(), album + "을 현재재생목록에 추가했습니다.", Toast.LENGTH_LONG).show();
            }

            isPlaying = 1;
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.Q) {
                mmr.close();
            }
            onPause();
            curSeekBar.setMax(Integer.parseInt(dur));
            new Thread(new Runnable() {
                @Override
                public void run() {
                    while (mp.isPlaying()) {
                        try {
                            Thread.sleep(200);
                            curSeekBar.setProgress(mp.getCurrentPosition());
                            if (isPlaying == 0)
                                this.finalize();
                        } catch (Exception e) {
                            e.printStackTrace();
                        } catch (Throwable throwable) {
                            throwable.printStackTrace();
                        }
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                txtCur.setText(timeFormat.format(mp.getCurrentPosition()));
                            }
                        });
                    }
                }
            }).start();
            btnPlay.setImageResource(R.drawable.ic_cur_pause);
        }
    }

    private void initTab() {
        tabHost = findViewById(android.R.id.tabhost);
        tabHost.setup();
        tabHost.setOnTabChangedListener(new TabHost.OnTabChangeListener() {
            @Override
            public void onTabChanged(String tabId) {
                if (tabHost.getCurrentTabTag() == "Device") {
                    selectAudio();
                    tabHost.setCurrentTabByTag("cur");
                }
            }
        });


        final TabHost.TabSpec tabSpecweb = tabHost.newTabSpec("WEB").setIndicator("", getResources().getDrawable(R.drawable.ic_tab_web, null));
        tabSpecweb.setContent(R.id.tabWeb);

        webView = findViewById(R.id.tabWeb);
        webView.setWebViewClient(new WebViewClient());
        webView.getSettings().setUseWideViewPort(true);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.getSettings().setLoadWithOverviewMode(true);

        String mainUrl = "https://samplelib.com/sample-mp3.html";

        //String mainUrl = "http://172.26.102.90:8989/webTest/View/login/index.jsp";
//        String mainUrl = "https://file-examples.com/index.php/sample-audio-files/sample-mp3-download/";

        webView.loadUrl(mainUrl);
        webView.setDownloadListener(new DownloadListener() {
            @Override
            public void onDownloadStart(String url, String userAgent, String contentDisposition, String mimetype, long contentLength) {
                if (ContextCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.WRITE_EXTERNAL_STORAGE)
                        != PackageManager.PERMISSION_GRANTED) {
                    Toast.makeText(getBaseContext(), "다운로드를 위해\n권한이 필요합니다.", Toast.LENGTH_LONG).show();
                    ActivityCompat.requestPermissions(MainActivity.this, new String[]{android.Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1004);
                }
                try {
                    DownloadManager.Request request = new DownloadManager.Request(Uri.parse(url));
                    DownloadManager dm = (DownloadManager) getSystemService(DOWNLOAD_SERVICE);
                    downFileName = URLUtil.guessFileName(url, contentDisposition, mimetype);
                    request.setMimeType(mimetype);
                    request.addRequestHeader("User-Agent", userAgent);
                    request.setDescription("Downloading File");
                    request.setAllowedOverMetered(true);
                    request.setTitle(downFileName); // 노티피케이션에 보이는 타이틀
                    request.setDestinationInExternalPublicDir(Environment.DIRECTORY_DOWNLOADS, downFileName);
                    request.setAllowedOverMetered(true); // 데이터로 다운
                    request.setNotificationVisibility(DownloadManager.Request.VISIBILITY_VISIBLE_NOTIFY_COMPLETED);
                    dm.enqueue(request);
                    Toast.makeText(getApplicationContext(), "파일이 다운로드됩니다.", Toast.LENGTH_LONG).show();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });
        tabHost.addTab(tabSpecweb);
        //웹 페이지 탭

        TabHost.TabSpec tabCurList = tabHost.newTabSpec("curList").setIndicator("", getResources().getDrawable(R.drawable.ic_tab_curlist, null));
        tabCurList.setContent(R.id.tabCurList);
        tabHost.addTab(tabCurList);

        curSongsMap = new HashMap<>();
        curSongsList = new ArrayList<>();
        curSongsKey = new ArrayList<>();

        final ListView curListView = findViewById(R.id.tabCurList);
        curAdapter = new CurListAdapter(
                this,
                R.layout.item,
                curSongsList
        );

        curListView.setAdapter(curAdapter);
        curListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if (curSongsList.get(position).contains(curAlbum.getText()))
                    Toast.makeText(getApplicationContext(), "재생중인 음악입니다", Toast.LENGTH_SHORT).show();
                else {
                    try {
                        playMusic(null, position, false);
                    } catch (IOException e) {
                        throw new RuntimeException(e);
                    }
                }
                tabHost.setCurrentTabByTag("cur");
            }

        });

        curListView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE_MODAL);
        curListView.setMultiChoiceModeListener(new AbsListView.MultiChoiceModeListener() {
            @Override
            public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
                return false;
            }

            @Override
            public void onDestroyActionMode(ActionMode mode) {
            }

            @Override
            public boolean onCreateActionMode(ActionMode mode, Menu menu) {
                mode.getMenuInflater().inflate(R.menu.menu_main, menu);
                return true;
            }

            @Override
            public boolean onActionItemClicked(final ActionMode mode, MenuItem item) {
                switch (item.getItemId()) {
                    case R.id.selectAll:
                        final int checkedCount = curSongsList.size();
                        curAdapter.removeSelection();

                        for (int i = 0; i < checkedCount; i++) {
                            curListView.setItemChecked(i, true);
                        }
                        mode.setTitle(checkedCount + "개 파일");
                        return true;

                    case R.id.delete:
                        AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                        builder.setMessage("선택한 항목을 삭제하겠습니까?");
                        builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                            }
                        });
                        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {

                                SparseBooleanArray selected = curAdapter.getSelectedIds();
                                for (int i = (selected.size() - 1); i >= 0; i--) {
                                    if (selected.valueAt(i)) {
                                        curSongsList.remove(selected.keyAt(i));
                                        curSongsMap.remove(curSongsKey.get(selected.keyAt(i)));
                                        curSongsKey.remove(selected.keyAt(i));
                                    }
                                }
                                mode.finish();
                                selected.clear();
                                if(curSongsList.size() != 0) {
                                    try {
                                        playMusic(null, 0, false);
                                    } catch (IOException e) {
                                        throw new RuntimeException(e);
                                    }
                                    curSongIndex = 0;
                                }
                                else{
                                    if(isPlaying != 2){
                                        endMusic();
                                    }
                                }
                                curAdapter.notifyDataSetChanged();
                                onPause();
                            }
                        });
                        AlertDialog alert = builder.create();
                        alert.setIcon(R.drawable.ic_list_delete);
                        alert.setTitle("삭제");
                        alert.show();
                        return true;
                    case R.id.makeList:
                        AlertDialog.Builder listBuilder = new AlertDialog.Builder(MainActivity.this);
                        listBuilder.setTitle("재생목록 이름을 입력해주세요");
                        final EditText et = new EditText(getApplicationContext());
                        et.setTextColor(Color.WHITE);
                        listBuilder.setView(et);
                        listBuilder.setNegativeButton("취소", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                            }
                        });
                        listBuilder.setPositiveButton("확인", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                String name = et.getText().toString();
                                String value = null;
                                if (!name.equals("")) {
                                    try {
                                        FileOutputStream outFs = openFileOutput(name + ".txt", MODE_PRIVATE);
                                        SparseBooleanArray selected = curAdapter.getSelectedIds();
                                        int storeCount = 0;
                                        for (int i = 0; i < selected.size(); i++) {
                                            if (selected.valueAt(i)) {
                                                String key = curSongsKey.get(selected.keyAt(i));
                                                String type = curSongsMap.get(key);
                                                if (type == "true") { // 위치를 알 경우
                                                    if (value == null) {
                                                        value = key; // 처음 리스트에 작성하는 경우
                                                    } else if (value.contains(key))
                                                        continue; // 중복
                                                    else
                                                        value += key;
                                                    value += "##";
                                                    ++storeCount;
                                                } else {
                                                    continue;
                                                }
                                            }
                                        }
                                        selected.clear();
                                        outFs.write(value.getBytes());
                                        outFs.close();
                                        Toast.makeText(getApplicationContext(),  storeCount + "개 파일을 저장했습니다", Toast.LENGTH_SHORT).show();
                                    } catch (FileNotFoundException e) {
                                        e.printStackTrace();
                                    } catch (IOException e) {
                                        e.printStackTrace();
                                    }

                                    SharedPreferences prefMap = getSharedPreferences("SavedList", MODE_PRIVATE);
                                    SharedPreferences.Editor editor = prefMap.edit();
                                    editor.putString(name + ".txt", String.valueOf(System.currentTimeMillis()));
                                    editor.commit();
                                    editor.clear();
                                    savedList.add(name);
                                    mode.finish();
                                } else {
                                    Toast.makeText(getApplicationContext(), "재생목록 이름을 입력해주세요", Toast.LENGTH_SHORT).show();
                                }
                            }
                        });
                        //curAdapter.notifyDataSetChanged();
                        listBuilder.show();
                        return true;
                    default:
                        return false;
                }
            }

            @Override
            public void onItemCheckedStateChanged(ActionMode mode, int position, long id, boolean checked) {
                final int checkedCount = curListView.getCheckedItemCount();
                mode.setTitle(checkedCount + " 개 파일");
                curAdapter.toggleSelection(position);
            }
        });


        TabHost.TabSpec tabImg = tabHost.newTabSpec("cur").setIndicator("", getResources().getDrawable(R.drawable.ic_tab_play, null));
        tabImg.setContent(R.id.tabCur);
        tabHost.addTab(tabImg);

        LinearLayout LL = findViewById(R.id.tabCur);
        View view = getLayoutInflater().inflate(R.layout.cur_music, null);
        LL.addView(view);

        imageView = findViewById(R.id.curImg);
        curAlbum = findViewById(R.id.curAlbum);
        curArtist = findViewById(R.id.curArtist);
        txtEnd = findViewById(R.id.txtEnd);
        txtCur = findViewById(R.id.txtCur);
        curSeekBar = findViewById(R.id.curSeekBar);
        curSeekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                if (fromUser && (isPlaying != 2)) {
                    txtCur.setText(timeFormat.format(progress));
                    mp.seekTo(progress);
                }
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {

            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {

            }

        });
        curImg = findViewById(R.id.curMusicButton);
        curImg.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                tabHost.setCurrentTabByTag("curList");
            }
        });
        curText = findViewById(R.id.curMusicText);
        LinearLayout curLayout = findViewById(R.id.curMusicLayout);
        curLayout.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                tabHost.setCurrentTabByTag("cur");
            }
        });

        btnPlay = findViewById(R.id.btnPlay);
        btnPlay.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                switch (isPlaying) {
                    case 1:
                        btnPlay.setImageResource(R.drawable.ic_cur_play);
                        mp.pause();
                        isPlaying = 0;

                        break;
                    case 0:
                        btnPlay.setImageResource(R.drawable.ic_cur_pause);
                        mp.start();
                        new Thread(new Runnable() {
                            @Override
                            public void run() {
                                while (mp.isPlaying()) {
                                    try {
                                        Thread.sleep(500);
                                        curSeekBar.setProgress(mp.getCurrentPosition());
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                    runOnUiThread(new Runnable() {
                                        @Override
                                        public void run() {
                                            txtCur.setText(timeFormat.format(mp.getCurrentPosition()));
                                        }
                                    });
                                }
                            }
                        }).start();
                        isPlaying = 1;
                        break;
                    default:
                        Toast.makeText(getApplicationContext(), "선택된 음악이 없습니다.", Toast.LENGTH_SHORT).show();

                }

            }
        });

        btnBack = findViewById(R.id.btnBack); //!
        btnBack.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(curSongsKey.size() > 1){
                    if(curSongIndex > 0){
                        curSongIndex -= 1;
                        try {
                            playMusic(null, curSongIndex, false);
                        } catch (IOException e) {
                            throw new RuntimeException(e);
                        }
                    }else{
                        Toast.makeText(getApplicationContext(), "맨 처음 곡 입니다", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });

        btnBack10 = findViewById(R.id.btnBack10); //!
        btnBack10.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(isPlaying != 2){
                    int progress = curSeekBar.getProgress();
                    if(progress > 10000)
                        progress-=10000;
                    else
                        progress = 0;
                    mp.seekTo(progress);
                }
            }
        });

        btnFor = findViewById(R.id.btnFor); //!
        btnFor.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(curSongsKey.size() > 1){
                    if(curSongIndex != (curSongsKey.size()-1)){
                        curSongIndex ++ ;
                        try {
                            playMusic(null, curSongIndex, false);
                        } catch (IOException e) {
                            throw new RuntimeException(e);
                        }
                    }else{
                        Toast.makeText(getApplicationContext(), "맨 마지막 곡 입니다", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        });

        btnFor10 = findViewById(R.id.btnFor10); //!
        btnFor10.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (isPlaying != 2) {
                    int max = curSeekBar.getMax();
                    int cur = curSeekBar.getProgress();
                    if ((cur + 10000) < max)
                        cur += 10000;
                    else
                        cur = max;
                    mp.seekTo(cur);
                }
            }
        });


        TabHost.TabSpec tabSaveList = tabHost.newTabSpec("saveList").setIndicator("", getResources().getDrawable(R.drawable.ic_tab_musiclist, null));
        tabSaveList.setContent(R.id.tabSaveList);
        tabHost.addTab(tabSaveList);

        savedList = new ArrayList<>();
        ListView savedListView = findViewById(R.id.tabSaveList);
        saveAdapter = new SaveListAdapter(
                this,
                R.layout.item,
                savedList
        );
        savedListView.setAdapter(saveAdapter);
        savedListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                try {
                    FileInputStream inFs = openFileInput(savedList.get(position) + ".txt");
                    byte[] txt = new byte[300];
                    inFs.read(txt);
                    String musics = new String(txt).trim();
                    String[] music = musics.split("##");
                    curSongsMap.clear();
                    curSongsList.clear();
                    curSongsKey.clear();
                    for (int i = 0; i < music.length; i++) {
                        curSongsMap.put(music[i], "true");
                        curSongsList.add(new File(music[i]).getName());
                        curSongsKey.add(music[i]);
                    }
                    curSongIndex = 0;
                    curAdapter.notifyDataSetChanged();
                    inFs.close();
                    Toast.makeText(getApplicationContext(), "재생목록" + savedList.get(position) + "을(를) 불러옵니다", Toast.LENGTH_SHORT).show();
                } catch (FileNotFoundException e) {
                    Toast.makeText(getApplicationContext(), "선택된 재생목록이 없습니다.", Toast.LENGTH_SHORT).show();
                } catch (IOException e) {
                    e.printStackTrace();
                }
                try {
                    playMusic(null,curSongIndex,false);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        });


        TabHost.TabSpec tabDevice = tabHost.newTabSpec("Device").setIndicator("", getResources().getDrawable(R.drawable.ic_tab_device, null));
        tabDevice.setContent(R.id.tabDeviceList);
        tabHost.addTab(tabDevice);
    }

}