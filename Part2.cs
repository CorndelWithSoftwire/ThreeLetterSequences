using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ThreeLetterSequences
{
  public class Part2
  {
    public static void AnswerPart2()
    {
      string input = File.ReadAllText("SampleText.txt");
      var regex = new Regex(@"tra", RegexOptions.IgnoreCase);
      var matches = regex.Matches(input);

      Console.WriteLine($"There are {matches.Count} instances of 'tra' in the text, based on my regular expression");
    }

    public static void SurprisinglyNotWorking()
    {
      string input = File.ReadAllText("SampleText.txt");
      var regex = new Regex(@"\w\w\w");
      var matches = regex.Matches(input);

      int counter = 0;

      foreach (Match match in matches)
      {
        if (match.Value.ToLowerInvariant() == "tra")
        {
          counter++;
        }
      }

      Console.WriteLine($"There are {counter} instances of 'tra' in the text, based on my incorrect regular expression");
    }

    public static void ComplicatedButWorking()
    {
      string input = File.ReadAllText("SampleText.txt");
      var regex = new Regex(@"\w(?=(\w\w))");
      var matches = regex.Matches(input);

      int counter = 0;

      foreach (Match match in matches)
      {
        if (match.Value.ToLowerInvariant() == "t" && match.Groups[1].Value.ToLowerInvariant() == "ra")
        {
          counter++;
        }
      }

      Console.WriteLine($"There are {counter} instances of 'tra' in the text, based on my complicated regular expression");
    }

  }
}