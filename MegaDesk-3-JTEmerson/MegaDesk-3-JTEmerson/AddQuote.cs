using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_JTEmerson
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validate ints or strings
            if (!Int32.TryParse(textBox5.Text, out int result1))
            {
                MessageBox.Show("Width Must be a Number");
            }

            if (!Int32.TryParse(textBox4.Text, out int result2))
            {
                MessageBox.Show("Depth Must be a Number");
            }

            //validate width ranges
            if (Int32.TryParse(textBox5.Text, out int result3))
            {
                int width = int.Parse(textBox5.Text);

                if (width < 24 || width > 96)
                {
                    MessageBox.Show("Width must be between 24 and 96");
                }

            }

            //validate for depth ranges
            if (Int32.TryParse(textBox5.Text, out int result4))
            {
                int depth = int.Parse(textBox4.Text);

                if (depth < 12 || depth > 48)
                {
                    MessageBox.Show("Depth must be between 12 and 48");
                }

            }

        }
    }
}
