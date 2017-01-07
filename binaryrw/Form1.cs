using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace binaryrw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd_obj = new OpenFileDialog();
            if (ofd_obj.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                path = ofd_obj.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BinaryReader br_obj = new BinaryReader(File.OpenRead(path));
            br_obj.BaseStream.Position = 0x00;
            foreach(char mychar in br_obj.ReadChars(5)) textBox1.Text += mychar; 
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BinaryWriter bw_obj = new BinaryWriter(File.OpenWrite(path));
            short s = 1;
            byte[] buffer = BitConverter.GetBytes(s);
            Array.Reverse(buffer);
            bw_obj.Dispose();
        }
    }
}