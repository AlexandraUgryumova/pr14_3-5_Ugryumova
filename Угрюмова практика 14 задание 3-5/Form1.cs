using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

namespace Угрюмова_практика_14_задание_3_5
{
    public partial class Form1 : Form
    {
        List<People> people = new List<People>();
        Stack<int> stack = new Stack<int>();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("Depart.txt"))
            {
                string[] peoples = File.ReadAllLines("Depart.txt");
                foreach (string i in peoples)
                {
                    string[] infoPerson = i.Split(' ');
                    people.Add(new People(infoPerson[0], infoPerson[1], infoPerson[2], int.Parse(infoPerson[3]), double.Parse(infoPerson[4])));
                }
                foreach (People i in people)
                {
                    listBox1.Items.Add(i.Info());
                }
                foreach (People i in people)
                {
                    listBox3.Items.Add(i.Info());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var ages = from i in people
                       where i.Age < 40
                       select i;
            foreach (People i in ages)
            {
                listBox1.Items.Add(i.Info());
            }
        }
        static int check(string str)
        {
            if (!int.TryParse(str, out int number))
            {
                MessageBox.Show("Не число");
            }
            else if (number <= 0)
                MessageBox.Show("Число меньше 0");
            return number;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            var sortedPeople = people.OrderBy(p => p.Age);
            foreach(People i in sortedPeople)
            {
                listBox3.Items.Add(i.Info());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int N = check(textBox1.Text);
            for(int i = 1; i <= N; i++)
            {
                stack.Push(i);
                listBox2.Items.Add(i);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (stack.Count == 0) MessageBox.Show("коллекция пуста", "сообщение");
            else
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int N = stack.Count();
            int i = N - 1;
            if (i < 0) timer1.Stop();
            else
            {
                listBox2.Items.RemoveAt(i);
                stack.Pop();
            }
            i--;
        }
    }
}
