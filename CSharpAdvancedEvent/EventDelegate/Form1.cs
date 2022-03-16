using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         * 
         public delegate void EventHandler(object sender, EventArgs e);
         public event EventHandler Click
        


        在 private System.Windows.Forms.Button button1;对象里定义并且调用 了事件
        //EventArgs事件参数的基类
         */

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1_Click");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button2_Click");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button3_Click");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
