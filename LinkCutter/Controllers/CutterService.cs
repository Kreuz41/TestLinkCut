using System.Text;

namespace LinkCutter.Controllers;

public class CutterService
{
    static CutterService()
    {
        var digits = "0123456789";
        var letters = "abcdefghijklmnopqrstuvwxyz";
        var bigLetters = letters.ToUpper();

        Alphabet = digits + letters + bigLetters;
    }
    private static string Alphabet { get; set; }
    private static string Domain { get; set; } = "https://domain/";

    public static string ToShort(long value)
    {
        var fullNumber = "";
        
        while (value != 0)
        { 
            var remainder = value % Alphabet.Length;
            fullNumber += Alphabet[(int)remainder];
            value /= Alphabet.Length;
        }

        return Domain + new string(fullNumber.Reverse().ToArray());
    }
    
    public static long FromShort(string link)
    {
        return link.Any(ch => !Alphabet.Contains(ch)) ? 0 : link.Select(t => Alphabet.IndexOf(t)).Select((digit, i) => digit * (long)Math.Pow(Alphabet.Length, link.Length - i - 1)).Sum();
    }
}