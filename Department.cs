using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLC_Scheduler
{
    [Serializable]
    public class Department
    {
        private string name;
        private string startTime;

        public Department(string name, string startTime)
        {
            this.name = name;
            this.startTime = startTime;
        }

        public string Name { get => name; set => name = value; }
        public string StartTime { get => startTime; set => startTime = value; }
                
    }
}
