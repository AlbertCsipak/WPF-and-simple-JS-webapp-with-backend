using Z6O9JF_HFT_2021221.Models;
using System;

namespace Z6O9JF_HFT_2021221.Client
{
    public class Program
    {
        public delegate void UIClear();
        public delegate void UIWrite(string s);
        public delegate void UICursor(int i1, int i2);
        public delegate void UICursorVis(bool bl);

        public static void ConsoleClear()
        {
            Console.Clear();
        }
        public static string UIConsoleInput()
        {
            return Console.ReadLine();
        }
        public static void Writer(string s) 
        {
            Console.Write(s);
        }
        public static void LineWriter(string s)
        {
            Console.WriteLine(s);
        }
        public static void CursorPos(int i1,int i2)
        {
            Console.SetCursorPosition(i1, i2);
        }
        public static void CursorVis(bool tf)
        {
            Console.CursorVisible = tf;
        }

        static void Main(string[] args)
        {
            RestService restService = new("http://localhost:11111");
            
            Menu menu = new();

            Menu.writer += Writer;
            Menu.lineWriter += LineWriter;
            Menu.cursorPos += CursorPos;
            Menu.cursorVis += CursorVis;
            Menu.consoleClear += ConsoleClear;

            menu.Start(restService);

        }
    }
}
