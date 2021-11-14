using System;
using System.Collections.Generic;

namespace Hahahaha
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string alphabet;
            int numalphabet;

            Console.WriteLine("Press enter twice to stop.");
            
            List<Fillout> fillout = new List<Fillout>();

            do
            {

                alphabet = Console.ReadLine();

                numalphabet = alphabet.Length;

                if (numalphabet == 0)
                {
                    calculate(fillout);

                    break;
                }

                if (numalphabet != 3)
                {
                    Console.WriteLine("Please enter only 2 characters or space.");
                }
                else
                {
                    fillout.Add(IntructionDaTa(alphabet));
                }

            } while (numalphabet >= 1);
        }


        static Fillout IntructionDaTa(string value)
        {


            string[] words = value.Split(' '); 
            string intruction = words[0]; 
            string data = words[1];
            Fillout fillout = new Fillout();
            fillout.intruction = intruction;
            fillout.data = data; 
            return fillout; 

        }


        static void calculate(List<Fillout> inputvalue, int count = 0)
        {
            count++;
            List<Fillout> waitingdata = new List<Fillout>();
            CPU[] cpu = new CPU[4];
            for (int a = 0; a < cpu.Length; a++)
            {
                cpu[a] = new CPU();
            }

            for (int i = 0; i < inputvalue.Count; i++)
            {
                string ins = inputvalue[i].intruction;
                for (int j = 0; j < cpu.Length; j++)
                {

                    if (cpu[j].CpuIntruction == null || cpu[j].CpuIntruction == ins)
                    {
                        cpu[j].CpuIntruction = ins;

                        for (int b = 0; b < cpu[j].CpuData.Length; b++)
                        {
                            if (cpu[j].CpuData[b] == null || cpu[j].CpuData[b] == inputvalue[i].data)
                            {
                                cpu[j].CpuData[b] = inputvalue[i].data;
                                break;
                            }
                            else if (b == cpu[j].CpuData.Length - 1)
                            {
                                waitingdata.Add(inputvalue[i]);
                                break;
                            }



                        }
                        break;
                    }
                    else if (j == cpu.Length - 1)
                    {
                        waitingdata.Add(inputvalue[i]);

                    }

                }
            }
            if (waitingdata.Count > 0)
            {
                calculate(waitingdata, count);
            }
            else
            {
                Console.WriteLine("CPU cycles needed: " + count);
            }
        }
    }
}




