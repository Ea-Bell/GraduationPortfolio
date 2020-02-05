using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace 나도가수다
{
    public partial class Form_MusicList : MetroFramework.Forms.MetroForm
    {
        int selected;
        static  int count = 0;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public Form_MusicList()
        {
            InitializeComponent();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            List<string> text = new List<string>();

            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            for (int i = 0; i < s.Length; i++)
            {
                text.Add(s[i]);
            }

            foreach (string str in text)
            {

                if (count == 0)
                {
                    Xml.XmlFile(str, System.IO.Path.GetFileName(str).ToString());
                    count++;
                }
                else if (count > 0 || count < 5)
                {
                    Xml.XmlFileAdd(str, System.IO.Path.GetFileName(str).ToString());
                    count++;
                }
                else
                {
                    MessageBox.Show("200개 이상의 음원을 넣을 수 없습니다.");
                }

            }

            Xml.fm = this;
            listBox1.Items.Clear();
            Xml.XmlFileRead();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_MusicList_Load(object sender, EventArgs e)
        {
            try
            {
                Xml.fm = this;
                Xml.XmlFileRead();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.StackTrace); }   
        }
    }
    static public class Xml
    {
        static public Form_MusicList fm = null;
        static private string filePath = "info.xml";

        static XElement playListFile;
        static XmlDocument xml = new XmlDocument();

        static public void XmlFile(string path, string name)
        {
            playListFile =
                 new XElement("Root",
                     new XElement("MyList",
                         new XElement("Name", name),
                         new XElement("AbsolutePath", "@" + path)
                         )
                         );
            playListFile.Save(filePath);
        }

        static public void XmlFileAdd(string path, string name)
        {

            playListFile = XElement.Load(filePath);

            playListFile.Add(
                             new XElement("MyList",
                             new XElement("Name", name),
                             new XElement("AbsolutePath", "@" + path)));
            playListFile.Save(filePath);

        }

        static public void XmlFileRead()
        {
            //IEnumerable<string> names = from customers in
            //                                XDocument.Load(filePath)
            //                                          .Descendants("MyList")
            //                            select customers.Element("Name").Value;


            IEnumerable<string> names = from customers in
                                            XDocument.Load(filePath)
                                                      .Descendants("MyList")
                                            //select customers.Element("Name").Value;

                                        select customers.Element("Name").Value;

            foreach (string Name in names)
            {
                fm.listBox1.Items.Add(Name);
            }
        }



        //노드 삭제 안됨 
        //노드를 삭제할려면 리스트 박스에서 선태후(자식 노드중 리스트 박스에 대한 선택된 정보? 찾아서 추가해야 한다.) xml에서 찾아서 삭제 해야한다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Select"> 삭제할 노드</param>
        static public void XmlFileDelet(int Select)
        {
            xml.Load(filePath);

            try
            {
                // XmlNode t = xml.SelectSingleNode("/Root/MyList [@Chart=" + Select.ToString() + "]");
                System.Xml.XmlNode t = xml.SelectSingleNode("/Root/MyList");
                t.ParentNode.RemoveChild(t);

            }
            catch (Exception ex)
            {
                // playListFile.Element("MyList");
            }
            finally
            {

                xml.Save(filePath);
            }
            fm.Count--;
            

            //playListFile = XElement.Load(fileName);

            //var xmlQury = from xQury in playListFile.Descendants() select xQury;
            //foreach (var xList in xmlQury)
            //{
            //    if (xList.Name == "MyList")
            //    {
            //        xList.SetAttributeValue("MyList", xmlQury.Count());
            //        //xList.SetValue(xmlQury.Count());
            //    }
            //}
            //playListFile.Save(fileName);
        }

    }
}
