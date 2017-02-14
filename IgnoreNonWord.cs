using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace ThreeLetterSequences
{
  public class IgnoreNonWord
  {
    public static void AnswerStretchGoalFromDisk(int targetFrequency, bool ignoreNonWordCharacters)
    {
      string input = File.ReadAllText("SampleText.txt");
      AnswerStretchGoal(input, targetFrequency, ignoreNonWordCharacters);
    }

    public static void AnswerStretchGoalFromTheInternet(int targetFrequency, bool ignoreNonWordCharacters)
    {
      using (var webClient = new WebClient())
      {
        string input = webClient.DownloadString(@"https://en.wikipedia.org/wiki/Three-letter_acronym");
        AnswerStretchGoal(input, targetFrequency, ignoreNonWordCharacters);
      }
    }

    private static void AnswerStretchGoal(string input, int targetFrequency, bool ignoreNonWordCharacters)
    {
      var dictionary = BuildTLSDictionary(input, ignoreNonWordCharacters);

      PrintFrequencyOfTra(dictionary);
      PrintTLSsOfFrequency(targetFrequency, dictionary);
      PrintMostFrequentTLSs(dictionary);
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
        AddOrIncrement(dictionary, tls);
      }

      return dictionary;
    }

    private static void AddOrIncrement<T>(Dictionary<T, int> dictionary, T key)
    {
      if (!dictionary.ContainsKey(key))
      {
        dictionary.Add(key, 0);
      }

      dictionary[key] = dictionary[key] + 1;
    }

    private static void PrintFrequencyOfTra(Dictionary<string, int> dictionary)
    {
      Console.WriteLine($"There are {dictionary["tra"]} instances of 'tra' in the text, according to my dictionary");
    }

    private static void PrintTLSsOfFrequency(int targetFrequency, Dictionary<string, int> dictionary)
    {
      Console.WriteLine();

      foreach (var entry in dictionary)
      {
        if (entry.Value == targetFrequency)
        {
          Console.WriteLine($"There are {targetFrequency} instances of {entry.Key}");
        }
      }
    }

    private static void PrintMostFrequentTLSs(Dictionary<string, int> dictionary)
    {
      Console.WriteLine();
      Console.WriteLine("Most frequent TLSs:");

      foreach (var entry in dictionary.OrderByDescending(entry => entry.Value).Take(10))
      {
        Console.WriteLine($"TLS: {entry.Key}, Frequency: {entry.Value}");
      }
    }

  }
}