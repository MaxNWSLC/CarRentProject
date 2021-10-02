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

        // method to keep the code dry!
        private void showTheInfo(int s)
        {
            string allCars = "";
            for (int i = 0; i < typeArray.Length; i++)
            {
                allCars = allCars + typeArray[i].AsString(s);
            }
            richTextBox1.Text = allCars;
        }

                    //Show all
        private void button1_Click(object sender, EventArgs e)
        {
            carArray = ca.ReadAllCars();

            string allCars = "";
            for (int i = 0; i < carArray.Length; i++)
            {
                allCars = allCars + carArray[i].AsString();
            }
            richTextBox1.Text = allCars;
        }

                    //Extra
        private void button2_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Extra");
            showTheInfo(1);
        }

                   //Economy
        private void button4_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Economy");
            showTheInfo(1);
        }

                //Compact
        private void button3_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Compact");
            showTheInfo(1);
        }

                    //Mid-Size
        private void button5_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Midsize");
            showTheInfo(1);
        }

                    //Mini
        private void button6_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Mini");
            showTheInfo(1);
        }
                    //PeopleCarier
        private void button7_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("PeopleCarier");
            showTheInfo(1);
        }
                    //Van
        private void button8_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByType("Van");
            showTheInfo(1);
        }


                    //BMW
        private void button10_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("BMW");
            showTheInfo(2);
        }
                    //Fiat
        private void button11_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("Fiat");
            showTheInfo(2);
        }
                    //Ford
        private void button12_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("Ford");
            showTheInfo(2);
        }

                //  Hyunday  
        private void button13_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("Hyunday");
            showTheInfo(2);
        }

                //  Nissan
        private void button14_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("Nissan");
            showTheInfo(2);
        }

                //  VW
        private void button15_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("VW");
            showTheInfo(2);
        }

                //  Vauxhall
        private void button16_Click(object sender, EventArgs e)
        {
            typeArray = ca.ReadCarByMake("Vauxhall");
            showTheInfo(2);
        }

//----------------------------------------------------------------------------//
                    //Add a Car
        private void button9_Click(object sender, EventArgs e)
        {
            Form2 CreateNewCar = new Form2("Create");
            CreateNewCar.ShowDialog();
        }
                    //Update or rent a car
        private void button17_Click(object sender, EventArgs e)
        {
            Form2 CreateNewCar = new Form2("Update");
            CreateNewCar.ShowDialog();
        }

                    // Delete a car
        private void button18_Click(object sender, EventArgs e)
        {
            Form2 CreateNewCar = new Form2("Delete");
            CreateNewCar.ShowDialog();
        }
                    //Rent a Car 
        private void button19_Click(object sender, EventArgs e)
        {
            Form2 CreateNewCar = new Form2("Rent");
            CreateNewCar.ShowDialog();
        }
    }
}
