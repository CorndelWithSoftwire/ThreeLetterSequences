using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ThreeLetterSequences
{
  public class IgnoreNonWord
  {
    public static void AnswerStretchGoal(int targetFrequency, bool ignoreNonWordCharacters)
    {
      string input = File.ReadAllText("SampleText.txt");
      var dictionary = BuildTLSDictionary(input, ignoreNonWordCharacters);

      Console.WriteLine($"There are {dictionary["vou"]} instances of 'vou' in the text, according to my dictionary");
      Console.WriteLine();

      foreach (var entry in dictionary)
      {
        if (entry.Value == targetFrequency)
        {
          Console.WriteLine($"There are {targetFrequency} instances of {entry.Key}");
        }
      }

      Console.WriteLine();
      Console.WriteLine("Most frequent TLSs:");

      foreach (var entry in dictionary.OrderByDescending(entry => entry.Value).Take(10))
      {
        Console.WriteLine($"TLS: {entry.Key}, Frequency: {entry.Value}");
      }
    }

    private static Dictionary<string, int> BuildTLSDictionary(string input, bool ignoreNonWordCharacters)
    {
      var dictionary = new Dictionary<string, int>();
      var regex = ignoreNonWordCharacters
        ? new Regex(@"\w(?=\W*(\w)\W*(\w))", RegexOptions.Compiled)
        : new Regex(@"\w(?=(\w)(\w))", RegexOptions.Compiled);

      foreach (Match match in regex.Matches(input))
      {
        var tls = (match.Groups[0].Value + match.Groups[1].Value + match.Groups[2].Value).ToLowerInvariant();

        if (!dictionary.ContainsKey(tls))
        {
          dictionary.Add(tls, 0);
        }

        dictionary[tls] = dictionary[tls] + 1;
      }

      return dictionary;
    }
  }
}