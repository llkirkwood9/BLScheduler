﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace TLC_Scheduler
{
    public partial class AddStudent : Form
    {
        private Department dept;
        private Student s;
        public AddStudent(Department d)
        {
            if (!Utils.studentsFileExists()) {
                Utils.createStudentFile();
                MessageBox.Show("Student.txt did not exist and needed to be created!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.dept = d;
            s = new Student("", "", "", "", dept.Name, "Black");
            InitializeComponent();
            deptLbl.Text = "Department: " + dept.Name;
        }

        private void fileSelectBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    s.SchedulePath = filePath;
                    pathLbl.Text = filePath;
                }
            }
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            string firstName = firstNameBox.Text;
            string lastName = lastNameBox.Text;
            string email = emailBox.Text;
            bool validFirst = Regex.IsMatch(firstName, "[A-Z]");
            bool validLast = Regex.IsMatch(lastName, "[A-Z]");
            bool validEmail = Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (validFirst)
            {
                if (validLast)
                {
                    if (validEmail)
                    {
                        if (s.SchedulePath != "")
                        {
                            s.FirstName = firstName;
                            s.LastName = lastName;
                            s.Email = email;
                            int code = Utils.addStudent(s);
                            if (code == 0)
                            {
                                MessageBox.Show("Student successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            if (code == -2)
                            {
                                MessageBox.Show("Error writing to Students.txt\nDoes the file exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a schedule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid email name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid last name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid first name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = false;
            colorPicker.Color = Color.Black;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                currentColorLbl.ForeColor = colorPicker.Color;
                s.Color = ColorTranslator.ToHtml(colorPicker.Color);
                Console.WriteLine("Color: " + colorPicker.Color.Name);
            }

        }
    }
}
