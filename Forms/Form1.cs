using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLC_Scheduler
{
    public partial class Form1 : Form
    {
        private List<Department> departments;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
            departments = Utils.getDepartments();
            if (departments != null)
            {
                foreach (Department dept in departments)
                {
                    dptCombo.Items.Add(dept.Name);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Error reading Departments.txt\nThe file may not exist or be corrupted.\nWould you like to re-create the files?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Utils.resetFiles();
                    MessageBox.Show("Departments.txt and Students.txt have been re-created.\nYou can now make a new department to get started!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The application cannot start until Departments.txt can be successfully read.\nNow closing the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Load += MyForm_CloseOnStart;
                }
            }

            if (dptCombo.Items.Count > 0)
            {
                dptCombo.SelectedIndex = 0;
            }
        }

        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createDpt_Click(object sender, EventArgs e)
        {
            CreateDepartment newDept = new CreateDepartment();
            newDept.ShowDialog();
            departments = new List<Department>();
            dptCombo.Items.Clear();

            departments = Utils.getDepartments();
            if (departments != null)
            {
                foreach (Department dept in departments)
                {
                    dptCombo.Items.Add(dept.Name);
                }
            }

            if (dptCombo.Items.Count != 0)
            {
                dptCombo.SelectedIndex = 0;
            }
        }

        private void launchBtn_Click(object sender, EventArgs e)
        {
           String name = (String)dptCombo.SelectedItem;
            Department selected = null;
            bool isValid = false;
            foreach (Department dept in departments)
            {
                if (name == dept.Name)
                {
                    isValid = true;
                    selected = dept;
                    break;
                }
            }
            Console.WriteLine(name);
            Console.WriteLine(isValid);
            if (!isValid)
            {
                MessageBox.Show("Error: Invalid Department Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LaunchMenu menu = new LaunchMenu(selected);
                menu.Show();
                this.Hide();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            departments = new List<Department>();
            dptCombo.Items.Clear();
            
            departments = Utils.getDepartments();
            if (departments != null)
            {
                foreach (Department dept in departments)
                {
                    dptCombo.Items.Add(dept.Name);
                }
                MessageBox.Show("Departments Refreshed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error reading Departments.txt\nDoes the file exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dptCombo.Items.Count != 0)
            {
                dptCombo.SelectedIndex = 0;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void creditsBtn_Click(object sender, EventArgs e)
        {
            Forms.Credits credits = new Forms.Credits();
            credits.ShowDialog();
        }
    }
}
