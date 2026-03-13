using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyProject
{
    public class Program
    {
        Inventory inventroySystem = new Inventory();
        public static void Main()
        {
            Program mainProgram = new Program();
            mainProgram.ProgramOpen();
        }

        public void ProgramOpen()
        {
            while(true){
                Console.WriteLine("What do you want to do: (Add Item|Display Item|Display All Items|Sell Item|Remove Item|Exit)");
                string whatToDo = Console.ReadLine();
                switch (whatToDo)
                {
                    case "Add Item":
                        AddItem();
                        break;
                    case "Display Item":
                        DisplayItem();
                        break;
                    case "Display All Items":
                        DisplayAllItems();
                        break;
                    case "Sell Item":
                        SellItem();
                        break;
                    case "Remove Item":
                        RemoveItem();
                        break;
                    case "Exit":
                        return;
                    default:
                        Console.WriteLine("You did not input a valid instruction. Input again!");
                        break;
                }
            }
        }

        public void AddItem()
        {
            bool isValid = false;
            float itemPriceFloat = 0;
            int itemStockInt = 0;

            Console.WriteLine("Item name to add: ");
            string itemName = Console.ReadLine();
            do
            {
                Console.WriteLine("Item Price: ");
                string itemPriceString = Console.ReadLine();
                isValid = float.TryParse(itemPriceString, out itemPriceFloat);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValid);

            do
            {
                Console.WriteLine("Item Stock: ");
                string itemStockString = Console.ReadLine();
                isValid = int.TryParse(itemStockString, out itemStockInt);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValid);

            inventroySystem.AddNewItemToInventory(itemName, itemPriceFloat, itemStockInt);
        }
    
        public void DisplayItem()
        {
            Console.WriteLine(" ");
            Console.WriteLine("What item are you searching?");
            string itemNameString = Console.ReadLine();
            inventroySystem.DisplayAnItem(itemNameString);
        }

        public void DisplayAllItems()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Displaying all items in Inventory.");
            inventroySystem.DisplayAllItems();
        }
    
        public void SellItem()
        {
            Console.WriteLine(" ");
            Console.WriteLine("What item are you searching?");
            string itemNameString = Console.ReadLine();
            inventroySystem.ItemToSell(itemNameString);
        }

        public void RemoveItem()
        {
            Console.WriteLine(" ");
            Console.WriteLine("What item are you searching?");
            string itemNameString = Console.ReadLine();
            inventroySystem.RemoveItem(itemNameString);
        }
    }
}