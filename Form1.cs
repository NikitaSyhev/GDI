using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI
{
    public partial class Form1 : Form
    {

        Point start;
        Point finish;
      
        Rectangle rectangle;
        List<Control> selectedItems = new List<Control>();
        List<AreaComment> comments_lst = new List<AreaComment>();


        public Form1()
        {
            InitializeComponent();
            addElementsToList();
          
        }
        private void addElementsToList()
        {
            selectedItems.Add(button1);
            selectedItems.Add(button2);
            selectedItems.Add(textBox1);
            selectedItems.Add(textBox2);
            selectedItems.Add(checkBox1);
            selectedItems.Add(checkBox2);
            selectedItems.Add(radioButton1);
            selectedItems.Add(radioButton2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Выдели элементы мышкой. Они отобразятся в ListBox");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           
            
                start = e.Location;
                
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
         
            finish = e.Location;
            var size = new Size(Math.Abs((start.X - finish.X)),
                Math.Abs((start.Y - finish.Y)));
            Point _start = new Point(
                start.X < finish.X ? start.X : finish.X,
                start.Y < finish.Y ? start.Y : finish.Y);
            Rectangle _rectangle = new Rectangle(_start, size);
            this.rectangle = _rectangle;
         
            listBox1.Items.Clear();
            string name = string.Empty;
            
            foreach (var item in selectedItems)
            {
                if (item is Button)
                {
                    var locButton = ((Button)item).Location;
                    if (rectangle.Contains(locButton.X, locButton.Y))
                    {
                        listBox1.Items.Add(((Button)item).Text);
                        
                    }
                }
                if (item is TextBox)
                {
                    var locTextBox = ((TextBox)item).Location;
                    if (rectangle.Contains(locTextBox.X, locTextBox.Y))
                    {
                        listBox1.Items.Add(((TextBox)item).Text);

                    }

                }
                if (item is CheckBox)
                {
                    var locCheckBox = ((CheckBox)item).Location;
                    if (rectangle.Contains(locCheckBox.X, locCheckBox.Y))
                    {
                        listBox1.Items.Add(((CheckBox)item).Text);

                    }

                }
                if (item is RadioButton)
                {
                    var locRadioButton = ((RadioButton)item).Location;
                    if (rectangle.Contains(locRadioButton.X, locRadioButton.Y))
                    {
                        listBox1.Items.Add(((RadioButton)item).Text);

                    }

                }

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var item in comments_lst)
            {
                if (item.Area.Contains(e.X, e.Y))
                {
                    Text = item.Text;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            finish = e.Location;
            textBox1.Clear();
            var size = new Size(Math.Abs((start.X - finish.X)),
                Math.Abs((start.Y - finish.Y)));
            Point _start = new Point(
                start.X < finish.X ? start.X : finish.X,
                start.Y < finish.Y ? start.Y : finish.Y);
            Rectangle _rectangle = new Rectangle(_start, size);
            //this.rectangle = _rectangle;
            textBox1.Visible = true;
            textBox1.Focus();

            textBox1.Enter += (object sender01, EventArgs e01) =>
            {
                var area = new AreaComment(textBox1.Text, _rectangle);
                comments_lst.Add(area);
            };
        }
    }
}
