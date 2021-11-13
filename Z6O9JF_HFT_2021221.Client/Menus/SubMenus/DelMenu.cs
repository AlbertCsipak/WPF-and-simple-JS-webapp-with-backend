namespace Z6O9JF_HFT_2021221.Client.Menus.SubMenus
{
    public class DelMenu
    {
        public void DeleteMenu(RestService restService, UI consoleClear, UIWrite writer, UIWrite lineWriter)
        {
            string options =
                "- Delete -\n" +
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
                    writer?.Invoke("Please type the Id of the Entity that you would like to delete: ");

                    string deleteInput = UIMethods.UIConsoleInput();

                    restService.Delete(int.Parse(deleteInput), "car");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("2"))
                {
                    lineWriter?.Invoke("- Brand -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to delete: ");

                    string deleteInput = UIMethods.UIConsoleInput();

                    restService.Delete(int.Parse(deleteInput), "brand");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("3"))
                {
                    lineWriter?.Invoke("- Mechanic -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to delete: ");

                    string deleteInput = UIMethods.UIConsoleInput();

                    restService.Delete(int.Parse(deleteInput), "mechanic");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("4"))
                {
                    lineWriter?.Invoke("- Engine -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to delete: ");

                    string deleteInput = UIMethods.UIConsoleInput();

                    restService.Delete(int.Parse(deleteInput), "engine");

                    lineWriter?.Invoke("Success!");
                }
                else if (input.Equals("5"))
                {
                    lineWriter?.Invoke("- Owner -\n");
                    writer?.Invoke("Please type the Id of the Entity that you would like to delete: ");

                    string deleteInput = UIMethods.UIConsoleInput();

                    restService.Delete(int.Parse(deleteInput), "owner");

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
                    input = UIMethods.UIConsoleInput();
                }
            }
        }
    }
}
