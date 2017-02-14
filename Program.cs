using System;
using System.Diagnostics;

namespace ThreeLetterSequences
{
  class Program
  {
    static void Main()
    {
      var targetFrequency = PromptForTargetFrequency();

      Stopwatch timer = new Stopwatch();
      timer.Start();

      IgnoreNonWord.AnswerStretchGoalFromTheInternet(targetFrequency, true);

      timer.Stop();

      Console.WriteLine();
      Console.WriteLine($"Took {timer.ElapsedMilliseconds} milliseconds");
      Console.ReadLine();
    }

    private static int PromptForTargetFrequency()
    {
      while (true)
      {
        Console.Write("What frequency of TLS would you like to look for? ");
        var frequency = Console.ReadLine();

        int ret;
        if (int.TryParse(frequency, out ret))
        {
          return ret;
        }
      }
    }
  }
}
