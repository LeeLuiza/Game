using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
class Program
{
    public static void Main()
    {
        Conditions game = new Conditions();
    }
}

public static class Word //считываем рандомное слово
{
    public static string ReadWord()
    {
        int i = 1;
        var random = new Random();
        
        List<string> text = new List<string>();

        using (StreamReader fs = new StreamReader(@"Word.txt"))
        {
            while (true)
            {
                string temp = fs.ReadLine();
                if (temp is null) break;
                text.Add(temp);
                i++;
            }
        }
        int index = random.Next(text.Count);
        int a = text[index].Length;
        Console.WriteLine($"Количество букв в слове {a}");

        //Console.WriteLine(text[index]);
        return text[index];
    }

    public static string CheckCharacter(this string word, char letter)
    {
        int m = 0;
        char[] array;
        array = word.ToCharArray();
        for (int i = 0; i < word.Length; i++)
        {
            if (array[i] == letter)
            {
                word = word.Remove(i, 1);              
                break;
            }
        }
        return word;
    }
}


public class Conditions 
{
    public string word = Word.ReadWord();

    public Conditions()
    {
        int counterror = 4;
        int error = 0;

        string w = word;
        int lengthword = word.Length;

        while (true)
        {
            Console.WriteLine("Введите букву");
            char latter = char.Parse(Console.ReadLine());

            w = w.CheckCharacter(latter);
            if (w.Length == lengthword)
            {
                error++;
                Console.WriteLine("Этой буквы нет в слове. " + $"Кол-во оставшихся ошибок - {counterror - error}");
                //Console.WriteLine($"Кол-во ошибок {error}");
                error.Sketch();
            }
            else
            {
                lengthword--;
                Console.WriteLine("Эта буква  есть в слове");
            }

            if (error >= counterror)
            {
                Console.WriteLine($"Игра окончена. Вы проиграли. Загаданное слово {word}");
                break;
            }

            if (lengthword == 0)
            {
                Console.WriteLine($"Вы выиграли. Загаданное слово {word}");
                break;
            }
        }
    }
}

public static class Draw
{
    public static void Sketch(this int error)
    {
        if (error == 1)
            Console.WriteLine("           ________\r\n");
        if (error == 2)
            Console.WriteLine("           ________\r\n          |       \r\n          |        \r\n          |        \r\n          |          \r\n          |       \r\n          |        \r\n          |          \r\n          |\r\n          |");
        if (error == 3)
            Console.WriteLine("           ________\r\n          |       \r\n          |          \r\n          |        \r\n          |          \r\n          |       \r\n          |        \r\n          |          \r\n          |\r\n        __|__________");
        if (error == 4)
            Console.WriteLine("           ________\r\n          |      |\r\n          |     ( )\r\n          |     _|_\r\n          |    / | \\\r\n          |      |\r\n          |     / \\\r\n          |    /   \\\r\n          |\r\n        __|__________");
    }
}
       /* ________
          |      |
          |     ( )
          |     _|_
          |    / | \
          |      |
          |     / \
          |    /   \
          |
        __|__________);*/        
