using System.Linq;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.Client.Menus.SubMenus
{
    public class UpdMenu
    {
        public void UpdateMenu(RestService restService, UI consoleClear, UIWrite writer, UIWrite lineWriter, UIInput uIInput)
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

                    string updateInput = uIInput?.Invoke();

                    lineWriter?.Invoke("");

                    Car toUpdate = restService.Get<Car>("car").FirstOrDefault(t => t.Vin == int.Parse(updateInput)); ;

                    while (toUpdate is null)
                    {
                        lineWriter?.Invoke("Invalid ID!");
                        updateInput = uIInput?.Invoke();

                        toUpdate = restService.Get<Car>("car").FirstOrDefault(t => t.Vin == int.Parse(updateInput));
                    }

                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Mechanic Id: {toUpdate.MechanicId} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.MechanicId = int.Parse(updateInput);
                    }

                    lineWriter?.Invoke("");
                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Model: {toUpdate.Model} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.Model = updateInput;
                    }

                    restService.Put(toUpdate, "car");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("2"))
                {
                    lineWriter?.Invoke("- Brand -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to update: ");

                    string updateInput = uIInput?.Invoke();

                    lineWriter?.Invoke("");

                    Brand toUpdate = restService.Get<Brand>("brand").FirstOrDefault(t => t.BrandId == int.Parse(updateInput)); ;

                    while (toUpdate is null)
                    {
                        lineWriter?.Invoke("Invalid ID!");
                        updateInput = uIInput?.Invoke();

                        toUpdate = restService.Get<Brand>("brand").FirstOrDefault(t => t.BrandId == int.Parse(updateInput));
                    }

                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Name: {toUpdate.Name} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.Name = updateInput;
                    }

                    lineWriter?.Invoke("");
                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Location: {toUpdate.Location} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.Location = updateInput;
                    }

                    restService.Put(toUpdate, "brand");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("3"))
                {
                    lineWriter?.Invoke("- Mechanic -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to update: ");

                    string updateInput = uIInput?.Invoke();

                    lineWriter?.Invoke("");

                    Mechanic toUpdate = restService.Get<Mechanic>("mechanic").FirstOrDefault(t => t.MechanicId == int.Parse(updateInput)); ;

                    while (toUpdate is null)
                    {
                        lineWriter?.Invoke("Invalid ID!");
                        updateInput = uIInput?.Invoke();

                        toUpdate = restService.Get<Mechanic>("mechanic").FirstOrDefault(t => t.MechanicId == int.Parse(updateInput));
                    }

                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Name: {toUpdate.Name} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.Name = updateInput;
                    }

                    lineWriter?.Invoke("");
                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"ServiceID: {toUpdate.ServiceId} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.ServiceId = int.Parse(updateInput);
                    }

                    restService.Put(toUpdate, "mechanic");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("4"))
                {
                    lineWriter?.Invoke("- Engine -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to update: ");

                    string updateInput = uIInput?.Invoke();

                    lineWriter?.Invoke("");

                    Engine toUpdate = restService.Get<Engine>("engine").FirstOrDefault(t => t.EngineCode == int.Parse(updateInput)); ;

                    while (toUpdate is null)
                    {
                        lineWriter?.Invoke("Invalid ID!");
                        updateInput = uIInput?.Invoke();

                        toUpdate = restService.Get<Engine>("engine").FirstOrDefault(t => t.EngineCode == int.Parse(updateInput));
                    }

                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Power: {toUpdate.Power} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.Power = int.Parse(updateInput);
                    }

                    lineWriter?.Invoke("");
                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"BrandID: {toUpdate.BrandId} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.BrandId = int.Parse(updateInput);
                    }

                    restService.Put(toUpdate, "engine");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("5"))
                {
                    lineWriter?.Invoke("- Owner -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to update: ");

                    string updateInput = uIInput?.Invoke();

                    lineWriter?.Invoke("");

                    Owner toUpdate = restService.Get<Owner>("owner").FirstOrDefault(t => t.OwnerId == int.Parse(updateInput)); ;

                    while (toUpdate is null)
                    {
                        lineWriter?.Invoke("Invalid ID!");
                        updateInput = uIInput?.Invoke();

                        toUpdate = restService.Get<Owner>("owner").FirstOrDefault(t => t.OwnerId == int.Parse(updateInput));
                    }

                    lineWriter?.Invoke("Add the new value or leave it empty");
                    writer?.Invoke($"Name: {toUpdate.Name} -> ");
                    updateInput = uIInput?.Invoke();

                    if (!updateInput.Equals(""))
                    {
                        toUpdate.Name = updateInput;
                    }

                    restService.Put(toUpdate, "name");

                    lineWriter?.Invoke("Success!");
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
