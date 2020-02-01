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

namespace 나도가수다
{
    public partial class Form_MusicList : MetroFramework.Forms.MetroForm
    {
       string[] files;

        public string [] File
        {
            get; set;
        }
        public Form_MusicList()
        {
            InitializeComponent();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
             File = (string[])e.Data.GetData(DataFormats.FileDrop);
            //files = Path.GetFileName(files);
            foreach (string file in files) listBox1.Items.Add(File);
            
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
