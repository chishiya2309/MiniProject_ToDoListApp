﻿namespace To_Do_List_App
{
    partial class ToDoList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.toDoListView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(922, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "To Do List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(9, 66);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(922, 20);
            this.titleTextBox.TabIndex = 1;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(9, 115);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(922, 20);
            this.descriptionTextBox.TabIndex = 2;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(779, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(779, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Title:";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(9, 141);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(225, 23);
            this.newButton.TabIndex = 5;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(706, 141);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(225, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(475, 141);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(225, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(244, 141);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(225, 23);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // toDoListView
            // 
            this.toDoListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.toDoListView.BackgroundColor = System.Drawing.Color.White;
            this.toDoListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDoListView.Location = new System.Drawing.Point(9, 170);
            this.toDoListView.Name = "toDoListView";
            this.toDoListView.Size = new System.Drawing.Size(922, 268);
            this.toDoListView.TabIndex = 9;
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(943, 450);
            this.Controls.Add(this.toDoListView);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ToDoList";
            this.Text = "To Do List";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toDoListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.DataGridView toDoListView;
    }
}

