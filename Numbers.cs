using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firsttry
{
    class Numbers
    {
        public List<double> number;
        public int labels;

        public Numbers(List<double> number,int labels) {
            this.number = number;
            this.labels = labels;
        }

        public void Print() {
            Console.WriteLine("number:");
            foreach (double d in this.number) {
                Console.Write(d);
            }
            Console.WriteLine($"label: {this.labels}");
        }

    }
}
