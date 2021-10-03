using System;
using System.Windows.Forms;

namespace CarRentProject
{
    public partial class Form2 : Form
    {
        string scope = "Create";
        static CatalogAcces ca = new CatalogAcces("Data Source=carsCatalog.db");

        public Form2(string s)
        {
            InitializeComponent();
            scope = s;
            setTheForm(s);
        }
        private void setTheForm(string str)
        {   
                //Create
            if (str == "Create")
            {
                this.Text = "Add a new car.";
                idTextBox.Visible = false;
                label3.Text = "Add a New Car to the Database";
                button3.Text = "Add the Car";
            }
                //Update
            if (str == "Update")
            {
                this.Text = "Update a car.";
                button3.Text = "Update the Car";
            }
                 //Rent
            if (str == "Rent")
            {
                this.Text = "Rent a car.";
                button3.Text = "Rent the Car";
                typeTextBox.Enabled = false;
                makeTextBox.Enabled = false;
                modelTextBox.Enabled = false;
                priceTextBox.Enabled = false;
                numberTextBox.Enabled = false;
                colorTextBox.Enabled = false;
                checkBox1.Visible = false;
            }
                //Delete
            if (str == "Delete")
            {
                this.Text = "Drop a car.";
                button3.Text = "Destroy the Car";
                typeTextBox.Enabled = false;
                makeTextBox.Enabled = false;
                modelTextBox.Enabled = false;
                priceTextBox.Enabled = false;
                numberTextBox.Enabled = false;
                colorTextBox.Enabled = false;
                checkBox1.Visible = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            string type = "";
            string make = "";
            string model = "";
            int price = 0;
            int number = 0;
            string color = "";
            string avail = "false";

            if (scope != "Create")
            {
                id = Int32.Parse(idTextBox.Text);
            }
            if (scope != "Delete" && scope != "Rent")
            {
                type = typeTextBox.Text;
                make = makeTextBox.Text;
                model = modelTextBox.Text;
                price = Int32.Parse(priceTextBox.Text);
                number = Int32.Parse(numberTextBox.Text);
                color = colorTextBox.Text;
                if (checkBox1.Checked) { avail = "true";}
            }
            

            switch (scope)
            {
                case "Rent":
                    CarClass RentCar = new CarClass(id);
                    ca.RentCar(RentCar);
                    break;
                case "Delete":
                    CarClass DeleteCar = new CarClass(id);
                    ca.DeleteCar(DeleteCar);
                    break;
                case "Update":
                    CarClass UpdateCar = new CarClass(id, type, make, model, price, number, color, avail);
                    ca.UpdateCar(UpdateCar);
                    break;
                default:
                    CarClass CreateCar = new CarClass(type, make, model, price, number, color, avail);
                    ca.CreateCar(CreateCar);
                    break;
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
