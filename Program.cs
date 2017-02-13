using System;
using System.Diagnostics;

namespace ThreeLetterSequences
{
  class Program
  {
    static void Main()
    {
      Stopwatch timer = new Stopwatch();
      timer.Start();

      Part3.AnswerPart3();

      timer.Stop();

      Console.WriteLine();
      Console.WriteLine($"Took {timer.ElapsedMilliseconds} milliseconds");
      Console.ReadLine();
    }
  }
}
