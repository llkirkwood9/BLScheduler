using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TLC_Scheduler.Forms
{
    public partial class ScheduleCreator : Form
    {
        string selectedDay;
        Schedule s;
        Department dept;
        List<Student> students;
        string openedFilePath;
        bool fileOpened;
        LaunchMenu launch;

        public ScheduleCreator(Department d, LoadingScreen ls, LaunchMenu lm)
        {
            launch = lm;
            if (!Utils.studentsFileExists())
            {
                Utils.createStudentFile();
                MessageBox.Show("Student.txt did not exist and needed to be created!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dept = d;
            s = new Schedule(dept);
            ls.setProgress(15);
            students = Utils.getStudentAvailability(dept, ls);
            ls.setProgress(100);
            InitializeComponent();
            setMonday();
            startTime1Lbl.Text = dept.StartTime + "-9am";
            startTime2Lbl.Text = dept.StartTime + "-9am";
            fileLbl.Text = string.Empty;
            fileOpened = false;
            openedFilePath = string.Empty;
            hoursLbl.Text = "";
            hoursTodayLbl.Text = "";
            effectiveDatePicker.Value = DateTime.Today;
            ls.Close();
        }

        public ScheduleCreator(Schedule opened, string filePath, LoadingScreen ls, LaunchMenu lm)
        {
            launch = lm;
            if (!Utils.studentsFileExists())
            {
                Utils.createStudentFile();
                MessageBox.Show("Student.txt did not exist and needed to be created!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            s = opened;
            dept = s.Dept;

            ls.setProgress(15);
            students = Utils.getStudentAvailability(dept, ls);
            ls.setProgress(100);
            InitializeComponent();
            setMonday();
            if (s.Saved[0])
            {
                setMondaySaved();
            }
            startTime1Lbl.Text = dept.StartTime + "-9am";
            startTime2Lbl.Text = dept.StartTime + "-9am";
            fileLbl.Text = "Opened file: " + filePath + " on " + DateTime.Now.ToString();
            openedFilePath = filePath;
            fileOpened = true;
            titleTxtBox.Text = opened.Title;
            if (opened.EffectiveDate == string.Empty)
            {
                effectiveDatePicker.Value = DateTime.Today;
            }
            else
            {
                effectiveDatePicker.Value = DateTime.ParseExact(opened.EffectiveDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            if (opened.ShowCreateDate)
            {
                showCDateCheck.Checked = true;
            }
            if (opened.ShowEffectiveDate)
            {
                showEDateCheck.Checked = true;
            }
            updateHours();
            ls.Close();
        }

        public void addDefaults()
        {
            time11.Items.Add("None");
            time11.Items.Add("CLOSED");

            time12.Items.Add("None");
            time12.Items.Add("CLOSED");

            time21.Items.Add("None");
            time21.Items.Add("CLOSED");

            time22.Items.Add("None");
            time22.Items.Add("CLOSED");

            time31.Items.Add("None");
            time31.Items.Add("CLOSED");

            time32.Items.Add("None");
            time32.Items.Add("CLOSED");

            time41.Items.Add("None");
            time41.Items.Add("CLOSED");

            time42.Items.Add("None");
            time42.Items.Add("CLOSED");

            time51.Items.Add("None");
            time51.Items.Add("CLOSED");

            time52.Items.Add("None");
            time52.Items.Add("CLOSED");

            time61.Items.Add("None");
            time61.Items.Add("CLOSED");

            time62.Items.Add("None");
            time62.Items.Add("CLOSED");

            time71.Items.Add("None");
            time71.Items.Add("CLOSED");

            time72.Items.Add("None");
            time72.Items.Add("CLOSED");

            time81.Items.Add("None");
            time81.Items.Add("CLOSED");

            time82.Items.Add("None");
            time82.Items.Add("CLOSED");

            time91.Items.Add("None");
            time91.Items.Add("CLOSED");

            time92.Items.Add("None");
            time92.Items.Add("CLOSED");

            time101.Items.Add("None");
            time101.Items.Add("CLOSED");

            time102.Items.Add("None");
            time102.Items.Add("CLOSED");

            time111.Items.Add("None");
            time111.Items.Add("CLOSED");

            time112.Items.Add("None");
            time112.Items.Add("CLOSED");

            time121.Items.Add("None");
            time121.Items.Add("CLOSED");

            time122.Items.Add("None");
            time122.Items.Add("CLOSED");

            time131.Items.Add("None");
            time131.Items.Add("CLOSED");

            time132.Items.Add("None");
            time132.Items.Add("CLOSED");

            time141.Items.Add("None");
            time141.Items.Add("CLOSED");

            time142.Items.Add("None");
            time142.Items.Add("CLOSED");

            time151.Items.Add("None");
            time151.Items.Add("CLOSED");

            time152.Items.Add("None");
            time152.Items.Add("CLOSED");

            time161.Items.Add("None");
            time161.Items.Add("CLOSED");

            time162.Items.Add("None");
            time162.Items.Add("CLOSED");
        }

        public void clear()
        {
            time11.Items.Clear();

            time12.Items.Clear();

            time21.Items.Clear();

            time22.Items.Clear();

            time31.Items.Clear();

            time32.Items.Clear();

            time41.Items.Clear();

            time42.Items.Clear();

            time51.Items.Clear();

            time52.Items.Clear();

            time61.Items.Clear();

            time62.Items.Clear();

            time71.Items.Clear();

            time72.Items.Clear();

            time81.Items.Clear();

            time82.Items.Clear();

            time91.Items.Clear();

            time92.Items.Clear();

            time101.Items.Clear();

            time102.Items.Clear();

            time111.Items.Clear();

            time112.Items.Clear();

            time121.Items.Clear();

            time122.Items.Clear();

            time131.Items.Clear();

            time132.Items.Clear();

            time141.Items.Clear();

            time142.Items.Clear();

            time151.Items.Clear();

            time152.Items.Clear();

            time161.Items.Clear();

            time162.Items.Clear();
        }

        public void setMonday()
        {
            selectedDay = "Monday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Monday";

            time11.SelectedIndex = 0;
            time12.SelectedIndex = 0;
            time21.SelectedIndex = 0;
            time22.SelectedIndex = 0;
            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;
            time111.SelectedIndex = 0;
            time112.SelectedIndex = 0;
            time121.SelectedIndex = 0;
            time122.SelectedIndex = 0;
            time131.SelectedIndex = 0;
            time132.SelectedIndex = 0;
            time141.SelectedIndex = 0;
            time142.SelectedIndex = 0;

            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void setTuesday()
        {
            selectedDay = "Tuesday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Tuesday";

            time11.SelectedIndex = 0;
            time12.SelectedIndex = 0;
            time21.SelectedIndex = 0;
            time22.SelectedIndex = 0;
            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;
            time111.SelectedIndex = 0;
            time112.SelectedIndex = 0;
            time121.SelectedIndex = 0;
            time122.SelectedIndex = 0;
            time131.SelectedIndex = 0;
            time132.SelectedIndex = 0;
            time141.SelectedIndex = 0;
            time142.SelectedIndex = 0;

            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void setWednesday()
        {
            selectedDay = "Wednesday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Wednesday";

            time11.SelectedIndex = 0;
            time12.SelectedIndex = 0;
            time21.SelectedIndex = 0;
            time22.SelectedIndex = 0;
            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;
            time111.SelectedIndex = 0;
            time112.SelectedIndex = 0;
            time121.SelectedIndex = 0;
            time122.SelectedIndex = 0;
            time131.SelectedIndex = 0;
            time132.SelectedIndex = 0;
            time141.SelectedIndex = 0;
            time142.SelectedIndex = 0;

            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void setThursday()
        {
            selectedDay = "Thursday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Thursday";

            time11.SelectedIndex = 0;
            time12.SelectedIndex = 0;
            time21.SelectedIndex = 0;
            time22.SelectedIndex = 0;
            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;
            time111.SelectedIndex = 0;
            time112.SelectedIndex = 0;
            time121.SelectedIndex = 0;
            time122.SelectedIndex = 0;
            time131.SelectedIndex = 0;
            time132.SelectedIndex = 0;
            time141.SelectedIndex = 0;
            time142.SelectedIndex = 0;

            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void setFriday()
        {
            selectedDay = "Friday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Friday";

            time11.SelectedIndex = 0;
            time12.SelectedIndex = 0;
            time21.SelectedIndex = 0;
            time22.SelectedIndex = 0;
            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;
            time111.SelectedIndex = 0;
            time112.SelectedIndex = 0;

            time121.SelectedIndex = 1;
            time122.SelectedIndex = 1;
            time131.SelectedIndex = 1;
            time132.SelectedIndex = 1;
            time141.SelectedIndex = 1;
            time142.SelectedIndex = 1;
            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void setSaturday()
        {
            selectedDay = "Saturday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Saturday";

            time11.SelectedIndex = 1;
            time12.SelectedIndex = 1;
            time21.SelectedIndex = 1;
            time22.SelectedIndex = 1;

            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;

            time111.SelectedIndex = 1;
            time112.SelectedIndex = 1;
            time121.SelectedIndex = 1;
            time122.SelectedIndex = 1;
            time131.SelectedIndex = 1;
            time132.SelectedIndex = 1;
            time141.SelectedIndex = 1;
            time142.SelectedIndex = 1;
            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void setSunday()
        {
            selectedDay = "Sunday";
            clear();
            addDefaults();
            addStudentAvailability();
            dayLbl.Text = "Selected Day: Sunday";

            time11.SelectedIndex = 1;
            time12.SelectedIndex = 1;
            time21.SelectedIndex = 1;
            time22.SelectedIndex = 1;

            time31.SelectedIndex = 0;
            time32.SelectedIndex = 0;
            time41.SelectedIndex = 0;
            time42.SelectedIndex = 0;
            time51.SelectedIndex = 0;
            time52.SelectedIndex = 0;
            time61.SelectedIndex = 0;
            time62.SelectedIndex = 0;
            time71.SelectedIndex = 0;
            time72.SelectedIndex = 0;
            time81.SelectedIndex = 0;
            time82.SelectedIndex = 0;
            time91.SelectedIndex = 0;
            time92.SelectedIndex = 0;
            time101.SelectedIndex = 0;
            time102.SelectedIndex = 0;
            time111.SelectedIndex = 0;
            time112.SelectedIndex = 0;
            time121.SelectedIndex = 0;
            time122.SelectedIndex = 0;
            time131.SelectedIndex = 0;
            time132.SelectedIndex = 0;
            time141.SelectedIndex = 0;
            time142.SelectedIndex = 0;

            time151.SelectedIndex = 1;
            time152.SelectedIndex = 1;
            time161.SelectedIndex = 1;
            time162.SelectedIndex = 1;
        }

        public void saveDay()
        {
            updateHours();
            s.Title = titleTxtBox.Text;
            if (showCDateCheck.Checked)
            {
                s.ShowCreateDate = true;
            }
            else
            {
                s.ShowCreateDate = false;
            }
            if (showEDateCheck.Checked)
            {
                s.ShowEffectiveDate = true;
            }
            else
            {
                s.ShowEffectiveDate = false;
            }
            s.EffectiveDate = effectiveDatePicker.Value.ToString("MM/dd/yyyy");
            if (selectedDay == "Monday")
            {
                s.Saved[0] = true;
                s.Monday1[0] = time11.Text;
                s.Monday1[1] = time21.Text;
                s.Monday1[2] = time31.Text;
                s.Monday1[3] = time41.Text;
                s.Monday1[4] = time51.Text;
                s.Monday1[5] = time61.Text;
                s.Monday1[6] = time71.Text;
                s.Monday1[7] = time81.Text;
                s.Monday1[8] = time91.Text;
                s.Monday1[9] = time101.Text;
                s.Monday1[10] = time111.Text;
                s.Monday1[11] = time121.Text;
                s.Monday1[12] = time131.Text;
                s.Monday1[13] = time141.Text;
                s.Monday1[14] = time151.Text;
                s.Monday1[15] = time161.Text;

                s.Monday2[0] = time12.Text;
                s.Monday2[1] = time22.Text;
                s.Monday2[2] = time32.Text;
                s.Monday2[3] = time42.Text;
                s.Monday2[4] = time52.Text;
                s.Monday2[5] = time62.Text;
                s.Monday2[6] = time72.Text;
                s.Monday2[7] = time82.Text;
                s.Monday2[8] = time92.Text;
                s.Monday2[9] = time102.Text;
                s.Monday2[10] = time112.Text;
                s.Monday2[11] = time122.Text;
                s.Monday2[12] = time132.Text;
                s.Monday2[13] = time142.Text;
                s.Monday2[14] = time152.Text;
                s.Monday2[15] = time162.Text;
            }
            else if(selectedDay == "Tuesday")
            {
                s.Saved[1] = true;
                s.Tuesday1[0] = time11.Text;
                s.Tuesday1[1] = time21.Text;
                s.Tuesday1[2] = time31.Text;
                s.Tuesday1[3] = time41.Text;
                s.Tuesday1[4] = time51.Text;
                s.Tuesday1[5] = time61.Text;
                s.Tuesday1[6] = time71.Text;
                s.Tuesday1[7] = time81.Text;
                s.Tuesday1[8] = time91.Text;
                s.Tuesday1[9] = time101.Text;
                s.Tuesday1[10] = time111.Text;
                s.Tuesday1[11] = time121.Text;
                s.Tuesday1[12] = time131.Text;
                s.Tuesday1[13] = time141.Text;
                s.Tuesday1[14] = time151.Text;
                s.Tuesday1[15] = time161.Text;

                s.Tuesday2[0] = time12.Text;
                s.Tuesday2[1] = time22.Text;
                s.Tuesday2[2] = time32.Text;
                s.Tuesday2[3] = time42.Text;
                s.Tuesday2[4] = time52.Text;
                s.Tuesday2[5] = time62.Text;
                s.Tuesday2[6] = time72.Text;
                s.Tuesday2[7] = time82.Text;
                s.Tuesday2[8] = time92.Text;
                s.Tuesday2[9] = time102.Text;
                s.Tuesday2[10] = time112.Text;
                s.Tuesday2[11] = time122.Text;
                s.Tuesday2[12] = time132.Text;
                s.Tuesday2[13] = time142.Text;
                s.Tuesday2[14] = time152.Text;
                s.Tuesday2[15] = time162.Text;
            }
            else if (selectedDay == "Wednesday")
            {
                s.Saved[2] = true;
                s.Wednesday1[0] = time11.Text;
                s.Wednesday1[1] = time21.Text;
                s.Wednesday1[2] = time31.Text;
                s.Wednesday1[3] = time41.Text;
                s.Wednesday1[4] = time51.Text;
                s.Wednesday1[5] = time61.Text;
                s.Wednesday1[6] = time71.Text;
                s.Wednesday1[7] = time81.Text;
                s.Wednesday1[8] = time91.Text;
                s.Wednesday1[9] = time101.Text;
                s.Wednesday1[10] = time111.Text;
                s.Wednesday1[11] = time121.Text;
                s.Wednesday1[12] = time131.Text;
                s.Wednesday1[13] = time141.Text;
                s.Wednesday1[14] = time151.Text;
                s.Wednesday1[15] = time161.Text;

                s.Wednesday2[0] = time12.Text;
                s.Wednesday2[1] = time22.Text;
                s.Wednesday2[2] = time32.Text;
                s.Wednesday2[3] = time42.Text;
                s.Wednesday2[4] = time52.Text;
                s.Wednesday2[5] = time62.Text;
                s.Wednesday2[6] = time72.Text;
                s.Wednesday2[7] = time82.Text;
                s.Wednesday2[8] = time92.Text;
                s.Wednesday2[9] = time102.Text;
                s.Wednesday2[10] = time112.Text;
                s.Wednesday2[11] = time122.Text;
                s.Wednesday2[12] = time132.Text;
                s.Wednesday2[13] = time142.Text;
                s.Wednesday2[14] = time152.Text;
                s.Wednesday2[15] = time162.Text;
            }
            else if (selectedDay == "Thursday")
            {
                s.Saved[3] = true;
                s.Thursday1[0] = time11.Text;
                s.Thursday1[1] = time21.Text;
                s.Thursday1[2] = time31.Text;
                s.Thursday1[3] = time41.Text;
                s.Thursday1[4] = time51.Text;
                s.Thursday1[5] = time61.Text;
                s.Thursday1[6] = time71.Text;
                s.Thursday1[7] = time81.Text;
                s.Thursday1[8] = time91.Text;
                s.Thursday1[9] = time101.Text;
                s.Thursday1[10] = time111.Text;
                s.Thursday1[11] = time121.Text;
                s.Thursday1[12] = time131.Text;
                s.Thursday1[13] = time141.Text;
                s.Thursday1[14] = time151.Text;
                s.Thursday1[15] = time161.Text;

                s.Thursday2[0] = time12.Text;
                s.Thursday2[1] = time22.Text;
                s.Thursday2[2] = time32.Text;
                s.Thursday2[3] = time42.Text;
                s.Thursday2[4] = time52.Text;
                s.Thursday2[5] = time62.Text;
                s.Thursday2[6] = time72.Text;
                s.Thursday2[7] = time82.Text;
                s.Thursday2[8] = time92.Text;
                s.Thursday2[9] = time102.Text;
                s.Thursday2[10] = time112.Text;
                s.Thursday2[11] = time122.Text;
                s.Thursday2[12] = time132.Text;
                s.Thursday2[13] = time142.Text;
                s.Thursday2[14] = time152.Text;
                s.Thursday2[15] = time162.Text;
            }
            else if (selectedDay == "Friday")
            {
                s.Saved[4] = true;
                s.Friday1[0] = time11.Text;
                s.Friday1[1] = time21.Text;
                s.Friday1[2] = time31.Text;
                s.Friday1[3] = time41.Text;
                s.Friday1[4] = time51.Text;
                s.Friday1[5] = time61.Text;
                s.Friday1[6] = time71.Text;
                s.Friday1[7] = time81.Text;
                s.Friday1[8] = time91.Text;
                s.Friday1[9] = time101.Text;
                s.Friday1[10] = time111.Text;
                s.Friday1[11] = time121.Text;
                s.Friday1[12] = time131.Text;
                s.Friday1[13] = time141.Text;
                s.Friday1[14] = time151.Text;
                s.Friday1[15] = time161.Text;

                s.Friday2[0] = time12.Text;
                s.Friday2[1] = time22.Text;
                s.Friday2[2] = time32.Text;
                s.Friday2[3] = time42.Text;
                s.Friday2[4] = time52.Text;
                s.Friday2[5] = time62.Text;
                s.Friday2[6] = time72.Text;
                s.Friday2[7] = time82.Text;
                s.Friday2[8] = time92.Text;
                s.Friday2[9] = time102.Text;
                s.Friday2[10] = time112.Text;
                s.Friday2[11] = time122.Text;
                s.Friday2[12] = time132.Text;
                s.Friday2[13] = time142.Text;
                s.Friday2[14] = time152.Text;
                s.Friday2[15] = time162.Text;
            }
            else if (selectedDay == "Saturday")
            {
                s.Saved[5] = true;
                s.Saturday1[0] = time11.Text;
                s.Saturday1[1] = time21.Text;
                s.Saturday1[2] = time31.Text;
                s.Saturday1[3] = time41.Text;
                s.Saturday1[4] = time51.Text;
                s.Saturday1[5] = time61.Text;
                s.Saturday1[6] = time71.Text;
                s.Saturday1[7] = time81.Text;
                s.Saturday1[8] = time91.Text;
                s.Saturday1[9] = time101.Text;
                s.Saturday1[10] = time111.Text;
                s.Saturday1[11] = time121.Text;
                s.Saturday1[12] = time131.Text;
                s.Saturday1[13] = time141.Text;
                s.Saturday1[14] = time151.Text;
                s.Saturday1[15] = time161.Text;

                s.Saturday2[0] = time12.Text;
                s.Saturday2[1] = time22.Text;
                s.Saturday2[2] = time32.Text;
                s.Saturday2[3] = time42.Text;
                s.Saturday2[4] = time52.Text;
                s.Saturday2[5] = time62.Text;
                s.Saturday2[6] = time72.Text;
                s.Saturday2[7] = time82.Text;
                s.Saturday2[8] = time92.Text;
                s.Saturday2[9] = time102.Text;
                s.Saturday2[10] = time112.Text;
                s.Saturday2[11] = time122.Text;
                s.Saturday2[12] = time132.Text;
                s.Saturday2[13] = time142.Text;
                s.Saturday2[14] = time152.Text;
                s.Saturday2[15] = time162.Text;
            }
            else if (selectedDay == "Sunday")
            {
                s.Saved[6] = true;
                s.Sunday1[0] = time11.Text;
                s.Sunday1[1] = time21.Text;
                s.Sunday1[2] = time31.Text;
                s.Sunday1[3] = time41.Text;
                s.Sunday1[4] = time51.Text;
                s.Sunday1[5] = time61.Text;
                s.Sunday1[6] = time71.Text;
                s.Sunday1[7] = time81.Text;
                s.Sunday1[8] = time91.Text;
                s.Sunday1[9] = time101.Text;
                s.Sunday1[10] = time111.Text;
                s.Sunday1[11] = time121.Text;
                s.Sunday1[12] = time131.Text;
                s.Sunday1[13] = time141.Text;
                s.Sunday1[14] = time151.Text;
                s.Sunday1[15] = time161.Text;

                s.Sunday2[0] = time12.Text;
                s.Sunday2[1] = time22.Text;
                s.Sunday2[2] = time32.Text;
                s.Sunday2[3] = time42.Text;
                s.Sunday2[4] = time52.Text;
                s.Sunday2[5] = time62.Text;
                s.Sunday2[6] = time72.Text;
                s.Sunday2[7] = time82.Text;
                s.Sunday2[8] = time92.Text;
                s.Sunday2[9] = time102.Text;
                s.Sunday2[10] = time112.Text;
                s.Sunday2[11] = time122.Text;
                s.Sunday2[12] = time132.Text;
                s.Sunday2[13] = time142.Text;
                s.Sunday2[14] = time152.Text;
                s.Sunday2[15] = time162.Text;
            }
        }

        public void setMondaySaved()
        {
            time11.Text = s.Monday1[0];
            time12.Text = s.Monday2[0];
            time21.Text = s.Monday1[1];
            time22.Text = s.Monday2[1];
            time31.Text = s.Monday1[2];
            time32.Text = s.Monday2[2];
            time41.Text = s.Monday1[3];
            time42.Text = s.Monday2[3];
            time51.Text = s.Monday1[4];
            time52.Text = s.Monday2[4];
            time61.Text = s.Monday1[5];
            time62.Text = s.Monday2[5];
            time71.Text = s.Monday1[6];
            time72.Text = s.Monday2[6];
            time81.Text = s.Monday1[7];
            time82.Text = s.Monday2[7];
            time91.Text = s.Monday1[8];
            time92.Text = s.Monday2[8];
            time101.Text = s.Monday1[9];
            time102.Text = s.Monday2[9];
            time111.Text = s.Monday1[10];
            time112.Text = s.Monday2[10];
            time121.Text = s.Monday1[11];
            time122.Text = s.Monday2[11];
            time131.Text = s.Monday1[12];
            time132.Text = s.Monday2[12];
            time141.Text = s.Monday1[13];
            time142.Text = s.Monday2[13];
            time151.Text = s.Monday1[14];
            time152.Text = s.Monday2[14];
            time161.Text = s.Monday1[15];
            time162.Text = s.Monday2[15];
            
        }

        public void setTuesdaySaved()
        {
            time11.Text = s.Tuesday1[0];
            time12.Text = s.Tuesday2[0];
            time21.Text = s.Tuesday1[1];
            time22.Text = s.Tuesday2[1];
            time31.Text = s.Tuesday1[2];
            time32.Text = s.Tuesday2[2];
            time41.Text = s.Tuesday1[3];
            time42.Text = s.Tuesday2[3];
            time51.Text = s.Tuesday1[4];
            time52.Text = s.Tuesday2[4];
            time61.Text = s.Tuesday1[5];
            time62.Text = s.Tuesday2[5];
            time71.Text = s.Tuesday1[6];
            time72.Text = s.Tuesday2[6];
            time81.Text = s.Tuesday1[7];
            time82.Text = s.Tuesday2[7];
            time91.Text = s.Tuesday1[8];
            time92.Text = s.Tuesday2[8];
            time101.Text = s.Tuesday1[9];
            time102.Text = s.Tuesday2[9];
            time111.Text = s.Tuesday1[10];
            time112.Text = s.Tuesday2[10];
            time121.Text = s.Tuesday1[11];
            time122.Text = s.Tuesday2[11];
            time131.Text = s.Tuesday1[12];
            time132.Text = s.Tuesday2[12];
            time141.Text = s.Tuesday1[13];
            time142.Text = s.Tuesday2[13];
            time151.Text = s.Tuesday1[14];
            time152.Text = s.Tuesday2[14];
            time161.Text = s.Tuesday1[15];
            time162.Text = s.Tuesday2[15];

        }

        public void setWednesdaySaved()
        {
            time11.Text = s.Wednesday1[0];
            time12.Text = s.Wednesday2[0];
            time21.Text = s.Wednesday1[1];
            time22.Text = s.Wednesday2[1];
            time31.Text = s.Wednesday1[2];
            time32.Text = s.Wednesday2[2];
            time41.Text = s.Wednesday1[3];
            time42.Text = s.Wednesday2[3];
            time51.Text = s.Wednesday1[4];
            time52.Text = s.Wednesday2[4];
            time61.Text = s.Wednesday1[5];
            time62.Text = s.Wednesday2[5];
            time71.Text = s.Wednesday1[6];
            time72.Text = s.Wednesday2[6];
            time81.Text = s.Wednesday1[7];
            time82.Text = s.Wednesday2[7];
            time91.Text = s.Wednesday1[8];
            time92.Text = s.Wednesday2[8];
            time101.Text = s.Wednesday1[9];
            time102.Text = s.Wednesday2[9];
            time111.Text = s.Wednesday1[10];
            time112.Text = s.Wednesday2[10];
            time121.Text = s.Wednesday1[11];
            time122.Text = s.Wednesday2[11];
            time131.Text = s.Wednesday1[12];
            time132.Text = s.Wednesday2[12];
            time141.Text = s.Wednesday1[13];
            time142.Text = s.Wednesday2[13];
            time151.Text = s.Wednesday1[14];
            time152.Text = s.Wednesday2[14];
            time161.Text = s.Wednesday1[15];
            time162.Text = s.Wednesday2[15];

        }

        public void setThursdaySaved()
        {
            time11.Text = s.Thursday1[0];
            time12.Text = s.Thursday2[0];
            time21.Text = s.Thursday1[1];
            time22.Text = s.Thursday2[1];
            time31.Text = s.Thursday1[2];
            time32.Text = s.Thursday2[2];
            time41.Text = s.Thursday1[3];
            time42.Text = s.Thursday2[3];
            time51.Text = s.Thursday1[4];
            time52.Text = s.Thursday2[4];
            time61.Text = s.Thursday1[5];
            time62.Text = s.Thursday2[5];
            time71.Text = s.Thursday1[6];
            time72.Text = s.Thursday2[6];
            time81.Text = s.Thursday1[7];
            time82.Text = s.Thursday2[7];
            time91.Text = s.Thursday1[8];
            time92.Text = s.Thursday2[8];
            time101.Text = s.Thursday1[9];
            time102.Text = s.Thursday2[9];
            time111.Text = s.Thursday1[10];
            time112.Text = s.Thursday2[10];
            time121.Text = s.Thursday1[11];
            time122.Text = s.Thursday2[11];
            time131.Text = s.Thursday1[12];
            time132.Text = s.Thursday2[12];
            time141.Text = s.Thursday1[13];
            time142.Text = s.Thursday2[13];
            time151.Text = s.Thursday1[14];
            time152.Text = s.Thursday2[14];
            time161.Text = s.Thursday1[15];
            time162.Text = s.Thursday2[15];

        }

        public void setFridaySaved()
        {
            time11.Text = s.Friday1[0];
            time12.Text = s.Friday2[0];
            time21.Text = s.Friday1[1];
            time22.Text = s.Friday2[1];
            time31.Text = s.Friday1[2];
            time32.Text = s.Friday2[2];
            time41.Text = s.Friday1[3];
            time42.Text = s.Friday2[3];
            time51.Text = s.Friday1[4];
            time52.Text = s.Friday2[4];
            time61.Text = s.Friday1[5];
            time62.Text = s.Friday2[5];
            time71.Text = s.Friday1[6];
            time72.Text = s.Friday2[6];
            time81.Text = s.Friday1[7];
            time82.Text = s.Friday2[7];
            time91.Text = s.Friday1[8];
            time92.Text = s.Friday2[8];
            time101.Text = s.Friday1[9];
            time102.Text = s.Friday2[9];
            time111.Text = s.Friday1[10];
            time112.Text = s.Friday2[10];
            time121.Text = s.Friday1[11];
            time122.Text = s.Friday2[11];
            time131.Text = s.Friday1[12];
            time132.Text = s.Friday2[12];
            time141.Text = s.Friday1[13];
            time142.Text = s.Friday2[13];
            time151.Text = s.Friday1[14];
            time152.Text = s.Friday2[14];
            time161.Text = s.Friday1[15];
            time162.Text = s.Friday2[15];

        }

        public void setSaturdaySaved()
        {
            time11.Text = s.Saturday1[0];
            time12.Text = s.Saturday2[0];
            time21.Text = s.Saturday1[1];
            time22.Text = s.Saturday2[1];
            time31.Text = s.Saturday1[2];
            time32.Text = s.Saturday2[2];
            time41.Text = s.Saturday1[3];
            time42.Text = s.Saturday2[3];
            time51.Text = s.Saturday1[4];
            time52.Text = s.Saturday2[4];
            time61.Text = s.Saturday1[5];
            time62.Text = s.Saturday2[5];
            time71.Text = s.Saturday1[6];
            time72.Text = s.Saturday2[6];
            time81.Text = s.Saturday1[7];
            time82.Text = s.Saturday2[7];
            time91.Text = s.Saturday1[8];
            time92.Text = s.Saturday2[8];
            time101.Text = s.Saturday1[9];
            time102.Text = s.Saturday2[9];
            time111.Text = s.Saturday1[10];
            time112.Text = s.Saturday2[10];
            time121.Text = s.Saturday1[11];
            time122.Text = s.Saturday2[11];
            time131.Text = s.Saturday1[12];
            time132.Text = s.Saturday2[12];
            time141.Text = s.Saturday1[13];
            time142.Text = s.Saturday2[13];
            time151.Text = s.Saturday1[14];
            time152.Text = s.Saturday2[14];
            time161.Text = s.Saturday1[15];
            time162.Text = s.Saturday2[15];

        }

        public void setSundaySaved()
        {
            time11.Text = s.Sunday1[0];
            time12.Text = s.Sunday2[0];
            time21.Text = s.Sunday1[1];
            time22.Text = s.Sunday2[1];
            time31.Text = s.Sunday1[2];
            time32.Text = s.Sunday2[2];
            time41.Text = s.Sunday1[3];
            time42.Text = s.Sunday2[3];
            time51.Text = s.Sunday1[4];
            time52.Text = s.Sunday2[4];
            time61.Text = s.Sunday1[5];
            time62.Text = s.Sunday2[5];
            time71.Text = s.Sunday1[6];
            time72.Text = s.Sunday2[6];
            time81.Text = s.Sunday1[7];
            time82.Text = s.Sunday2[7];
            time91.Text = s.Sunday1[8];
            time92.Text = s.Sunday2[8];
            time101.Text = s.Sunday1[9];
            time102.Text = s.Sunday2[9];
            time111.Text = s.Sunday1[10];
            time112.Text = s.Sunday2[10];
            time121.Text = s.Sunday1[11];
            time122.Text = s.Sunday2[11];
            time131.Text = s.Sunday1[12];
            time132.Text = s.Sunday2[12];
            time141.Text = s.Sunday1[13];
            time142.Text = s.Sunday2[13];
            time151.Text = s.Sunday1[14];
            time152.Text = s.Sunday2[14];
            time161.Text = s.Sunday1[15];
            time162.Text = s.Sunday2[15];

        }

        private void monBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setMonday();
            if(s.Saved[0])
            {
                setMondaySaved();
            }
            updateHours();
        }

        private void tueBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setTuesday();
            if(s.Saved[1])
            {
                setTuesdaySaved();
            }
            updateHours();
        }

        private void wedBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setWednesday();
            if(s.Saved[2])
            {
                setWednesdaySaved();
            }
            updateHours();
        }

        private void thurBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setThursday();
            if(s.Saved[3])
            {
                setThursdaySaved();
            }
            updateHours();
        }

        private void friBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setFriday();
            if(s.Saved[4])
            {
                setFridaySaved();
            }
            updateHours();
        }

        private void satBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setSaturday();
            if(s.Saved[5])
            {
                setSaturdaySaved();
            }
            updateHours();
        }

        private void sunBtn_Click(object sender, EventArgs e)
        {
            saveDay();
            setSunday();
            if(s.Saved[6])
            {
                setSundaySaved();
            }
            updateHours();
        }

        private void addStudentAvailability()
        {
            int day = 0;

            if (selectedDay == "Monday")
            {
                day = 0;
            }

            if (selectedDay == "Tuesday")
            {
                day = 1;
            }

            if (selectedDay == "Wednesday")
            {
                day = 2;
            }

            if (selectedDay == "Thursday")
            {
                day = 3;
            }

            if (selectedDay == "Friday")
            {
                day = 4;
            }

            if (selectedDay == "Saturday")
            {
                day = 5;
            }

            if (selectedDay == "Sunday")
            {
                day = 6;
            }

            foreach (Student student in students)
            {
                if (student.Availability[day, 0])
                {
                    if (student.Preferred[day, 0] && !student.ClassAvail[day,0])
                    {
                        time11.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time12.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 0] && student.ClassAvail[day, 0])
                    {
                        time11.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time12.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 0] && student.ClassAvail[day, 0])
                    {
                        time11.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time12.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time11.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time12.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 1])
                {
                    if (student.Preferred[day, 1] && !student.ClassAvail[day, 1])
                    {
                        time21.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time22.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 1] && student.ClassAvail[day, 1])
                    {
                        time21.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time22.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 1] && student.ClassAvail[day, 1])
                    {
                        time21.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time22.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time21.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time22.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 2])
                {
                    if (student.Preferred[day, 2] && !student.ClassAvail[day, 2])
                    {
                        time31.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time32.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 2] && student.ClassAvail[day, 2])
                    {
                        time31.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time32.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 2] && student.ClassAvail[day, 2])
                    {
                        time31.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time32.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time31.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time32.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 3])
                {
                    if (student.Preferred[day, 3] && !student.ClassAvail[day, 3])
                    {
                        time41.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time42.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 3] && student.ClassAvail[day, 3])
                    {
                        time41.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time42.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 3] && student.ClassAvail[day, 3])
                    {
                        time41.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time42.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time41.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time42.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 4])
                {
                    if (student.Preferred[day, 4] && !student.ClassAvail[day, 4])
                    {
                        time51.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time52.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 4] && student.ClassAvail[day, 4])
                    {
                        time51.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time52.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 4] && student.ClassAvail[day, 4])
                    {
                        time51.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time52.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time51.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time52.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 5])
                {
                    if (student.Preferred[day, 5] && !student.ClassAvail[day, 5])
                    {
                        time61.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time62.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 5] && student.ClassAvail[day, 5])
                    {
                        time61.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time62.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 5] && student.ClassAvail[day, 5])
                    {
                        time61.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time62.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time61.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time62.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 6])
                {
                    if (student.Preferred[day, 6] && !student.ClassAvail[day, 6])
                    {
                        time71.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time72.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 6] && student.ClassAvail[day, 6])
                    {
                        time71.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time72.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 6] && student.ClassAvail[day, 6])
                    {
                        time71.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time72.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time71.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time72.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 7])
                {
                    if (student.Preferred[day, 7] && !student.ClassAvail[day, 7])
                    {
                        time81.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time82.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 7] && student.ClassAvail[day, 7])
                    {
                        time81.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time82.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 7] && student.ClassAvail[day, 7])
                    {
                        time81.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time82.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time81.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time82.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 8])
                {
                    if (student.Preferred[day, 8] && !student.ClassAvail[day, 8])
                    {
                        time91.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time92.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 8] && student.ClassAvail[day, 8])
                    {
                        time91.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time92.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 8] && student.ClassAvail[day, 8])
                    {
                        time91.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time92.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time91.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time92.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 9])
                {
                    if (student.Preferred[day, 9] && !student.ClassAvail[day, 9])
                    {
                        time101.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time102.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 9] && student.ClassAvail[day, 9])
                    {
                        time101.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time102.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 9] && student.ClassAvail[day, 9])
                    {
                        time101.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time102.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time101.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time102.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 10])
                {
                    if (student.Preferred[day, 10] && !student.ClassAvail[day, 10])
                    {
                        time111.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time112.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 10] && student.ClassAvail[day, 10])
                    {
                        time111.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time112.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 10] && student.ClassAvail[day, 10])
                    {
                        time111.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time112.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time111.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time112.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 11])
                {
                    if (student.Preferred[day, 11] && !student.ClassAvail[day, 11])
                    {
                        time121.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time122.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 11] && student.ClassAvail[day, 11])
                    {
                        time121.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time122.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 11] && student.ClassAvail[day, 11])
                    {
                        time121.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time122.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time121.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time122.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 12])
                {
                    if (student.Preferred[day, 12] && !student.ClassAvail[day, 12])
                    {
                        time131.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time132.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 12] && student.ClassAvail[day, 12])
                    {
                        time131.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time132.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 12] && student.ClassAvail[day, 12])
                    {
                        time131.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time132.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time131.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time132.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 13])
                {
                    if (student.Preferred[day, 13] && !student.ClassAvail[day, 13])
                    {
                        time141.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time142.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 13] && student.ClassAvail[day, 13])
                    {
                        time141.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time142.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 13] && student.ClassAvail[day, 13])
                    {
                        time141.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time142.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time141.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time142.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 14])
                {
                    if (student.Preferred[day, 14] && !student.ClassAvail[day, 14])
                    {
                        time151.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time152.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 14] && student.ClassAvail[day, 14])
                    {
                        time151.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time152.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 14] && student.ClassAvail[day, 14])
                    {
                        time151.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time152.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time151.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time152.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
                if (student.Availability[day, 15])
                {
                    if (student.Preferred[day, 15] && !student.ClassAvail[day, 15])
                    {
                        time161.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                        time162.Items.Add("**" + student.FirstName + " " + student.LastName[0] + ".**");
                    }
                    else if (!student.Preferred[day, 15] && student.ClassAvail[day, 15])
                    {
                        time161.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                        time162.Items.Add("*" + student.FirstName + " " + student.LastName[0] + ".*");
                    }
                    else if (student.Preferred[day, 15] && student.ClassAvail[day, 15])
                    {
                        time161.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                        time162.Items.Add("* **" + student.FirstName + " " + student.LastName[0] + ".** *");
                    }
                    else
                    {
                        time161.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                        time162.Items.Add(student.FirstName + " " + student.LastName[0] + ".");
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to create a new schedule?\nAny unsaved changes will be lost!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Schedule newSchedule = new Schedule(dept);
                s = newSchedule;
                fileLbl.Text = string.Empty;
                openedFilePath = string.Empty;
                fileOpened = false;
                titleTxtBox.Text = string.Empty;
                setMonday();
                MessageBox.Show("New schedule created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDay();
            updateHours();
            saveAs();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to open a new schedule?\nAny unsaved changes will be lost!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                openFile();
                updateHours();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (fileOpened)
                {
                    saveFileDialog.InitialDirectory = openedFilePath;
                }
                else
                {
                    saveFileDialog.InitialDirectory = "c:\\";
                }
                saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveDay();
                    for (int i = 0; i < s.Saved.Length; i++)
                    {
                        if (s.Saved[i] == false)
                        {
                           if (i == 0)
                           {
                                for (int j = 0; j < s.Monday1.Length; j++)
                                {
                                    if (j == 14 || j == 15)
                                    {
                                        s.Monday1[j] = "CLOSED";
                                        s.Monday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Monday1[j] = "None";
                                        s.Monday2[j] = "None";
                                    }
                                }
                           }
                            if (i == 1)
                            {
                                for (int j = 0; j < s.Tuesday1.Length; j++)
                                {
                                    if(j == 14 || j == 15)
                                    {
                                        s.Tuesday1[j] = "CLOSED";
                                        s.Tuesday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Tuesday1[j] = "None";
                                        s.Tuesday2[j] = "None";
                                    }
                                }
                            }
                            if (i == 2)
                            {
                                for (int j = 0; j < s.Wednesday1.Length; j++)
                                {
                                    if (j == 14 || j == 15)
                                    {
                                        s.Wednesday1[j] = "CLOSED";
                                        s.Wednesday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Wednesday1[j] = "None";
                                        s.Wednesday2[j] = "None";
                                    }
                                }
                            }
                            if (i == 3)
                            {
                                for (int j = 0; j < s.Thursday1.Length; j++)
                                {
                                    if (j == 14 || j == 15)
                                    {
                                        s.Thursday1[j] = "CLOSED";
                                        s.Thursday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Thursday1[j] = "None";
                                        s.Thursday2[j] = "None";
                                    }
                                }
                            }
                            if (i == 4)
                            {
                                for (int j = 0; j < s.Friday1.Length; j++)
                                {
                                    if (j == 11 || j == 12 || j == 13 || j == 14 || j == 15)
                                    {
                                        s.Friday1[j] = "CLOSED";
                                        s.Friday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Friday1[j] = "None";
                                        s.Friday2[j] = "None";
                                    }
                                }
                            }
                            if (i == 5)
                            {
                                for (int j = 0; j < s.Saturday1.Length; j++)
                                {
                                    if (j == 0 || j == 1 || j == 10 || j == 11 || j == 12 || j == 13 || j == 14 || j == 15)
                                    {
                                        s.Saturday1[j] = "CLOSED";
                                        s.Saturday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Saturday1[j] = "None";
                                        s.Saturday2[j] = "None";
                                    }
                                }
                            }
                            if (i == 6)
                            {
                                for (int j = 0; j < s.Sunday1.Length; j++)
                                {
                                    if (j == 0 || j == 1 ||  j == 14 || j == 15)
                                    {
                                        s.Sunday1[j] = "CLOSED";
                                        s.Sunday2[j] = "CLOSED";
                                    }
                                    else
                                    {
                                        s.Sunday1[j] = "None";
                                        s.Sunday2[j] = "None";
                                    }
                                }
                            }
                        }
                    }
                    //Get the path of specified file
                    LoadingScreen ls = new LoadingScreen("Exporting Schedule...");
                    ls.Show();
                    string filePath = saveFileDialog.FileName;
                    int code = Utils.exportSchedule(s, students, filePath, ls);
                    if (code == 0)
                    {
                        MessageBox.Show("File exported to: " + filePath, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDay();
            if (fileOpened)
            {
                saveFile();
            }
            else
            {
                saveAs();
            }
        }

        private void openFile()
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
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    IFormatter formatter = new BinaryFormatter();
                    try
                    {
                        System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        Schedule opened = (Schedule)formatter.Deserialize(stream);
                        stream.Close();
                        if (this.dept.Name == opened.Dept.Name)
                        {
                            s = opened;
                            setMonday();
                            if (s.Saved[0])
                            {
                                setMondaySaved();
                            }
                            fileLbl.Text = "Opened file: " + filePath + " on " + DateTime.Now.ToString();
                            MessageBox.Show("Schedule opened: " + filePath, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            openedFilePath = filePath;
                            fileOpened = true;
                            titleTxtBox.Text = s.Title;
                        }
                        else
                        {
                            MessageBox.Show("Error: schedule not in department: " + this.dept.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error: opening " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveAs()
        {
            saveDay();
            string filePath = "";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                if (fileOpened)
                {
                    saveFileDialog.InitialDirectory = openedFilePath;
                }
                else
                {
                    saveFileDialog.InitialDirectory = "c:\\";
                }
                saveFileDialog.Filter = "Schedule file (*.blsched)|*.blsched|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = saveFileDialog.FileName;

                    IFormatter formatter = new BinaryFormatter();

                    try
                    {
                        System.IO.Stream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                        formatter.Serialize(stream, s);
                        stream.Close();
                        MessageBox.Show("Schedule Saved to: " + filePath, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fileLbl.Text = "Saved to: " + filePath + " on " + DateTime.Now.ToString();
                        openedFilePath = filePath;
                        fileOpened = true;
                    }
                    catch
                    {
                        MessageBox.Show("Error: saving to " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
       
        private void saveFile()
        {
            IFormatter formatter = new BinaryFormatter();

            try
            {
                System.IO.Stream stream = new System.IO.FileStream(openedFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                formatter.Serialize(stream, s);
                stream.Close();
                MessageBox.Show("Schedule Saved to: " + openedFilePath, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileLbl.Text = "Saved to: " + openedFilePath + " on " + DateTime.Now.ToString();
            }
            catch
            {
                MessageBox.Show("Error: saving to " + openedFilePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateHours()
        {
            List<Student> students = Utils.getStudentsInDepartment(s.Dept);

            updateTodayHours();

            foreach (string i in s.Monday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Monday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Tuesday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Tuesday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Wednesday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Wednesday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Thursday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Thursday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Friday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Friday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Saturday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Saturday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Sunday1)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            foreach (string i in s.Sunday2)
            {
                foreach (Student student in students)
                {
                    string sName = student.FirstName + " " + student.LastName[0] + ".";
                    if (i.Contains(sName))
                    {
                        student.hours += 1;
                    }
                }
            }
            hoursLbl.Text = "";
            foreach (Student student in students)
            {
                hoursLbl.Text += "\n" + student.FirstName + " " + student.LastName + ": " + student.hours;
            }
        }

        private void updateTodayHours()
        {
            List<Student> students = Utils.getStudentsInDepartment(s.Dept);
            int[] hours = new int[students.Count];

            if (selectedDay == "Monday")
            {
                hoursForLbl.Text = "Hours for Monday:";
                foreach (string i in s.Monday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Monday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }
            if (selectedDay == "Tuesday")
            {
                hoursForLbl.Text = "Hours for Tuesday:";
                foreach (string i in s.Tuesday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Tuesday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }
            if (selectedDay == "Wednesday")
            {
                hoursForLbl.Text = "Hours for Wednesday:";
                foreach (string i in s.Wednesday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Wednesday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }
            if (selectedDay == "Thursday")
            {
                hoursForLbl.Text = "Hours for Thursday:";
                foreach (string i in s.Thursday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Thursday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }
            if (selectedDay == "Friday")
            {
                hoursForLbl.Text = "Hours for Friday:";
                foreach (string i in s.Friday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Friday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }
            if (selectedDay == "Saturday")
            {
                hoursForLbl.Text = "Hours for Saturday:";
                foreach (string i in s.Saturday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Saturday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }
            if (selectedDay == "Sunday")
            {
                hoursForLbl.Text = "Hours for Sunday:";
                foreach (string i in s.Sunday1)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
                foreach (string i in s.Sunday2)
                {
                    foreach (Student student in students)
                    {
                        string sName = student.FirstName + " " + student.LastName[0] + ".";
                        if (i.Contains(sName))
                        {
                            hours[students.IndexOf(student)] += 1;
                        }
                    }
                }
            }

            hoursTodayLbl.Text = "";
            foreach (Student student in students)
            {
                if (hours[students.IndexOf(student)] != 0)
                {
                    hoursTodayLbl.Text += "\n" + student.FirstName + " " + student.LastName + ": " + hours[students.IndexOf(student)];
                }
            }

        }

        private void time162_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveDay();
            updateHours();
        }

        private void ScheduleCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            launch.Show();
        }
    }
}
