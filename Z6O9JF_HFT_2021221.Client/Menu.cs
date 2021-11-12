using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Models;
using static Z6O9JF_HFT_2021221.Client.Program;

namespace Z6O9JF_HFT_2021221.Client
{
    public class Menu
    {
        public static event UIWrite writer;
        public static event UIWrite lineWriter;
        public static event UIClear consoleClear;
        public static event UICursor cursorPos;
        public static event UICursorVis cursorVis;

        //var serviceIncome = restService.Get<object>("advanced/serviceincome");
        //var mechanicEngineTypes = restService.Get<object>("advanced/mechanicenginetypes");
        //var ownersAndTheirStrongestCar = restService.Get<object>("advanced/ownersandtheirstrongestcar");
        //var carBrandsInsService = restService.Get<object>("advanced/carbrandsinservice");
        //var avgServiceCostByBrands = restService.Get<object>("advanced/avgservicecostbybrands");

        public Menu(){}

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

            cursorPos?.Invoke(0,0);
            writer?.Invoke("\t\t");
            cursorPos?.Invoke(0, 0);
            cursorVis?.Invoke(true);
            MenuDone(restService);
        }
        public void MenuDone(RestService restService) 
        {
            string options =
                "- Welcome -\n" +
                "\n" +
                "Press One Of The Following Numbers:\n" +
                "0 - Exit\n" +
                "1 - List Datas\n" +
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
                    MenuList(restService);

                    consoleClear?.Invoke();

                    lineWriter?.Invoke(options);
                }
                else if (input.Equals("2"))
                {

                }
                else if (input.Equals("3"))
                {

                }
                else if (input.Equals("4"))
                {

                }
                else if (input.Equals("5"))
                {
                    
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
                    input = UIConsoleInput();
                }
            }
        }
        public void MenuList(RestService restService) 
        {
            string options =
                "- List Datas -\n" +
                "\n" +
                "Press One Of The Following Numbers:\n" +
                "0 - Back\n" +
                "1 - Brands\n" +
                "2 - Cars\n" +
                "3 - Owners\n" +
                "4 - Services\n" +
                "5 - Engines\n";

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
                    var get = restService.Get<Brand>("brand");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.Name + " " + item.BrandId);
                    }
                    lineWriter?.Invoke("");
                }
                else if (input.Equals("2"))
                {
                    var get = restService.Get<Car>("car");

                    foreach (var item in get)
                    {
                        lineWriter?.Invoke(item.BrandId + " " + item.Model);
                    }
                }
                else if (input.Equals("3"))
                {
                    var brands = restService.Get<Owner>("owner");

                    foreach (var item in brands)
                    {
                        lineWriter?.Invoke(item.Name + " " + item.OwnerId);
                    }
                }
                else if (input.Equals("4"))
                {
                    var brands = restService.Get<Brand>("brand");

                    foreach (var item in brands)
                    {
                        lineWriter?.Invoke(item.Name + " " + item.BrandId);
                    }
                }
                else if (input.Equals("5"))
                {
                    var brands = restService.Get<Brand>("brand");

                    foreach (var item in brands)
                    {
                        lineWriter?.Invoke(item.Name + " " + item.BrandId);
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
                    input = UIConsoleInput();
                }
            }
        }
    }
}
