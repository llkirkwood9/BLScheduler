using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLC_Scheduler.Forms
{
    public partial class EditDepartment : Form
    {
        private Department orig;
        private Department edit;
        public EditDepartment(Department toEdit)
        {
            this.edit = toEdit;
            orig = new Department(edit.Name, edit.StartTime);
            InitializeComponent();

            nameBox.Text = edit.Name;
            if (edit.StartTime == "7:30am")
            {
                startTime1.Checked = true;
            }
            else
            {
                startTime2.Checked = true;
            }
        }

        private void createDeptBtn_Click(object sender, EventArgs e)
        {
            int code = 1;

            string name = nameBox.Text;

            bool validName = System.Text.RegularExpressions.Regex.IsMatch(name, "[A-Z]");

            if (validName)
            {
                edit.Name = nameBox.Text;
                if (startTime1.Checked)
                {
                    edit.StartTime = "7:30am";
                }
                else if (startTime2.Checked)
                {
                    edit.StartTime = "8:00am";
                }

                code = Utils.editDepartment(edit, orig);

                if (code == 0)
                {
                    MessageBox.Show("Department successfully edited!\nIf you changed the name of the department, please restart the application!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (code == -1)
                {
                    MessageBox.Show("Error: Department with that name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (code == -2)
                {
                    MessageBox.Show("Error writing to Departments.txt\nDoes the file exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Unknown Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Department name must contain a letter!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
