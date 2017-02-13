using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ThreeLetterSequences
{
  public class Part3
  {
    public static void AnswerPart3()
    {
      string input = File.ReadAllText("SampleText.txt");
      var dictionary = BuildTLSDictionary(input);

      Console.WriteLine($"There are {dictionary["vou"]} instances of 'vou' in the text, according on my dictionary");
      Console.WriteLine();

      foreach (var entry in dictionary)
      {
        if (entry.Value == 99)
        {
          Console.WriteLine($"There are 99 instances of {entry.Key}");
        }
      }
    }

    private static Dictionary<string, int> BuildTLSDictionary(string input)
    {
      var dictionary = new Dictionary<string, int>();
      var regex = new Regex(@"\w\w\w", RegexOptions.Compiled);

      for (int i = 0; i < input.Length - 2; i++)
      {
        var possibleTLS = input.Substring(i, 3).ToLowerInvariant();

        if (regex.IsMatch(possibleTLS))
        {
          if (!dictionary.ContainsKey(possibleTLS))
          {
            dictionary.Add(possibleTLS, 0);
          }

          dictionary[possibleTLS] = dictionary[possibleTLS] + 1;
        }
      }
      return dictionary;
    }
  }
}