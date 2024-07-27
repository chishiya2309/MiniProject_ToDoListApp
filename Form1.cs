using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        bool isEditing = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");

            toDoListView.DataSource = dt;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            titleTextBox.Text = dt.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = dt.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void toDoListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "+ ex);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                   dt.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                   dt.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
            }
            else
            {
                dt.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }

        private void toDoListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void toDoListView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow r in toDoListView.Rows)
            {
                bool isChecked = Convert.ToBoolean(r.Cells[0].Value);
                if (isChecked == false)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                    r.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (isChecked == true)
                {
                    r.DefaultCellStyle.BackColor = Color.Green;
                    r.DefaultCellStyle.ForeColor = Color.Black;
                }
            }    
        }
    }
}
