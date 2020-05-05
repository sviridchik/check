using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace firsttry
{
    class Neyro
    {
        public List<Matrica<double>> vesa;
        public Matrica<double> output;
        public Matrica<double> bios;
        int inputSize;
        public Random r;
        public Matrica<double> Predict(Matrica<double> input)
        {
            return (input *= output)+bios; 
        }
        public Matrica<double> Softmax(Matrica<double> input)
        {
            double denominator = 0;
            Matrica<double> res = new Matrica<double>(input.Rows, input.Cells);

            for (int i = 0; i < input.Rows; i++)
            {
                for (int j = 0; j < input.Cells; j++)
                {
                   
                        dynamic a = input[i, j];
                   denominator += Math.Exp(a);
                    
                }
            }

            for (int i = 0; i < input.Rows; i++)
            {
                for (int j = 0; j < input.Cells; j++)
                {

                    dynamic a = input[i, j];
                    input[i, j] = Math.Exp(a)/denominator;

                }
            }

            return input;
        }
    }
}
