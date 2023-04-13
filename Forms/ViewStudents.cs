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
    public partial class ViewStudents : Form
    {
        private Department dept;
        private List<Student> students;
        public ViewStudents(Department dept)
        {
            if (!Utils.studentsFileExists())
            {
                Utils.createStudentFile();
                MessageBox.Show("Student.txt did not exist and needed to be created!\nDue to this, no students will appear in the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.dept = dept;
            students = Utils.getStudentsInDepartment(dept);
            InitializeComponent();
            deptLbl.Text = dept.Name + " Students";

            if (students != null)
            {
                foreach (Student student in students)
                {
                    studentList.Items.Add(student.FirstName + " " + student.LastName);
                }
            }
            else
            {
                MessageBox.Show("Error reading Departments.txt\nDoes the file exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Student s = Utils.getStudentByNameAndDepartment((string)studentList.SelectedItem, dept);
            if (s != null)
            {
                Forms.EditStudent edit = new Forms.EditStudent(s);
                edit.ShowDialog();
                refreshAll();
            }
            else
            {
                MessageBox.Show("Error: Could not find student or no student selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshAll()
        {
            studentList.Items.Clear();
            students = Utils.getStudentsInDepartment(dept);
            if (students != null)
            {
                foreach (Student student in students)
                {
                    studentList.Items.Add(student.FirstName + " " + student.LastName);
                }
            }
            else
            {
                MessageBox.Show("Error reading Departments.txt\nDoes the file exist?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
