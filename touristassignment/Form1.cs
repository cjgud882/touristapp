using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace touristassignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void attractionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.attractionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database5DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database5DataSet.Attractions' table. You can move, or remove it, as needed.
            this.attractionsTableAdapter.Fill(this.database5DataSet.Attractions);
            // TODO: This line of code loads data into the 'database5DataSet.Attractions' table. You can move, or remove it, as needed.
            this.attractionsTableAdapter.Fill(this.database5DataSet.Attractions);

        }

        private void attractionsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.attractionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database5DataSet);

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            string type = comboBox2.SelectedItem.ToString();
            string ratings = ratingsCB.SelectedItem.ToString();
            string price = comboBox3.SelectedItem.ToString();
            string location = comboBox4.SelectedItem.ToString();
            string availability = comboBox5.SelectedItem.ToString();

            string name;



            // Query database  
            var attractionDetails =
               from c in database5DataSet.Attractions
               where c.Type == type
               where c.Ratings == ratings
               where c.Price == price
               where c.Location == location
               where c.Availability == availability
               select c;
            //attractionsDataGridView.DataSource = attractionDetails.AsDataView();

            if(attractionDetails.Count() <= 0)
            {
                textBox1.Text = "No Results Found.";

            } else
            {

                foreach (Database5DataSet.AttractionsRow item in attractionDetails)
                {
                    textBox1.Text += item.a_Name + "\n";
                    textBox1.Text += ", ";
                    // pictureBox1.ImageLocation = item.Map;

                }
            }

            

        }

        private void ratingsCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Visible = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex >= 1)
            {
                searchButton.Visible = true;
                clearButton.Visible = true;
            }
            
        }

        private void attractionsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchButton.Visible = false;
            ratingsCB.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;

            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            clearButton.Visible = false;
            
        }
    }
}
