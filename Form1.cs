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
            
            dt.Columns.Add("Checked", typeof(bool));
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("Day set",typeof(DateTime));
            dt.Columns.Add("Deadline", typeof(DateTime));
            dt.Columns.Add("Priority", typeof(bool));

            dt.DefaultView.Sort = "Priority DESC, Deadline ASC";
            toDoListView.DataSource = dt;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            titleTextBox.Text = dt.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
            descriptionTextBox.Text = dt.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[2].ToString();
            dateTimePicker1.Value = (DateTime)dt.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[4];
            dateTimePicker2.Value = (DateTime)dt.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[4];
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
                   dt.Rows[toDoListView.CurrentCell.RowIndex]["Deadline"] = 
                    new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
                              dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0);


            }
            else
            {
                if (!string.IsNullOrWhiteSpace(titleTextBox.Text) && !string.IsNullOrWhiteSpace(descriptionTextBox.Text))
                {
                    dt.Rows.Add(false, titleTextBox.Text, descriptionTextBox.Text, DateTime.Now,
                    new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
                              dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0), false);
                    
                }
                else
                {
                    MessageBox.Show("Please enter both title and description.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
            toDoListView.Columns["Checked"].HeaderText = "";
            toDoListView.Columns["Checked"].Width = 30;
            dateTimePicker2.CustomFormat = "HH:mm";
            toDoListView.Columns["Priority"].HeaderText = "Mark";
            toDoListView.Columns["Priority"].Width = 50;
            
            // toDoListView.Columns["Day set"].DefaultCellStyle.Format = "dd/MM/yyyy";
            foreach (DataGridViewRow r in toDoListView.Rows)
            {
                bool isChecked = Convert.ToBoolean(r.Cells[0].Value);
                DateTime time = Convert.ToDateTime(r.Cells[4].Value);

                if (r.Cells[0].Value != null)
                {
                    if (isChecked == true)
                    {
                        r.DefaultCellStyle.BackColor = Color.Green;
                        r.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (DateTime.Now > time)
                    {
                        r.DefaultCellStyle.BackColor = Color.Red;
                        r.DefaultCellStyle.ForeColor = Color.White;
                    }

                    else 
                    {
                        r.DefaultCellStyle.BackColor = Color.White;
                        r.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }    
        }
    }
}
