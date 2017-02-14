using System;
using System.IO;

namespace ThreeLetterSequences
{
  public class Part1
  {
    public static void AnswerPart1()
    {
      string input = File.ReadAllText("SampleText.txt").ToLowerInvariant();

      int counter = 0;

      for (int i = 0; i < input.Length-2; i++)
      {
        if (input[i] == 't' && input[i + 1] == 'r' && input[i + 2] == 'a')
        {
          counter++;
        }
      }

      Console.WriteLine($"There are {counter} instances of 'tra' in the text");
    }
  }
}