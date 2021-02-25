using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadPoolBoundHandle
{
    
    class Program
    {
       
        static void Main(string[] args)
        {
            Stopwatch cronometro = new Stopwatch();
            StreamReader read = new StreamReader("./nomi.txt");
            string file = "nomi.txt";
            if (File.Exists(file))
            {
                List<string> n = new List<string>();
                string l;
                while ((l = read.ReadLine()) != null)
                {
                    n.Add(l);
                }
                foreach (string s in n)
                {
                    Console.WriteLine(s);
                }
                Console.Write("\nInserisci il nome");
                string nome = Console.ReadLine();
                Console.ReadLine();
            }

            
        }
        private static void Thread(string s,List<string> nome)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t1 = new Thread(() => Ricerca(s ,nome));
                t1.Start();
            }
            
        }
        /*private static void ThreadPool(string s, List<string> nomi)
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(RicercaPool));
            }
        }*/
        private static void RicercaPool(object callback, string s, List<string> nome)
        {
            for (int i = 0; i < 10000; i++)
            {
                if (s == nome[i])
                {
                    Console.WriteLine($"{s} è stato trovato e di trova in: {i}");
                    break;

                }
                else
                {
                    Console.WriteLine($"{s} non è stato trovato");
                    break;
                }
            }
        }
        private static void Ricerca(string s ,List<string> nome)
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                if(s == nome[i])
                {
                     Console.WriteLine($"{s} è stato trovato e di trova in: {i}");
                    
                    break;
                    
                }
                else
                {
                    Console.WriteLine($"{s} non è stato trovato");
                    break;
                }
            }
            
        }
        
        
    }
}
