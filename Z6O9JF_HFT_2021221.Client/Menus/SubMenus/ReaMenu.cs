using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Client.Menus.SubMenus
{
    public class ReaMenu
    {
        public void ReadMenu(RestService restService, UI consoleClear, UIWrite writer, UIWrite lineWriter, UIMethods ui)
        {
            string options =
                "- Read -\n" +
                "\n" +
                "Press One Of The Following Numbers:\n" +
                "0 - Back\n" +
                "1 - Car\n" +
                "2 - Brand\n" +
                "3 - Mechanic\n" +
                "4 - Engine\n" +
                "5 - Owner\n";

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
                    var get = restService.Get<Car>("car");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.ToString());
                    }
                }
                else if (input.Equals("2"))
                {
                    var get = restService.Get<Brand>("brand");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.ToString());
                    }
                }
                else if (input.Equals("3"))
                {
                    var get = restService.Get<Mechanic>("mechanic");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.ToString());
                    }
                }
                else if (input.Equals("4"))
                {
                    var get = restService.Get<Engine>("engine");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.ToString());
                    }
                }
                else if (input.Equals("5"))
                {
                    var get = restService.Get<Owner>("owner");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.ToString());
                    }
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
