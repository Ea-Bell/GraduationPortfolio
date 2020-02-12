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
       
        public Form_MusicList()
        {
            InitializeComponent();
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) metroListView1.Items.Add(file);
            metroListView1.Items[0].Selected = true;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        
    }
}
