using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Client.Menus.SubMenus
{
    public class UpdMenu
    {
        public void UpdateMenu(RestService restService, UI consoleClear, UIWrite writer, UIWrite lineWriter)
        {
            string options =
                "- Update -\n" +
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
                    lineWriter?.Invoke("- Car -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to update: ");

                    string updateInput = UIMethods.UIConsoleInput();

                    lineWriter?.Invoke("");

                    Car carUpdate = restService.Get<Car>("car").FirstOrDefault(t => t.Vin == int.Parse(updateInput)); ;

                    while (carUpdate is null)
                    {
                        lineWriter?.Invoke("Invalid ID!");
                        updateInput = UIMethods.UIConsoleInput();

                        carUpdate = restService.Get<Car>("car").FirstOrDefault(t => t.Vin == int.Parse(updateInput));
                    }

                    //itt jó lenne a reflexió de no time :c

                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Mechanic Id: {carUpdate.MechanicId} -> ");
                    updateInput = UIMethods.UIConsoleInput();

                    if (!updateInput.Equals(""))
                    {
                        carUpdate.MechanicId = int.Parse(updateInput);
                    }

                    lineWriter?.Invoke("");
                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Model: {carUpdate.Model} -> ");
                    updateInput = UIMethods.UIConsoleInput();

                    if (!updateInput.Equals(""))
                    {
                        carUpdate.Model = updateInput;
                    }

                    restService.Put(carUpdate, "car");

                    lineWriter?.Invoke("Success!");
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
                    input = UIMethods.UIConsoleInput();
                }
            }
        }
    }
}
