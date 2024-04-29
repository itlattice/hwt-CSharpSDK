using CSharpSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
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

        private void button1_Click(object sender, EventArgs e)
        {
            HwtApi hwtApi = new HwtApi(new Config("20240400007087", "d79b744343e27c05uOFoxOCl", false));
            string result = hwtApi.Basic().ApiOrderRoute("aaa");
            MessageBox.Show(result);
        }
    }
}
