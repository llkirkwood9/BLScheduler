using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace TLC_Scheduler.Forms
{
    public partial class EditStudent : Form
    {
        private Student orig;
        private Student edit;
        public EditStudent(Student toEdit)
        {
            this.edit = toEdit;
            orig = new Student(edit.FirstName, edit.LastName, edit.Email, edit.SchedulePath, edit.DeptName, edit.Color);
            InitializeComponent();
            firstNameBox.Text = edit.FirstName;
            lastNameBox.Text = edit.LastName;
            emailBox.Text = edit.Email;
            pathLbl.Text = edit.SchedulePath;
            Color color = System.Drawing.ColorTranslator.FromHtml(edit.Color);
            currentColorLbl.ForeColor = color;
            deptLbl.Text = "Department: " + edit.DeptName;
        }

        private void fileSelectBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    pathLbl.Text = filePath;
                    edit.SchedulePath = filePath;
                }
            }
        }

        private void editStudentBtn_Click(object sender, EventArgs e)
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
                        if (edit.SchedulePath != "")
                        {
                            edit.FirstName = firstName;
                            edit.LastName = lastName;
                            edit.Email = email;
                            int code = Utils.editStudent(edit, orig);
                            if (code == 0)
                            {
                                MessageBox.Show("Student successfully edited!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void delStudentBtn_Click(object sender, EventArgs e)
        {
            int code = Utils.deleteStudent(orig);
            if (code == 0)
            {
                MessageBox.Show("Student successfully deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            if (code == -2)
            {
                MessageBox.Show("Error writing to Students.txt\nDoes the file exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                edit.Color = ColorTranslator.ToHtml(colorPicker.Color);
                Console.WriteLine("Color: " + edit.Color);
            }

        }
    }
}
