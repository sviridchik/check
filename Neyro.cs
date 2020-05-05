using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace firsttry
{
    class Neyro
    {
       // public List<Matrica<double>> vesa;
        public Matrica<double> output;
        public Matrica<double> bias;
        int inputSize;
        public Random r;



        public Neyro() {
            for (int i = 0; i < 724; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    output[i, j] = r.Next(-1, 1);
                   // Console.Write("{0}\t", output[i, j]);
                }
                //Console.WriteLine();
            }


            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    bias[i, j] = r.Next(-1, 1);
                    // Console.Write("{0}\t", output[i, j]);
                }
                //Console.WriteLine();
            }
        }
        public Matrica<double> Predict(Matrica<double> input)
        {
            return Softmax(input *= output)+bias); 
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
