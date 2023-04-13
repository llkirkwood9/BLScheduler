using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLC_Scheduler.Forms;

namespace TLC_Scheduler
{
    public partial class LaunchMenu : Form
    {
        private Department dept;

        public LaunchMenu(Department dept)
        {
            this.dept = dept;
            InitializeComponent();
            titleLbl.Text = dept.Name + " Menu";
            this.Text = dept.Name + " Menu";
        }

        private void editStudentsBtn_Click(object sender, EventArgs e)
        {
            ViewStudents view = new ViewStudents(dept);
            view.ShowDialog();
        }

        private void addStudentsBtn_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent(dept);
            add.ShowDialog();
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are about to launch the Schedule Creator\nThis may take a few minutes to load!\nContinue?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                LoadingScreen load = new LoadingScreen("Creating a new schedule...");
                load.Show();
                Forms.ScheduleCreator sc = new Forms.ScheduleCreator(dept, load, this);
                sc.Show();
                this.Hide();
            }
            
        }

        private void openSchedule_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Schedule file (*.blsched)|*.blsched|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    DialogResult result = MessageBox.Show("You are about to launch the Schedule Creator\nThis may take a few minutes to load!\nContinue?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        IFormatter formatter = new BinaryFormatter();
                        LoadingScreen load = new LoadingScreen("Opening schedule...");
                        try
                        {
                            System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            Schedule opened = (Schedule)formatter.Deserialize(stream);
                            stream.Close();
                            if (this.dept.Name == opened.Dept.Name)
                            {
                                load.Show();
                                ScheduleCreator sched = new ScheduleCreator(opened, filePath, load, this);
                                sched.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Error: schedule not in department: " + this.dept.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error: opening " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            load.Close();
                        }
                    }
                    
                }
            }
        }

        private void LaunchMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void editDeptBtn_Click(object sender, EventArgs e)
        {
            EditDepartment edit = new EditDepartment(dept);
            edit.ShowDialog();
        }

        private void delDeptBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are about to delete this department!\nAll department information and students will be deleted!\n\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Utils.deleteDepartment(dept);
                MessageBox.Show("Department successfully deleted!\nApplication will now close!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
