
namespace FinalAssignment
{
    public class Menu
    {
        public void Display()
        {
            StoreManagement StoreManager = new StoreManagement();
            while (true)
            {
                Console.WriteLine("Enter an option from the menu below:");
                Console.WriteLine("1. Add a store");
                Console.WriteLine("2. Reomve a store");
                Console.WriteLine("3. Assign types (e.g., Retail, Wholesale, Online, etc.)");
                Console.WriteLine("4. Update income");
                Console.WriteLine("5. Save data to the JSON file");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StoreManager.AddStore();
                        break;
                    case "2":
                        StoreManager.RemoveStore();
                        break;
                    case "3":
                        StoreManager.AssignTypes();
                        break;
                    case "4":
                        StoreManager.UpdateIncome();
                        break;
                    case "5":
                        StoreManager.SaveStoresToFile();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
