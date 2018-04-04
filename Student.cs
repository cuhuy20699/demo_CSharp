using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormQL_SinhVien
{
    class Student
    {
        private string name;
        private string rollnumber;

        public Student()
        {
            
        }

        public Student(string name, string rollnumber)
        {
            this.name = name;
            this.rollnumber = rollnumber;
        }

        public string Name { get => name; set => name = value; }
        public string Rollnumber { get => rollnumber; set => rollnumber = value; }
    }
}
