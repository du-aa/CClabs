using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter usernames (separated by commas): ");
        string input = Console.ReadLine();
        string[] usernames = input.Split(',');

        List<string> validUsernames = new List<string>();
        List<string> invalidUsernames = new List<string>();
        List<string> output = new List<string>();

        foreach (string username in usernames.Select(u => u.Trim()))
        {
            string validationResult = ValidateUsername(username, out bool isValid);
            if (isValid)
            {
                validUsernames.Add(username);
                string password = GeneratePassword();
                string strength = EvaluatePasswordStrength(password);
                output.Add($"{username} - Valid\n{validationResult}\nGenerated Password: {password} (Strength: {strength})");
            }
            else
            {
                invalidUsernames.Add(username);
                output.Add($"{username} - Invalid ({validationResult})");
            }
        }

        // Display results
        Console.WriteLine("\nValidation Results:");
        output.ForEach(Console.WriteLine);

        // Summary
        Console.WriteLine($"\nSummary:");
        Console.WriteLine($"- Total Usernames: {usernames.Length}");
        Console.WriteLine($"- Valid Usernames: {validUsernames.Count}");
        Console.WriteLine($"- Invalid Usernames: {invalidUsernames.Count}");

        // Save to file
        SaveResultsToFile(output, usernames.Length, validUsernames.Count, invalidUsernames.Count);

        // Retry invalid usernames
        if (invalidUsernames.Count > 0)
        {
            Console.Write("\nDo you want to retry invalid usernames? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                Console.Write("Enter invalid usernames: ");
                string retryInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(retryInput))
                {
                    Main(new string[] { retryInput });
                }
            }
        }
    }

    static string ValidateUsername(string username, out bool isValid)
    {
        isValid = true;
        string errors = "";

        if (!Regex.IsMatch(username, @"^[a-zA-Z]"))
        {
            isValid = false;
            errors += "Username must start with a letter. ";
        }

        if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]{5,15}$"))
        {
            isValid = false;
            errors += "Username length must be between 5 and 15 and contain only letters, digits, and underscores. ";
        }

        if (isValid)
        {
            int upper = username.Count(char.IsUpper);
            int lower = username.Count(char.IsLower);
            int digits = username.Count(char.IsDigit);
            int underscores = username.Count(c => c == '_');
            return $"Letters: {upper + lower} (Uppercase: {upper}, Lowercase: {lower}), Digits: {digits}, Underscores: {underscores}";
        }

        return errors.Trim();
    }

    static string GeneratePassword()
    {
        Random rnd = new Random();
        string upper = GetRandomChars("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 2, rnd);
        string lower = GetRandomChars("abcdefghijklmnopqrstuvwxyz", 2, rnd);
        string digits = GetRandomChars("0123456789", 2, rnd);
        string special = GetRandomChars("!@#$%^&*", 2, rnd);
        string remaining = GetRandomChars("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*", 4, rnd);
        return ShuffleString(upper + lower + digits + special + remaining, rnd);
    }

    static string GetRandomChars(string source, int count, Random rnd)
    {
        return new string(Enumerable.Range(0, count).Select(_ => source[rnd.Next(source.Length)]).ToArray());
    }

    static string ShuffleString(string input, Random rnd)
    {
        return new string(input.OrderBy(_ => rnd.Next()).ToArray());
    }

    static string EvaluatePasswordStrength(string password)
    {
        int variety = 0;
        if (password.Any(char.IsUpper)) variety++;
        if (password.Any(char.IsLower)) variety++;
        if (password.Any(char.IsDigit)) variety++;
        if (password.Any(c => "!@#$%^&*".Contains(c))) variety++;

        if (password.Length >= 12 && variety == 4) return "Strong";
        if (password.Length >= 10 && variety >= 3) return "Medium";
        return "Weak";
    }

    static void SaveResultsToFile(List<string> results, int total, int valid, int invalid)
    {
        string filePath = "UserDetails.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string result in results)
            {
                writer.WriteLine(result);
                writer.WriteLine();
            }

            writer.WriteLine("Summary:");
            writer.WriteLine($"- Total Usernames: {total}");
            writer.WriteLine($"- Valid Usernames: {valid}");
            writer.WriteLine($"- Invalid Usernames: {invalid}");
        }
        Console.WriteLine($"\nResults saved to {filePath}");
    }
}
