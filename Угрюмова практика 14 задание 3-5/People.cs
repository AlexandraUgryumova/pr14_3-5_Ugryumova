using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Угрюмова_практика_14_задание_3_5
{
    class People
    {
        string sername;
        string name;
        string middlename;
        int age;
        double weight;
        public People(string sername, string name, string middlename, int age, double weight)
        {
            this.sername = sername;
            this.name = name;
            this.middlename = middlename;
            this.age = age;
            this.weight = weight;
        }
        public string Sername { get => sername; set => sername = value; }
        public string Name { get => name; set => name = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public int Age { get => age; set => age = value; }
        public double Weight { get => weight; set => weight = value; }
        public string Info()
        {
            return $"{sername} {name} {middlename} {age} {weight}";
        }

    }
}
