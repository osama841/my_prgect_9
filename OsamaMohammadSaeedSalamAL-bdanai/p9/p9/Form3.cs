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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox3.TextChanged += textBox3_TextChanged;
            textBox4.TextChanged += textBox4_TextChanged;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddToListBox(listBox1, textBox1);
            textBox1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AddToListBox(listBox2, textBox2);
            textBox2.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            AddToListBox(listBox4, textBox4);
            textBox4.Clear();
        
        }
        // داله لي اضافة لداخل listbox على حسب مربع النص المرسل والقائمة الاوله الثانية 
        private void AddToListBox(ListBox listBox, TextBox textBox)
        {

            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {

                listBox.Items.Add(textBox.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            AddToListBox(listBox3, textBox3);
            textBox3.Clear();
      
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

        // داله تقوم بي التحديد عبر الاندكس بكل قائمة نفس الاندكس الاول يلي في القائمة الاولة يتضللو كامل
        private void selectItems(ListBox listBox)
        {
            if (listBox.Items.Count > 0 && listBox.Items.Count == listBox1.Items.Count)
            {
                int selectedIndex = listBox1.SelectedIndex;  

                // التأكد من أن هناك فهرسًا محددًا في listBox1
                if (selectedIndex != -1)
                {

                    listBox.SetSelected(selectedIndex, true);
                }

                // طريقة اخره
                //if (listBox.Items.Count > 0 && listBox.Items.Count == listBox1.Items.Count)
                //{
                //    for (int i = 0; i < listBox.Items.Count; i++)
                //    {
                //        listBox.SetSelected(i, listBox1.SelectedIndices.Contains(i));
                //    }
                //}
            }
        }
        // المضاعفه 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                selectItems(listBox2);
                selectItems(listBox3);
                selectItems(listBox4);
            }
        }
        // زر الحساب بنا على الفهرس المحدد
        private void button4_Click(object sender, EventArgs e)
        {
             if (listBox1.SelectedIndex != -1)
       {
        int selectedIndex = listBox1.SelectedIndex;
          // فحص بي الاندكس
        if (listBox2.Items.Count > selectedIndex && listBox3.Items.Count > selectedIndex)
        {
            // استخراج العملية الحسابية من ListBox2
            string operation = listBox2.Items[selectedIndex].ToString();

            // استخراج الأرقام من ListBox1 و ListBox3
            double number1 = Convert.ToDouble(listBox1.Items[selectedIndex].ToString());
            double number2 = Convert.ToDouble(listBox3.Items[selectedIndex].ToString());

            // متغير لتخزين النتيجة
            double result = 0;

            if (operation == "+")
            {
                result = number1 + number2;
            }
            else if (operation == "*")
            {
                result = number1 * number2;
            }
            else if (operation == "-")
            {
                result = number1 - number2;
            }
            else if (operation == "/")
            {
                result = number1 / number2;
            }
            else
            {
                MessageBox.Show("العملية غير معروفة");
                return;
            }

            listBox4.Items.Clear();
            listBox4.Items.Add(result);
        }
        else
        {
            MessageBox.Show("تأكد من أن القوائم تحتوي على نفس عدد العناصر.");
        }
    }           
       }
   
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.SelectedIndex = listBox3.SelectedIndex = listBox4.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox2.SelectedIndex = listBox1.SelectedIndex = listBox4.SelectedIndex = listBox3.SelectedIndex;

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox2.SelectedIndex = listBox3.SelectedIndex = listBox1.SelectedIndex = listBox4.SelectedIndex;

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        if (listBox1.SelectedIndices.Count > 0)
        {
           
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                 int index = listBox1.SelectedIndices[i];  

                listBox1.Items.RemoveAt(index);
                listBox2.Items.RemoveAt(index);
                listBox3.Items.RemoveAt(index);
                listBox4.Items.RemoveAt(index);
            }
        }
        else
        {
            MessageBox.Show("يرجى تحديد العناصر المراد حذفها.");
        }
    }
    
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

              // تأكد من أن هناك عنصرًا محددًا
        if (listBox1.SelectedIndex != -1)
        {
            // احصل على الفهرس المحدد
            int selectedIndex = listBox1.SelectedIndex;

            // قم بتمرير القيم إلى النموذج الفرعي (Form2)
            Form2 editForm = new Form2(
                listBox1.Items[selectedIndex].ToString(),
                listBox2.Items[selectedIndex].ToString(),
                listBox3.Items[selectedIndex].ToString());
          
           

            // عند إغلاق النموذج الفرعي، استقبل التعديلات
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // تحديث القيم في ListBox في النموذج الرئيسي
                listBox1.Items[selectedIndex] = editForm.UpdatedValue1;
                listBox2.Items[selectedIndex] = editForm.UpdatedValue2;
                listBox3.Items[selectedIndex] = editForm.UpdatedValue3;
        
            }
        }
        else
        {
            MessageBox.Show("يرجى تحديد عنصر من القائمة لتعديله.");
        }
    
            //if (listBox1.SelectedIndex != -1)
            //{
            //    int selectedIndex = listBox1.SelectedIndex;

            //    // التأكد من أن جميع ListBox تحتوي على نفس عدد العناصر
            //    if (listBox2.Items.Count > selectedIndex && listBox3.Items.Count > selectedIndex && listBox4.Items.Count > selectedIndex)
            //    {
            //        // التحديد عبر جميع الـ ListBoxes
            //        listBox1.SetSelected(selectedIndex, true);
            //        listBox2.SetSelected(selectedIndex, true);
            //        listBox3.SetSelected(selectedIndex, true);
            //        listBox4.SetSelected(selectedIndex, true);

            //        // قم بتمكين تحرير العناصر في الـ TextBox أو أي مكان آخر تريد تعديل القيم فيه.
            //        textBox1.Text = listBox1.Items[selectedIndex].ToString();
            //        textBox2.Text = listBox2.Items[selectedIndex].ToString();
            //        textBox3.Text = listBox3.Items[selectedIndex].ToString();
            //        textBox4.Text = listBox4.Items[selectedIndex].ToString();
            //    }
            //    else
            //    {
            //        MessageBox.Show("تأكد من أن القوائم تحتوي على نفس عدد العناصر.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("يرجى تحديد عنصر من القائمة الأولى.");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    }
