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
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        public LoadingScreen(string title)
        {
            InitializeComponent();
            label1.Text = title;
        }

        public void setProgress(int percentage)
        {
            if (percentage > 100)
            {
                progressBar.Value = 100;
            }
            else
            {
                progressBar.Value = percentage;
            }
        }

        public int getProgress()
        {
            return progressBar.Value;
        }

        public void setLbl(string label)
        {
            infoLbl.Text = "Loading: " + label;
        }
    }
}
