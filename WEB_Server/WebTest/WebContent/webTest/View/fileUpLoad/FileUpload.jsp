
<%@page import="com.sun.tools.javac.util.Context"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@page import="com.oreilly.servlet.multipart.DefaultFileRenamePolicy" %>
    <%@page import="com.oreilly.servlet.MultipartRequest" %>
    <%@page import="java.utill.*" %>
   
    
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

<%
//실제 경로 
//String savedir = application.getRealPath("/saveFile");

String saveFolder="/upload";
ServletContext context = getServletContext();
//String savedir = context.getRealPath(saveFolder);

//ServletContext Context2 = getServletContext();
//String savedir = Context2.getRealPath(saveFolder);

//String savedir2= "C:\\Program Files (x86)\\Apache Software Foundation\\Tomcat 9.0\\webapps\\ROOT\\upload";
String savedir3 = "C:\\Users\\EaBEll\\Desktop\\java\\.metadata\\.plugins\\org.eclipse.wst.server.core\\tmp0\\wtpwebapps\\WebTest\\webTest\\upload";
String savedir = request.getSession().getServletContext().getRealPath("upload");

//String savedir= request.getServletPath(saveFolder);
//String savedir= "C:\\Users\\EaBEll\\Desktop\\java\\WebTest\\WebContent\\webTest\\upload\\";


//저장 최대 용량
 int maxSize = 1024*1024*15;

//한글 설정
String encoding = "utf-8";
try{
//사용자가 전송한 텍스트 정보 및 파일을 '/storage'에 저장하기(MultipartRequest의 매개변수에 맞춰서 위에서 지정한 변수를 넣어준 것)
/*		
MultipartRequest mr=new MultipartRequest(
				request,
				savedir,
				maxSize,
				encoding,
				new DefaultFileRenamePolicy()
		);
*/
MultipartRequest mr=new MultipartRequest(
		request,
		savedir3,
		maxSize,
		encoding,
		new DefaultFileRenamePolicy()
);






String music_name = mr.getParameter("music_name");
String album      = mr. getParameter("album");
  
String music_file= mr.getFilesystemName("music_file");
String music_ofile = mr.getOriginalFileName("music_file");



//String music_pictuer=mr.getFilesystemName("music_pictuer");
//String pictuer_ofile = mr.getOriginalFileName("music_pictuer");


}catch(Exception e){
	
}



%>

<jsp:forward page="fileList.jsp"></jsp:forward>


</body>




</html>