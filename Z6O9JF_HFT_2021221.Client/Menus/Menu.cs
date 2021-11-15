using Z6O9JF_HFT_2021221.Client.Menus.SubMenus;

namespace Z6O9JF_HFT_2021221.Client
{
    public class Menu
    {
        public event UI consoleClear;
        public event UIWrite writer;
        public event UIWrite lineWriter;
        public event UICursor cursorPos;
        public event UICursorVis cursorVis;

        public void Start(RestService restService)
        {
            cursorVis?.Invoke(false);

            writer?.Invoke("Loading ");

            double timer = 0;

            while (timer < 50)
            {
                timer++;
                writer?.Invoke("\\");
                cursorPos?.Invoke(8, 0);
                System.Threading.Thread.Sleep(100);

                timer++;
                writer?.Invoke("|");
                cursorPos?.Invoke(8, 0);
                System.Threading.Thread.Sleep(100);

                timer++;
                writer?.Invoke("/");
                cursorPos?.Invoke(8, 0);
                System.Threading.Thread.Sleep(100);

                timer++;
                writer?.Invoke("-");
                cursorPos?.Invoke(8, 0);
                System.Threading.Thread.Sleep(100);
            }

            cursorPos?.Invoke(0, 0);
            writer?.Invoke("\t\t");
            cursorPos?.Invoke(0, 0);
            cursorVis?.Invoke(true);

            MenuLoaded(restService);
        }
        void MenuLoaded(RestService restService)
        {
            UIMethods ui = new();
            DelMenu delMenu = new();
            AdvMenu advMenu = new();
            CreMenu creMenu = new();
            ReaMenu reaMenu = new();
            UpdMenu updMenu = new();

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
                consoleClear?.Invoke();

                lineWriter?.Invoke(options);

                if (input.Equals("0"))
                {
                    terminalStop = true;
                }
                else if (input.Equals("1"))
                {
                    advMenu.AdvancedMenu(restService, consoleClear, writer, lineWriter,ui);

                    consoleClear?.Invoke();

                    lineWriter?.Invoke(options);
                }
                else if (input.Equals("2"))
                {
                    creMenu.CreateMenu(restService, consoleClear, writer, lineWriter,ui);

                    consoleClear?.Invoke();

                    lineWriter?.Invoke(options);

                }
                else if (input.Equals("3"))
                {
                    reaMenu.ReadMenu(restService, consoleClear, writer, lineWriter,ui);

                    consoleClear?.Invoke();

                    lineWriter?.Invoke(options);
                }
                else if (input.Equals("4"))
                {
                    updMenu.UpdateMenu(restService, consoleClear, writer, lineWriter,ui);

                    consoleClear?.Invoke();

                    lineWriter?.Invoke(options);
                }
                else if (input.Equals("5"))
                {
                    delMenu.DeleteMenu(restService, consoleClear, writer, lineWriter,ui);

                    consoleClear?.Invoke();

                    lineWriter?.Invoke(options);
                }
                else if (input.Equals("_"))
                {

                }
                else
                {
                    lineWriter?.Invoke("That is not a valid option!");
                }

                if (terminalStop == false)
                {
                    input = ui.UIConsoleInput();
                }
            }
        }
    }
}
