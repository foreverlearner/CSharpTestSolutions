using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTestSolution
{
    public delegate int dgPointer(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            Adder a = new Adder();
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;
            a.OnMultipleOfTwoReached += a_MultipleOfTwoReached;
            dgPointer pAdder = new dgPointer(a.Add);


            int iAnswer = pAdder(4, 3);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            iAnswer = pAdder(4, 6);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            Console.ReadKey();
        }

        static void a_MultipleOfFiveReached(object sender, EventArgs e)
        {
            Console.WriteLine("Multiple of five reached!");
        }
        static void a_MultipleOfTwoReached(object sender, EventArgs e)
        {
            Console.WriteLine("Multiple of two reached!");
        }
    }

    public class Adder
    {
        public event EventHandler<EventArgs> OnMultipleOfFiveReached;

        public event EventHandler<MultipleOfTwoEventArgs> OnMultipleOfTwoReached;

        public class MultipleOfTwoEventArgs : EventArgs
        {
            public MultipleOfTwoEventArgs(int iTotal)
            { Total = iTotal; }
            public int Total { get; set; }
        }

        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
            {
                OnMultipleOfFiveReached(this, EventArgs.Empty);
            }
            if ((iSum % 2 == 0) && (OnMultipleOfTwoReached != null))
            {
                OnMultipleOfTwoReached(this, new MultipleOfTwoEventArgs(iSum));
            }
            return iSum;
        }

    }
}
