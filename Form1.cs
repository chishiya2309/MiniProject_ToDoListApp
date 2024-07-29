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

        private void Form1_Load(object sender, EventArgs e)
        {
            toDoListView.Columns.Add("Title", "Title");
            toDoListView.Columns.Add("Description", "Description");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void newButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
            {
                toDoListView.Rows.Add(title, description);
                titleTextBox.Clear();
                descriptionTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter both title and description.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
