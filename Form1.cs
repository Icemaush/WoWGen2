using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWGenGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void update_labels()
        {
            label5.Text = Program.faction;
            label5.Update();
            label6.Text = Program.race;
            label6.Update();
            label7.Text = Program.job;
            label7.Update();
            label8.Text = Program.spec;
            label8.Update();
        }

        private void update_images()
        {
            if (pictureBox1.Image != null && pictureBox2.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox2.Image.Dispose();
            }
            
            Object image1 = Properties.Resources.ResourceManager.GetObject(Program.job_img);
            pictureBox1.Image = (Image)image1;
            
            Object image2 = Properties.Resources.ResourceManager.GetObject(Program.spec_img);
            pictureBox2.Image = (Image)image2;
            pictureBox1.Update();
            pictureBox2.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.GenChar();
            update_labels();
            update_images();
        }
    }
}
