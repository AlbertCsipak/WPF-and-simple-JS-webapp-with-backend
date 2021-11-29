using Z6O9JF_HFT_2021221.Client.Menus.SubMenus;

namespace Z6O9JF_HFT_2021221.Client
{
    public delegate void UIClear();
    public delegate void UIWrite(string s);
    public delegate void UICursor(int i1, int i2);
    public delegate void UICursorVis(bool bl);
    public delegate string UIInput();
    public class Menu
    {
        public event UIClear consoleClear;
        public event UIWrite write;
        public event UIWrite writeLine;
        public event UICursor cursorPos;
        public event UICursorVis cursorVis;
        public event UIInput uiInput;

        public void Start(RestService restService)
        {
            UIMethods ui = new();
            DelMenu delMenu = new();
            AdvMenu advMenu = new();
            CreMenu creMenu = new();
            ReaMenu reaMenu = new();
            UpdMenu updMenu = new();

            cursorVis?.Invoke(false);

            cursorPos?.Invoke(50, 0);

            write?.Invoke("Loading ");

            //loader style 1
            write?.Invoke("\n[");

            cursorPos?.Invoke(102, 1);

            write?.Invoke("]");

            double sec = 7;

            for (int i = 0; i < 100; i++)
            {
                cursorPos?.Invoke(104, 1);
                write?.Invoke($"{i}%");

                cursorPos?.Invoke(42, 2);
                write?.Invoke($"est. time remaining: {sec:n1} s");

                cursorPos?.Invoke(i + 1, 1);
                write?.Invoke("=");

                cursorPos?.Invoke(i + 2, 1);
                write?.Invoke(">");

                sec = sec - 0.07;
                System.Threading.Thread.Sleep(70);
            }

            //loader style 2
            //for (int i = 0; i < 15; i++)
            //{
            //    writer?.Invoke("\\");
            //    cursorPos?.Invoke(8, 0);
            //    System.Threading.Thread.Sleep(100);

            //    writer?.Invoke("|");
            //    cursorPos?.Invoke(8, 0);
            //    System.Threading.Thread.Sleep(100);

            //    writer?.Invoke("/");
            //    cursorPos?.Invoke(8, 0);
            //    System.Threading.Thread.Sleep(100);

            //    writer?.Invoke("-");
            //    cursorPos?.Invoke(8, 0);
            //    System.Threading.Thread.Sleep(100);
            //}

            cursorPos?.Invoke(0, 0);
            write?.Invoke("\t\t");
            cursorPos?.Invoke(0, 0);
            cursorVis?.Invoke(true);

            MenuLoaded(restService, delMenu, advMenu, creMenu, reaMenu, updMenu);
        }
        void MenuLoaded(RestService restService, DelMenu delMenu, AdvMenu advMenu, CreMenu creMenu, ReaMenu reaMenu, UpdMenu updMenu)
        {
            string options =
                "- Welcome -\n" +
                "\n" +
                "Press One Of The Following Numbers:\n" +
                "0 - Exit\n" +
                "1 - Advanced\n" +
                "2 - Create\n" +
                "3 - Read\n" +
                "4 - Update\n" +
                "5 - Delete\n";

            string input = "_";

            bool terminalStop = false;

            while (terminalStop is false)
            {
                if (input.Equals("0"))
                {
                    terminalStop = true;
                }
                else if (input.Equals("1"))
                {
                    advMenu.AdvancedMenu(restService, consoleClear, write, writeLine, uiInput);

                    consoleClear?.Invoke();

                    writeLine?.Invoke(options);
                }
                else if (input.Equals("2"))
                {
                    creMenu.CreateMenu(restService, consoleClear, write, writeLine, uiInput);

                    consoleClear?.Invoke();

                    writeLine?.Invoke(options);

                }
                else if (input.Equals("3"))
                {
                    reaMenu.ReadMenu(restService, consoleClear, write, writeLine, uiInput);

                    consoleClear?.Invoke();

                    writeLine?.Invoke(options);
                }
                else if (input.Equals("4"))
                {
                    updMenu.UpdateMenu(restService, consoleClear, write, writeLine, uiInput);

                    consoleClear?.Invoke();

                    writeLine?.Invoke(options);
                }
                else if (input.Equals("5"))
                {
                    delMenu.DeleteMenu(restService, consoleClear, write, writeLine, uiInput);

                    consoleClear?.Invoke();

                    writeLine?.Invoke(options);
                }
                else if (input.Equals("_"))
                {
                    consoleClear?.Invoke();

                    writeLine?.Invoke(options);
                }
                else
                {
                    writeLine?.Invoke("That is not a valid option!");
                }

                if (terminalStop == false)
                {
                    input = uiInput?.Invoke();
                }
            }
        }
    }
}
