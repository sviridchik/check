using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

namespace firsttry
{
    struct PL
    {
        public string name;
        public int label;


        public PL(string name, int label)
        {
            this.name = name;
            this.label = label;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //string[] args1 = @"MNIST - JPG - training";
            void Initial(string path) {

                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }

            }
           

            List<PL> paths = new List<PL>();
            List<Numbers> data = new List<Numbers>();
            int lab = 0;
            void ProcessFile(string path)
            {
                //Console.WriteLine("Processed file '{0}'.", path);
              //Console.WriteLine(path.Split('\\')[1]);

                lab = Convert.ToInt32(path.Split('\\')[1]);



                paths.Add(new PL(path,lab));
            }

             void ProcessDirectory(string targetDirectory)
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    ProcessFile(fileName);

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory);
            }


            Initial(@"MNIST - JPG - training");


            // string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MNIST - JPG - training\0\1.jpg";

            // string path1 = @"MNIST - JPG - training\0\1.jpg";
           // int count = 0;
            foreach (PL path in paths) {
                string path1 = path.name; 
                List<double> numbersForOne = new List<double>();
              // Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                
                

                Bitmap image = new Bitmap(path1);
                //         Console.WriteLine(image.PhysicalDimension);
                for (int x = 0; x < image.Height; x++)
                {
                    for (int y = 0; y < image.Width; y++)
                    {
                        Color clr = image.GetPixel(x, y);
                        //Console.WriteLine(clr.R);
                        double p = clr.R / (255.0);
                      //  Console.WriteLine($" {p}   |    ");
                        //Console.Write("  ");
                        numbersForOne.Add(p);
                    }
                    //image.Save()
                }
                
                data.Add(new Numbers(numbersForOne,path.label));
            }

            string pathToStore = @"data";

            using (StreamWriter sw = new StreamWriter(pathToStore))
            {
                foreach (var n in data) {

                    string str = JsonConvert.SerializeObject(n);
                    //Console.WriteLine(str);
                    sw.WriteLine(str);
                } 
            }
            Console.WriteLine("Done");
            List<Numbers> dataFromStorage = new List<Numbers>();
            using (StreamReader sr = new StreamReader(pathToStore, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Numbers tmp = JsonConvert.DeserializeObject<Numbers>(line);
                    dataFromStorage.Add(tmp);
                    //Console.WriteLine(line);
                }
            }

            foreach (var n in dataFromStorage)
            {

                Console.WriteLine(n.labels);
                
            }

            Console.ReadLine();
        }
    }
}
