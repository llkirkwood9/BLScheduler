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

namespace TLC_Scheduler
{
    public partial class CreateDepartment : Form
    {
        public CreateDepartment()
        {
            InitializeComponent();
        }

        private void createDeptBtn_Click(object sender, EventArgs e)
        {
            int code = 1;

            string name = nameBox.Text;

            bool validName = Regex.IsMatch(name, "[A-Z]");

            Department newDept = null;

            if (validName)
            {
                if (startTime1.Checked)
                {
                    newDept = new Department(name, "7:30am");
                }
                else if (startTime2.Checked)
                {
                    newDept = new Department(name, "8:00am");
                }

                code = Utils.addDepartment(newDept);

                if (code == 0)
                {
                    MessageBox.Show("Department successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
