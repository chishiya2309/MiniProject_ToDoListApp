using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    
    public partial class ToDoList : Form
    {
        private ToDoListManager _toDoListManager;
        private bool _isEditing = false;

        public ToDoList()
        {
            InitializeComponent();
            _toDoListManager = new ToDoListManager(dt);
        }

        DataTable dt = new DataTable();
        // bool isEditing = false;
        

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
            _isEditing = true;
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
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
            if (_isEditing)
            {
                // dt.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                // dt.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;
                // dt.Rows[toDoListView.CurrentCell.RowIndex]["Deadline"] = 
                //new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
                //        dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0);

                var item = new ToDoItem
                {
                    Title = titleTextBox.Text,
                    Description = descriptionTextBox.Text,
                    Deadline = new DateTime(
                    dateTimePicker1.Value.Year,
                    dateTimePicker1.Value.Month,
                    dateTimePicker1.Value.Day,
                    dateTimePicker2.Value.Hour,
                    dateTimePicker2.Value.Minute,
                    0)
                };
                _toDoListManager.UpdateItem(toDoListView.CurrentCell.RowIndex, item);

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(titleTextBox.Text) && !string.IsNullOrWhiteSpace(descriptionTextBox.Text))
                {
                    // dt.Rows.Add(false, titleTextBox.Text, descriptionTextBox.Text, DateTime.Now,
                    // new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day,
                    //        dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0), false);

                    var item = new ToDoItem
                    {
                        IsCompleted = false,
                        Title = titleTextBox.Text,
                        Description = descriptionTextBox.Text,
                        Dayset = DateTime.Now,
                        Deadline = new DateTime(
                        dateTimePicker1.Value.Year,
                        dateTimePicker1.Value.Month,
                        dateTimePicker1.Value.Day,
                        dateTimePicker2.Value.Hour,
                        dateTimePicker2.Value.Minute,
                        0),
                        IsMark = false

                    };
                    _toDoListManager.AddItem(item);

                }
                else
                {
                    MessageBox.Show("Please enter both title and description.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            _isEditing = false;
        }

        private void toDoListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void toDoListView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            toDoListView.Columns["Checked"].HeaderText = "Done";
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

        // OOP Concept
        public class ToDoItem
        {
            public bool IsCompleted { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Dayset { get; set; }
            public DateTime Deadline { get; set; }
            public bool IsMark { get; set; }
        }

        public class ToDoListManager
        {
            private DataTable _dataTable;

            public ToDoListManager(DataTable dataTable)
            {
                _dataTable = dataTable;
            }

            public void AddItem(ToDoItem item)
            {
                _dataTable.Rows.Add(item.IsCompleted, item.Title, item.Description, item.Dayset, item.Deadline, item.IsMark);
            }

            public void UpdateItem(int rowIndex, ToDoItem item)
            {
                _dataTable.Rows[rowIndex]["Title"] = item.Title;
                _dataTable.Rows[rowIndex]["Description"] = item.Description;
                _dataTable.Rows[rowIndex]["Deadline"] = item.Deadline;
            }
        }


    }
}
