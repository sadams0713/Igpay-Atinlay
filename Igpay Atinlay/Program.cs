using System;
using System.Text;


namespace IgpayAtinlay
{
    class Program
{


    static void Main()
    {
        Console.WriteLine("Welcome to the Pig Latin Translator!");

        bool loop = true;
        while (loop)
        {
            Console.WriteLine("Enter a line to be translated: ");

            string translated = TTPL(Console.ReadLine().ToLower());
            Console.WriteLine(translated);
            
                Console.WriteLine("Would you like to translate more? Enter yes or no");
            
                bool retryLoop = true;
            while (retryLoop)
            {
                string answer = Console.ReadLine().ToLower();
                if (answer == "y" || answer == "yes")
                {
                    retryLoop = false;
                    break;
                }
                else if (answer == "n" || answer == "no")
                {
                    loop = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Didn't quite catch that. Try typing 'yes' or 'no'");
                }
            }
        }
    }

    public static string FixPunctuation(string input)
    {
        string punctuation = "!?,;:'.";
        string fixpunc = input;

        for (int i = 0; i < input.Length; i++)
        {
            if (punctuation.Contains(input [i]))
            {
                fixpunc = input.Remove(i, 1) + input.Substring(i, 1) + " ";
                break;
            }
            else
            {
                continue;
            }
        }
        return fixpunc;
    }

    public static string TTPL(string input)
    {
        StringBuilder PLString = new StringBuilder();
        string[] separators = Array.Empty<string>();

        string[] SplitWordsToArray = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in SplitWordsToArray)
        {

            string firstLetter = word[..1];
            bool isVowel = "oiuae".IndexOf(firstLetter) >= 0;
            string vowels = "oiuae";
            string specials = "<>-*/*&^%$#@";
            bool flag = false;

            for (int x = 0; x < word.Length; x++)
            {
                if (specials.Contains(word[x]))
                {
                    PLString.Append(word + " ");
                    flag = true;
                    break;
                }

            }

            if (isVowel && flag == false)
            {

                string convertWord = word + "way ";
                string finalWord = FixPunctuation(convertWord);
                PLString.Append(finalWord);

            }
            else if (!isVowel && flag == false)
            {
                int vowelIndex = 0;

                for (int x = 1; x < word.Length; x++)
                {
                    if (vowels.Contains(word[x]))
                    {
                        vowelIndex = x;
                        break;
                    }
                }
                string changeWord = word.Remove(0, vowelIndex) + word[..vowelIndex] + "ay ";
                string endword = FixPunctuation(changeWord);
                PLString.Append(endword);
            }
        }

        return PLString.ToString();
    }

}
}