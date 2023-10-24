using System;
using System.Collections.Generic;
using System.Linq;

namespace AmnestyProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();

            dataBase.Work();

            Console.ReadLine();
        }
    }

    class DataBase
    {
        private IEnumerable<Criminal> _criminals;

        public DataBase()
        {
            _criminals = new List<Criminal>
            {
                new Criminal("Смиринов", "грабеж"),
                new Criminal("Кузнецов", "воровство"),
                new Criminal("Алексеев", "антиправительственная"),
                new Criminal("Никитин", "причинение смерти по неосторожности"),
                new Criminal("Морозов", "антиправительственная"),
                new Criminal("Николаев", "грабеж"),
                new Criminal("Макаров", "воровство"),
                new Criminal("Андреев", "антиправительственная"),
                new Criminal("Захаров", "антиправительственная"),
            };
        }

        public void Work()
        {
            Console.WriteLine("До амнистии: ");
            Show(_criminals);

            _criminals = Amnesty(_criminals);

            Console.WriteLine("После амнистии: ");
            Show(_criminals);
        }

        private void Show(IEnumerable<Criminal> criminals)
        {
            if (criminals.Any())
            {
                foreach (Criminal jail in criminals)
                {
                    jail.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Нет преступников, соотвествующих условаию.");
            }
        }

        private static IEnumerable<Criminal> Amnesty(IEnumerable<Criminal> criminals)
        {
            string article = "антиправительственная";

            return criminals.Where(criminal => criminal.Crime != article);
        }
    }

    class Criminal
    {
        public Criminal(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"имя: {FullName}\t" +
                              $"статья: {Crime}");
        }
    }
}
