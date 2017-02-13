using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace TuringMachine
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please Press any key and Select a Valid Text File");
                Console.ReadKey();
                Console.WriteLine();
                string filepath = "";
                string[] TMfile;
                OpenFileDialog FileExplorer = new OpenFileDialog();
                FileExplorer.Filter = "Text files (*.txt)|*.txt|All files (*.*) | *.*";
                FileExplorer.FilterIndex = 2;

                TmValidator Validator = new TmValidator();
                TuringMachine TM = new TuringMachine();

                try
                {
                    if (FileExplorer.ShowDialog() == DialogResult.OK) //File Selector
                    {
                            filepath = FileExplorer.FileName;
                            TMfile = File.ReadAllLines(filepath);

                         

                        TMfile = Validator.TmParser(TMfile).ToArray(); //File Parsing
                        Console.Write("Please Enter an input word - ");
                        TM = Validator.TMBuilder(TMfile); //Turing Machine Building From Parse File
                         
                        //input word
                       

                        Validator.TuringMachineValidator(TM); // Validating a Turing Machine

                        Validator.TMProcessor(ref TM); //Running Turing Machine Against Input
                    }
                    
                }
                catch(Exception)
                {
                    Console.WriteLine("This is a Invalid Turing Machine");
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to Try Again");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                
                


            }
        }
    }
}
