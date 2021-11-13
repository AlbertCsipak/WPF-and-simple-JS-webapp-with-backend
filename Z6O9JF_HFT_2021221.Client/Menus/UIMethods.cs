using System;

namespace Z6O9JF_HFT_2021221.Client
{
    public class UIMethods
    {
        public static string UIConsoleInput()
        {
            return Console.ReadLine();
        }
        public void ConsoleClear()
        {
            Console.Clear();
        }
        public void Writer(string s)
        {
            Console.Write(s);
        }
        public void LineWriter(string s)
        {
            Console.WriteLine(s);
        }
        public void CursorPos(int i1, int i2)
        {
            Console.SetCursorPosition(i1, i2);
        }
        public void CursorVis(bool tf)
        {
            Console.CursorVisible = tf;
        }

    }
}
