using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class StringCalculator
{
    public int Add(string input)
    {
        MatchCollection numericSubstrings = Regex.Matches(input, @"-?\d+");

        List<int> parsedNumericSubstrings = numericSubstrings.Cast<Match>()
            .Select(m => int.Parse(m.Value))
            .ToList();

        List<int> negativeNumbers = parsedNumericSubstrings.Where(n => n < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new Exception("Negatives not allowed: " + string.Join(" ", negativeNumbers));
        }

        int sum = parsedNumericSubstrings.Where(n => n >= 0 && n <= 1000).Sum();

        return sum;
    }
}

public class Program
{
    public static void Main(string[] args)
    {

    }
}