using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentProject
{
    public partial class Form2 : Form
    {

        static CatalogAcces ca = new CatalogAcces("Data Source=carsCatalog.db");

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string type = typeTextBox.Text;
            string make = makeTextBox.Text;
            string model = modelTextBox.Text;
            int price = Int32.Parse(priceTextBox.Text);
            int number = Int32.Parse(numberTextBox.Text);
            string color = colorTextBox.Text;
            string avail = "false";
            if (checkBox1.Checked) { avail = "true";}
            

            CarClass newCar = new CarClass( type, make, model, price, number, color, avail);
            ca.CreateCar(newCar);

            this.Close();
        }
    }
}
