using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentProject
{
    public partial class Form1 : Form
    {
        static CatalogAcces ca = new CatalogAcces("Data Source=carsCatalog.db");
        CarClass[] carArray;
        CarClass[] typeArray;

        public Form1()
        {
            InitializeComponent();
            carArray = ca.ReadAllCars();
            typeArray = ca.ReadCarByType();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carArray = ca.ReadAllCars();
            string allCars = "";
            for (int i = 0; i < carArray.Length; i++)
            {
                if (carArray[i].Availability == "false")
                {
                    richTextBox1.BackColor = Color.Bisque;
                }
                allCars = allCars + carArray[i].AsString();
            }
            richTextBox1.Text = allCars;
        }

                    //Extra
        private void button2_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Extra");
            richTextBox1.Text = typeArray[0].AsString();

            string allCars = "";
            for (int i = 0; i < typeArray.Length; i++)
            {
                allCars = allCars + typeArray[i].AsString();
            }
            richTextBox1.Text = allCars;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

                //Compact
        private void button3_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Compact");
            richTextBox1.Text = typeArray[0].AsString();

            string allCars = "";
            for (int i = 0; i < typeArray.Length; i++)
            {
                allCars = allCars + typeArray[i].AsString();
            }
            richTextBox1.Text = allCars;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 CreateNewCar = new Form2();
            CreateNewCar.ShowDialog();
        }
    }
}
