using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenRec2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //save button for profile editor
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Form2Save();
            Program.Form2Hide();
            Program.Form1SetValues();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            byte[] imagefile = File.ReadAllBytes(path);
            File.Replace(path, "SaveData\\Profile\\profileimage.png", "backupfilename.png");
            File.WriteAllBytes(path, imagefile);
            File.Delete("backupfilename.png");
            imagefile = null;
            Program.Form2SetValues();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
