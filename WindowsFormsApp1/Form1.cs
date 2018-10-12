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


namespace WindowsFormsApp1
{
    //enum Color { Red = 10, Blue = 20, Green= 300 };
    internal interface ILazyWorker { int WastedTime(); }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            //textBox2.Text = result2.ToString();// firstSmallNumbers.l ..Count.ToString();
            //textBox1.Text = evenNumbers[1].ToString();
            //textBox2.Text = arr.Length.ToString();
            //textBox1.Text = i.ToString();
            //textBox2.Text = i.GetValueOrDefault().ToString();
            //textBox4.Text = date4.ToString();
            //textBox5.Text = date5.ToString();//4.ToString();
            //textBox5.Text = a.GetLength(0).ToString();
        }


        class Cat
        {
            // Auto-implemented properties.
            public int Age { get; private set; }
            public string Name { get; set; }
        }


        public struct MyStru {
            public int myField;
            public const int myConst = 77;
            public int Method1(string s) {return myField; }
            public struct MyStruB { public int y; }

        }  //basic struct with a public field

        #region hide required code section


        private void btnFormat_Click(object sender, EventArgs e)
        {
            HelperClass.ParseRichTextBox(richTextBox1, "Consolas", 10);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //DataFormats Class
            //richTextBox1.SelectAll();
            //richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionFont = new Font("Consolas", 10);

            Clipboard.SetText(richTextBox1.Rtf, TextDataFormat.Rtf);

        }
        #endregion
    }
}