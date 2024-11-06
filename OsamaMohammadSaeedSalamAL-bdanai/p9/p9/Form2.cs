using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p10
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string UpdatedValue1 { get; set; }
        public string UpdatedValue2 { get; set; }
        public string UpdatedValue3 { get; set; }
 

        // Constructor لتلقي القيم من النموذج الرئيسي
        public Form2(string value1, string value2, string value3)
        {
            InitializeComponent();


            textBox1.Text = value1;
            textBox2.Text = value2;
            textBox3.Text = value3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
            !string.IsNullOrWhiteSpace(textBox2.Text) &&
            !string.IsNullOrWhiteSpace(textBox3.Text))
           
        {
            // حفظ القيم المعدلة
            UpdatedValue1 = textBox1.Text;
            UpdatedValue2 = textBox2.Text;
            UpdatedValue3 = textBox3.Text;
          
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            MessageBox.Show("يرجى ملء جميع الحقول.");
        }
        }
    }
}

