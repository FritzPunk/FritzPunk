using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResistenceCalculator
{
    public partial class ResistorCalculator : Form
    {
        List<String> percentages = new List<String>();
        int pen_size = 3;
        List<SolidBrush> pens = new List<SolidBrush>();
        List<SolidBrush> pens3 = new List<SolidBrush>();
        List<SolidBrush> pens4 = new List<SolidBrush>();
        bool draw = false, comb1 = false, comb2 = false, comb3 = false, comb4 = false;

        public ResistorCalculator()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Grey", "White" });
            comboBox2.Items.AddRange(new string[] { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Grey", "White" });
            comboBox3.Items.AddRange(new string[] { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Purple" ,"Gold","Silver"});
            comboBox4.Items.AddRange(new string[] { "Brown", "Red", "Green", "Blue", "Purple","Gray", "Gold", "Silver" });
            percentages.AddRange(new string[] { "± 1%", "± 2%", "± 0.5%", "± 0.25%", "± 0.10%", "± 0.05%", "± 5%", "± 10%" });
            pens.AddRange(new SolidBrush[] { new SolidBrush(Color.Black), new SolidBrush(Color.Brown), new SolidBrush(Color.Red), new SolidBrush(Color.Orange), new SolidBrush(Color.Yellow ), new SolidBrush(Color.Green ), new SolidBrush(Color.Blue ), new SolidBrush(Color.Purple ), new SolidBrush(Color.Gray ), new SolidBrush(Color.White ) });
          //  pens2.AddRange(new SolidBrush[] { new SolidBrush(Color.Black ), new SolidBrush(Color.Brown ), new SolidBrush(Color.Red ), new SolidBrush(Color.Orange ), new SolidBrush(Color.Yellow ), new SolidBrush(Color.Green ), new SolidBrush(Color.Blue ), new SolidBrush(Color.Purple ), new SolidBrush(Color.Gray ), new SolidBrush(Color.White ) });
            pens3.AddRange(new SolidBrush[] { new SolidBrush(Color.Black ), new SolidBrush(Color.Brown ), new SolidBrush(Color.Red ), new SolidBrush(Color.Orange ), new SolidBrush(Color.Yellow ), new SolidBrush(Color.Green ), new SolidBrush(Color.Blue ), new SolidBrush(Color.Purple ), new SolidBrush(Color.Gold ), new SolidBrush(Color.Silver ) });
            pens4.AddRange(new SolidBrush[] { new SolidBrush(Color.Brown ), new SolidBrush(Color.Red ), new SolidBrush(Color.Green ), new SolidBrush(Color.Blue ), new SolidBrush(Color.Purple ), new SolidBrush(Color.Gray ), new SolidBrush(Color.Gold ), new SolidBrush(Color.Silver ) });
           // comboBox1.
        }
        
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb1 = true;
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            draw = false;
            int a,b,c,d;
            if(comboBox1.SelectedItem != null && comboBox2.SelectedItem != null  && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null)
            {
                draw = true;
               double result = 0 ;
                label1.Text =  comboBox1.SelectedIndex.ToString();
                if(comboBox3.SelectedIndex != 8 && comboBox3.SelectedIndex != 9)
                result = (comboBox1.SelectedIndex*10 + comboBox2.SelectedIndex ) * Math.Pow(10,comboBox3.SelectedIndex) ;
                else{
                    if(comboBox3.SelectedIndex ==8 )
                    result = (comboBox1.SelectedIndex * 10 + comboBox2.SelectedIndex) *0.1;
                    else
                    result = (comboBox1.SelectedIndex * 10 + comboBox2.SelectedIndex) * 0.01;
                }
                label1.Text = Convert.ToString(result) + "Ω" + percentages[comboBox4.SelectedIndex];
            }
            Refresh();

        }
        int width =  50;
        int height = 50;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb2 = true;
            Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb3 = true;
            Refresh();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb4 = true;
            Refresh();
        }

        private void ResistorCalculator_Load(object sender, EventArgs e)
        {

        }

        int wire = 10;


        int x = 150 ;
        int y = 35 ;

        //private void draw_resistor(PaintEventArgs e)
        //{
            
        //    // Draw rectangle to screen.
        //    e.Graphics.FillRectangle(new SolidBrush(Color.Black) , wire1);

        //    e.Graphics.FillRectangle(pens[comboBox1.SelectedIndex], rect);
        //    e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect);

        //    e.Graphics.FillRectangle(pens[comboBox2.SelectedIndex], rect2);
        //    e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect2);

        //    e.Graphics.FillRectangle(pens3[comboBox3.SelectedIndex], rect3);
        //    e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect3);

        //    e.Graphics.FillRectangle(pens4[comboBox4.SelectedIndex], rect4);
        //    e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect4);

        //    e.Graphics.FillRectangle(new SolidBrush(Color.Black), wire2);
        //}
   
        private void ResistorCalculator_Paint(object sender, PaintEventArgs e)
        {
            // Create rectangle.
            Rectangle wire1 = new Rectangle(x - width, y + height / 2 - wire / 2, width, wire);
            Rectangle rect = new Rectangle(x, y, width, height);
            Rectangle rect2 = new Rectangle(x + width, y, width, height);
            Rectangle rect3 = new Rectangle(x + width * 2, y, width, height);
            Rectangle rect4 = new Rectangle(x + width * 3, y, width, height);
            Rectangle wire2 = new Rectangle(x + width * 4, y + height / 2 - wire / 2, width, wire);
            // if(draw)
            //draw_resistor (e);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), wire1);
            e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect);
            e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect2);
            e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect3);
            e.Graphics.DrawRectangle(new Pen(Color.SandyBrown, pen_size), rect4);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), wire2);
            if (comb1)
                e.Graphics.FillRectangle(pens[comboBox1.SelectedIndex], rect);

            if (comb2)
                e.Graphics.FillRectangle(pens[comboBox2.SelectedIndex], rect2);

            if (comb3)
                e.Graphics.FillRectangle(pens3[comboBox3.SelectedIndex], rect3);

            if (comb4)
                e.Graphics.FillRectangle(pens4[comboBox4.SelectedIndex], rect4);
            
        }
    }
}
