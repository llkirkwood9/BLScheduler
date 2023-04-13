using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLC_Scheduler.Forms
{
    [Serializable]
    public class Schedule
    {
        private Department dept;

        private String[] monday1 = new String[16];
        private String[] monday2 = new String[16];

        private String[] tuesday1 = new String[16];
        private String[] tuesday2 = new String[16];

        private String[] wednesday1 = new String[16];
        private String[] wednesday2 = new String[16];

        private String[] thursday1 = new String[16];
        private String[] thursday2 = new String[16];

        private String[] friday1 = new String[16];
        private String[] friday2 = new String[16];

        private String[] saturday1 = new String[16];
        private String[] saturday2 = new String[16];

        private String[] sunday1 = new String[16];
        private String[] sunday2 = new String[16];

        private bool[] saved = new bool[7];

        private string title;

        private string effectiveDate;
        private bool showEffectiveDate;
        private bool showCreateDate;

        public Schedule(Department d)
        {
            this.Dept = d;
            for(int i = 0; i < 16; i++)
            {
                monday1[i] = "";
                monday2[i] = "";

                tuesday1[i] = "";
                tuesday2[i] = "";

                wednesday1[i] = "";
                wednesday2[i] = "";

                thursday1[i] = "";
                thursday2[i] = "";

                friday1[i] = "";
                friday2[i] = "";

                saturday1[i] = "";
                saturday2[i] = "";

                sunday1[i] = "";
                sunday2[i] = "";
            }
        }

        public String[] Monday1 { get => monday1; set => monday1 = value; }
        public String[] Monday2 { get => monday2; set => monday2 = value; }
        public String[] Tuesday1 { get => tuesday1; set => tuesday1 = value; }
        public String[] Tuesday2 { get => tuesday2; set => tuesday2 = value; }
        public String[] Wednesday1 { get => wednesday1; set => wednesday1 = value; }
        public String[] Wednesday2 { get => wednesday2; set => wednesday2 = value; }
        public String[] Thursday1 { get => thursday1; set => thursday1 = value; }
        public String[] Thursday2 { get => thursday2; set => thursday2 = value; }
        public String[] Friday1 { get => friday1; set => friday1 = value; }
        public String[] Friday2 { get => friday2; set => friday2 = value; }
        public String[] Saturday1 { get => saturday1; set => saturday1 = value; }
        public String[] Saturday2 { get => saturday2; set => saturday2 = value; }
        public String[] Sunday1 { get => sunday1; set => sunday1 = value; }
        public String[] Sunday2 { get => sunday2; set => sunday2 = value; }
        public Department Dept { get => dept; set => dept = value; }
        public bool[] Saved { get => saved; set => saved = value; }
        public string Title { get => title; set => title = value; }
        public string EffectiveDate { get => effectiveDate; set => effectiveDate = value; }
        public bool ShowEffectiveDate { get => showEffectiveDate; set => showEffectiveDate = value; }
        public bool ShowCreateDate { get => showCreateDate; set => showCreateDate = value; }
    }
}
