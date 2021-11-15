using System;
using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Client.Menus.SubMenus
{
    public class CreMenu
    {
        public void CreateMenu(RestService restService, UI consoleClear, UIWrite writer, UIWrite lineWriter, UIMethods ui)
        {
            string options =
                "- Create -\n" +
                "\n" +
                "Press One Of The Following Numbers:\n" +
                "0 - Back\n" +
                "1 - Create Car\n" +
                "2 - Create Brand\n" +
                "3 - Create Owner\n" +
                "4 - Create CarService\n" +
                "5 - Create Engine\n" +
                "6 - Create Mechanic\n";

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
                    lineWriter?.Invoke("- Car -\n");
                    writer?.Invoke("Please enter the desired BrandId of your car: ");

                    string brandInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    while (!restService.Get<Brand>("brand").Select(t => t.BrandId).Contains(int.Parse(brandInput)))
                    {
                        writer?.Invoke("Invalid Id please try again: ");
                        brandInput = ui.UIConsoleInput();
                    }

                    writer?.Invoke("Please enter the MechanicId: ");

                    string mechanicInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    while (!restService.Get<Mechanic>("mechanic").Select(t => t.MechanicId).Contains(int.Parse(mechanicInput)))
                    {
                        writer?.Invoke("Invalid Id please try again: ");
                        mechanicInput = ui.UIConsoleInput();
                    }

                    writer?.Invoke("Please enter the EngineCode: ");

                    string engineInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    while (!restService.Get<Engine>("engine").Select(t => t.EngineCode).Contains(int.Parse(engineInput)))
                    {
                        writer?.Invoke("Invalid Id please try again: ");
                        engineInput = ui.UIConsoleInput();
                    }

                    writer?.Invoke("Please enter the OwnerId: ");

                    string ownerInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    while (!restService.Get<Owner>("owner").Select(t => t.OwnerId).Contains(int.Parse(ownerInput)))
                    {
                        writer?.Invoke("Invalid Id please try again: ");
                        ownerInput = ui.UIConsoleInput();
                    }

                    restService.Post(new Car
                    {
                        BrandId = int.Parse(brandInput),
                        MechanicId = int.Parse(mechanicInput),
                        EngineCode = int.Parse(engineInput),
                        OwnerId = int.Parse(ownerInput)
                    }, "car");

                    lineWriter?.Invoke("Sucess!");
                }
                else if (input.Equals("2"))
                {
                    lineWriter?.Invoke("- Brand -\n");

                    writer?.Invoke("Please enter the desired Name of your Brand: ");

                    string nameInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    restService.Post(new Brand
                    {
                        Name = nameInput
                    }, "brand");

                    lineWriter?.Invoke("Sucess!");
                }
                else if (input.Equals("3"))
                {
                    lineWriter?.Invoke("- Owner -\n");

                    writer?.Invoke("Please enter the desired Name of your Owner: ");

                    string nameInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    restService.Post(new Owner
                    {
                        Name = nameInput
                    }, "owner");

                    lineWriter?.Invoke("Sucess!");
                }
                else if (input.Equals("4"))
                {
                    lineWriter?.Invoke("- CarService -\n");

                    writer?.Invoke("Please enter the desired Name of your CarService: ");

                    string nameInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    restService.Post(new CarService
                    {
                        Name = nameInput
                    }, "carservice");

                    lineWriter?.Invoke("Sucess!");

                }
                else if (input.Equals("5"))
                {
                    lineWriter?.Invoke("- Engine -\n");

                    writer?.Invoke("Please enter the desired BrandId of your Engine: ");

                    string brandInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    while (!restService.Get<Brand>("brand").Select(t => t.BrandId).Contains(int.Parse(brandInput)))
                    {
                        writer?.Invoke("Invalid Id please try again: ");
                        brandInput = ui.UIConsoleInput();
                    }

                    writer?.Invoke("Please enter the desired Power of your Engine: ");

                    string powerInput = ui.UIConsoleInput();

                    lineWriter?.Invoke("");

                    restService.Post(new Engine
                    {
                        BrandId = int.Parse(brandInput),
                        Power = int.Parse(powerInput)
                    }, "engine");

                    lineWriter?.Invoke("Sucess!");
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
