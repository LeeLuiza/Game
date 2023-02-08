using System;
using System.Data;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

class Programm
{
    public static void Main()
    {
        int counterror = 3;
        int error = 0;

        Console.WriteLine("Введите число от 1 до 8");
        int number = (int.Parse(Console.ReadLine()) - 1);
        string word = number.ReadWord();

        string w = word;
        int lengthword = word.Length;

        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine("Введите букву");
            char latter = char.Parse(Console.ReadLine());

            w = w.CheckCharacter(latter);
            if (w.Length == lengthword)
            {
                error += 1;
                Console.WriteLine("Этой буквы нет в слове. " + $"Кол-во оставшихся ошибок - {counterror - error}");
            }
            else
            {
                lengthword -= 1;
                Console.WriteLine("Эта буква  есть в слове");
            }

            if (error >= counterror)
            {
                Console.WriteLine($"Игра окончена. Вы проиграли. Загаданное слово {word}");
                break;
            }
            
            if (lengthword == 0) Console.WriteLine($"Вы выиграли. Загаданное слово {word}");          
        }
    }

}

public static class Reading //считываем радномное слово
{
    public static string ReadWord(this int number)
    {
        int i = 0;
        string[] text;
        text = new string[8];
        using (StreamReader fs = new StreamReader(@"Word.txt"))
        {
            while (true)
            {             
                string temp = fs.ReadLine();                
                if (temp == null) break;              
                text[i] += temp;
                i += 1;
            }
        }
        return text[number];
    }
    
}

public static class check
{
    public static string CheckCharacter(this string word, char latter)
    {
        int m = 0;  
        char[] array;
        array = word.ToCharArray();
        for (int i = 0; i < word.Length; i++)
        {
            if (array[i] == latter)
            {
                word = word.Remove(i, 1);
                break;
            }
        }     
        return word;
    }
}
