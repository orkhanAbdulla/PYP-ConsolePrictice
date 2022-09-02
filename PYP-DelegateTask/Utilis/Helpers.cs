using PYP_DelegateTask.Models;
using System;


namespace PYP_DelegateTask
{
    static class Helpers
    {

        public static void Print(object text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void SleepErrorAndSuccefuly(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(50);
            }
            Console.ResetColor();
        }
        
    }
}   
