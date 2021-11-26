using System.Collections.Generic;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Client.Menus.SubMenus
{
    public class AdvMenu
    {
        public void AdvancedMenu(RestService restService, UI consoleClear, UIWrite writer, UIWrite lineWriter,UIInput uIInput)
        {
            string options =
                "- Advanced -\n" +
                "\n" +
                "Press One Of The Following Numbers:\n" +
                "0 - Back\n" +
                "1 - Service Income\n" +
                "2 - Mechanic Enginetypes\n" +
                "3 - Owners And Their Strongest Car\n" +
                "4 - Carbrands In Service\n" +
                "5 - Avg Servicecost By Brands\n";

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
                    var get = restService.Get<KeyValuePair<string, int>>("advanced/serviceincome");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.Key + ": " + item.Value);
                    }
                }
                else if (input.Equals("2"))
                {
                    var get = restService.Get<KeyValuePair<string, List<Enums.EngineType>>>("advanced/mechanicenginetypes");

                    foreach (var item in get)
                    {
                        writer?.Invoke(item.Key + ": ");
                        foreach (var item1 in item.Value)
                        {
                            writer?.Invoke(item1.ToString() + " ");
                        }
                        lineWriter?.Invoke("");
                    }
                }
                else if (input.Equals("3"))
                {
                    var get = restService.Get<KeyValuePair<string, List<Car>>>("advanced/ownersandtheirstrongestcar");

                    foreach (var item in get)
                    {
                        writer?.Invoke(item.Key + ": ");
                        foreach (var item1 in item.Value)
                        {
                            writer?.Invoke(item1.Vin + " ");
                        }
                        lineWriter?.Invoke("");
                    }
                }
                else if (input.Equals("4"))
                {
                    var get = restService.Get<KeyValuePair<string, List<string>>>("advanced/carbrandsinservice");

                    foreach (var item in get)
                    {
                        writer?.Invoke(item.Key + ": ");
                        foreach (var item1 in item.Value)
                        {
                            writer?.Invoke(item1 + " ");
                        }
                        lineWriter?.Invoke("");
                    }
                }
                else if (input.Equals("5"))
                {
                    var get = restService.Get<KeyValuePair<string, double>>("advanced/avgservicecostbybrands");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.Key + ": " + item.Value);
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
                    input = uIInput?.Invoke();
                }
            }
        }
    }
}
