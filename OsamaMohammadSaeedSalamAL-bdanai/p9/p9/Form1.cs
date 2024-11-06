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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Random f = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    int r = f.Next(100);
            //    listBox1.Items.Add(r);
            //}

            panel2.Visible = false;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (isnumoric(textBox1.Text.Trim())) ;
            {
                if (!repeaead(listBox1, textBox1.Text))
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("الرقم موجود مسبقا");
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            //listBox1.SelectionMode = SelectionMode.MultiExtended;
            int c = listBox1.SelectedItems.Count;
            for (int i = 0; i < c; i++)
            {
                if (!repeaead(listBox2, listBox1.SelectedItems[0].ToString()))
                {

                    listBox2.Items.Add(listBox1.SelectedItems[0]);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    //listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int c = listBox1.Items.Count;
            for (int i = 0; i < c; i++)
            {
                if (!listBox2.Items.Contains(listBox1.Items[0])) ;
                {

                    listBox2.Items.Add(listBox1.Items[0]);
                    listBox1.Items.Remove(listBox1.Items[0]);
                }
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            storanylistbox(listBox1);
        }



        private void storanylistbox(ListBox x)
        {
            int z; int c = x.Items.Count;
            for (int i = 0; i < c; i++)
            {
                for(int j=i+1; j < c ;j++)
                {
                    int m1 = Convert.ToInt32(x.Items[i]),
                        m2 = Convert.ToInt32(x.Items[j]);
                    if (m1 < m2)
                    {
                        z = m1;
                        x.Items[i] = m2;
                        x.Items[j] = z;
                    }
                }
            }
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBox1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            if (radioButton1.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if(Convert.ToInt32(listBox1.Items[i])%2==0);
                    listBox1.SelectedIndex=i;
                }
                if (listBox1.SelectedIndex == -1)
                    MessageBox.Show("لاتوجد عناصر");
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
                   if (radioButton2.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if(Convert.ToInt32(listBox1.Items[i])%2!=0);
                    listBox1.SelectedIndex=i;
                }
                if (listBox1.SelectedIndex == -1)
                    MessageBox.Show("لاتوجد عناصر فردية");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            bool flag=true;
            if (radioButton3.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    int n = Convert.ToInt32(listBox1.Items[i]);
                    flag = true;
                    for (int j = 2; j < n; j++)
                    {
                        if (n % j == 0) { flag = false; break; }
                    }

                    if (flag == true)
                        listBox1.SelectedIndex = i;
                }
            }
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("لاتوجد عناصر اولية");
        }

        bool isnumoric(string elemint)
        {
            if (elemint == "") return false;
            for (int i = 0; i < elemint.Length; i++)
            {
                if (elemint[i] < 48 || elemint[i] > 57)
                    return false;
            }
            return true;

        }
        bool repeaead(ListBox l, string s)
        {
            for (int i = 0; i < l.Items.Count; i++)
            {
                if (l.Items[i].ToString() == s)
                    return true;
            }
            return false;
        }
        void setEnabld()
        {
            button2.Enabled = listBox1.SelectedIndex > -1;
        }
        void revers(ListBox x)
        {
            for (int i = x.Items.Count - 1; i >= 0; i--)
            {
                x.Items.Add(x.Items[i]);
                x.Items.Add(x.Items[i]);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!=1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

      
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
             int c = listBox1.Items.Count;
            for (int i = 0; i < c; i++)
            {
    
                    listBox2.Items.Add(listBox1.Items[listBox1.Items.Count-1]);
                    listBox1.Items.Add(listBox1.Items[listBox1.Items.Count - 1]);
              
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            revers(listBox2);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            storanylistbox(listBox2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Add(textBox2.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Remove(textBox2.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox6.Text = listBox1.SelectedItems.Count.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox5.Text = (listBox1.Items.Count - listBox1.SelectedItems.Count).ToString();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            //textBox7.Text = listBox1.Items.Count.ToString();
           //التكليف
            int x = 0;
            bool endlist = false;


            for (int i = 0; !endlist; i++)
            {
                try
                {
                    int n = Convert.ToInt32(listBox1.Items[i]);
                    x += 1;  
                }
                catch
                {
                    endlist = true;
                }
                textBox7.Text = x.ToString();
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SelectedIndex = i;
                }

            }
            else
                MessageBox.Show(" not found elements");
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != 1)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        //private void MoveSelectedItems()
        //{
         
        //    if (listBox1.SelectedItems.Count > 0)
        //    {
           
        //        for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
        //        {
                    
        //            var item = listBox1.SelectedItems[i];
        //            listBox2.Items.Add(item);
        //            listBox1.Items.Remove(item);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("يرجى تحديد عنصر واحد أو أكثر لنقله.");
        //    }

        //}

 
    }
}
