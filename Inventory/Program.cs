using System.ComponentModel;

namespace Inventory
{
    internal class Program
    {
        static List<Item> items = new List<Item>();    
        static void Main(string[] args)
        {            
            bool keepGoing = false;

            do
            {            
                Console.WriteLine("Enter the number for what you want to do?\n\n  1) Add an item\n  2) Remove an item\n  3) Update inventory\n  4) Display inventory\n  5) Exit\n");
                Console.Write("What do you want to do?: ");
                int whatToDo = ChoiseCheck(Console.ReadLine());

                switch (whatToDo)
                {
                    case 1:
                        CreateItem();                       
                        break;
                    case 2:
                        RemoveItem();                       
                        break;
                    case 3:
                        UpdateInventory();
                        break;
                    case 4:
                        CheckInventory();
                        break;                                
                    default:                        
                        keepGoing= true;
                        break;
                }                
                Console.Clear();
                
            } while (!keepGoing);

            Console.WriteLine("Goodbye");

            Console.ReadKey();
        }

        static int IntCheck(string number)
        {
            int trueNumber;
            bool youShallPass = false;

            do
            {
                if (int.TryParse(number, out trueNumber))
                {
                    youShallPass = true;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please choose another one.");
                    number = Console.ReadLine();
                }
            } while (!youShallPass);

            return trueNumber;
        }

        static int ChoiseCheck(string number)
        {
            int trueNumber;
            bool youShallPass = false;

            do
            {
                if (int.TryParse(number, out trueNumber) && trueNumber > 0 && trueNumber <= 5)
                {                    
                    youShallPass = true;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please choose another one.");
                    number = Console.ReadLine();
                }
            } while (!youShallPass);            

            return trueNumber;
        }

        static void CreateItem()
        {            
            Console.Clear();

            Console.WriteLine("Enter the number for the category you want to add an item to.\n");
            string category = ChooseCategorie();

            Console.Clear();

            Console.WriteLine(category);
            Console.Write("Name: ");
            string name = Console.ReadLine();

            for (int i = 0; i < items.Count; i++)
            {
                do
                {                    
                    if (name.Equals(items[i].Name))
                    {
                        Console.Write($"{name} already exists. Type in another name: ");
                        name = Console.ReadLine();                        
                    }
                } while (name.Equals(items[i].Name));
            }
            
            Console.Write("Article number: ");
            int artNumber = IntCheck(Console.ReadLine());

            for (int i = 0; i < items.Count; i++)
            {
                do
                {
                    if (artNumber.Equals(items[i].ArtNumber))
                    {
                        Console.Write($"{artNumber} already exists. Type in another article number: ");
                        artNumber = IntCheck(Console.ReadLine());                        
                    }
                } while (artNumber.Equals(items[i].ArtNumber));
            }

            Console.Write("Quantity of the item: ");
            int inventory = IntCheck(Console.ReadLine());

            Item newItem = new Item(category, name, artNumber, inventory);
            items.Add(newItem);

            Console.WriteLine("Item added. Press enter to continue.");
            Console.ReadKey();
        }

        static void RemoveItem()
        {
            Console.Clear();

            CheckInventory();

            Console.WriteLine("Type in the article number of the item you want to remove. Type 0 to exit.");
            Console.Write("Article number: ");
            int remove = IntCheck(Console.ReadLine());
            
            do
            {
                if (remove == 0)
                {
                    break;
                }
                else if (!DoesItExist(remove))                
                {
                    Console.Write("No Item with that article number. Please try again: ");
                    remove = IntCheck(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Item Removed. Press enter to continue.");
                    Console.ReadKey();
                }
            }while(DoesItExist(remove));            
        } 
        
        static bool DoesItExist(int artNumber)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (artNumber.Equals(items[i].ArtNumber))
                {
                    items.RemoveAt(i);
                    return true;
                }               
            }

            return false;
        }

        static void UpdateInventory()
        {
            bool youShallPass = false;

            Console.Clear();

            CheckInventory();

            Console.WriteLine("Type in the article number of the item you want to change. Type 0 to exit.");
            Console.Write("Article number: ");
            int itemChange = IntCheck(Console.ReadLine());

            do
            {
                if (itemChange != 0)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (itemChange.Equals(items[i].ArtNumber))
                        {
                            Console.Clear();
                            Console.WriteLine("What would you like to change?\n  1) Name\n  2) Article number\n  3) Quantity\n  4) Exit");
                            int whatToDo = IntCheck(Console.ReadLine());
                            switch (whatToDo)
                            {
                                case 1:
                                    Console.Write("Type in the new name: ");
                                    items[i].Name = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("Type in the new article number: ");
                                    items[i].ArtNumber = IntCheck(Console.ReadLine());
                                    break;
                                case 3:
                                    Console.Write("Type in the new quantity: ");
                                    items[i].Inventory = IntCheck(Console.ReadLine());
                                    break;
                                default:
                                    break;
                            }
                            youShallPass = true;
                        }
                    }
                }
                else if (itemChange == 0)
                {
                    youShallPass= true;
                }
                else
                {
                    Console.WriteLine("Invaldi choise. Try again.");
                    itemChange = IntCheck(Console.ReadLine());
                }
                
            } while (!youShallPass);
        }

        static void CheckInventory()
        {
            Console.Clear();

            Console.WriteLine("Choose the category you want to access.\n");
            string category = ChooseCategorie();

            Console.Clear();

            Console.WriteLine(category + "\n");

            Console.WriteLine("NAME".PadRight(20) + "ARTICLE NUMBER".PadRight(20) + "QUANTITY\n");
            for (int i = 0; i < items.Count; i++)
            {
                if (category.Equals(items[i].Category))
                {
                    Print(items[i].Name, items[i].ArtNumber, items[i].Inventory);
                }
            }

            Console.WriteLine("\nPress enter to continue.");
            Console.ReadKey();
        }

        static string ChooseCategorie()
        {
            string[] categories = new string[19]
            {"Fruits", "Vegetables", "Canned Goods", "Dairy", "Meat", "Fish & Seafood", "Deli", "Condiments & Spices", "Snacks", 
             "Bread & Bakery", "Beverages", "Pasta, Rice & Cereal", "Baking", "Frozen Foods", "Personal Care", "Health Care",
             "Household & Cleaning Supplies", "Baby Items", "Pet Care"
            };
            int i = 1;
            
            foreach (string category in categories)
            {
                Console.WriteLine($"  {i}) " + category);
                i++;
            }

            Console.Write("\nCategory: ");
            int whatCategory = IntCheck(Console.ReadLine());

            do
            {
                if (whatCategory > 19)
                {
                    Console.Write("Invalid category. Please try again:");
                    whatCategory = IntCheck(Console.ReadLine());
                }
            } while (whatCategory > 19);
            
            return categories[whatCategory - 1];
        }

        static void Print(string name, int artNumber, int inventory)
        {
            string artNum = artNumber.ToString();
            string invent = inventory.ToString();
            
            
            Console.WriteLine(name.PadRight(20) + artNum.PadRight(20) + invent);
        }

    }
}