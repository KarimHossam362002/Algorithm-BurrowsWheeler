using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MTF
{

    public static byte[] Encode(string text)
    {

        List<char> extendedAsciiSymbols = new List<char>(getAsciiSymbols());



        byte[] position = new byte[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            int index = extendedAsciiSymbols.IndexOf(text[i]);
            position[i] = (byte)index;
            char a = extendedAsciiSymbols[index];
            extendedAsciiSymbols.RemoveAt(index);
            extendedAsciiSymbols.Insert(0, a);
        }

        for (int i = 0; i < position.Length; i++)
            Console.WriteLine(position[i]);

        return position;
    }

    private static IEnumerable<char> getAsciiSymbols()
    {
        List<char> extendedAsciiSymbols = new List<char>();
        for (int i = 0; i < 256; i++)
        {
            extendedAsciiSymbols.Add((char)i);
        }
        return extendedAsciiSymbols;
    }

    public static void Decode(byte[] pos)
    {
        int length = pos.Length;
        StringBuilder decoded = new StringBuilder();
        List<char> extendedAsciiSymbols1 = new List<char>(getAsciiSymbols());

        foreach (int index in pos)
        {
            char a = extendedAsciiSymbols1[index];
            decoded.Append(a);
            extendedAsciiSymbols1.RemoveAt(index);
            extendedAsciiSymbols1.Insert(0, a);
        }

        string d = decoded.ToString();
        Console.WriteLine(d);
    }
        
}
