using System;
using System.Collections.Generic;

namespace MyProject
{
    public class Inventory
    {
        List<Item> itemList = new List<Item>();
        float moneyInBank = 0;

        public Inventory(){
            
        }

        public void DisplayAnItem(string itemName)
        {
            int indexForItem = GetSingleProduct(itemName);

            if (indexForItem == -1)
            {
                Console.WriteLine("The item does not exists.");
            }else
            {
                Console.WriteLine("We found the item, here is the details. Name: " + itemList[indexForItem].itemName + " Price: " + itemList[indexForItem].itemCost + " Stock level: " +  itemList[indexForItem].itemStock);
            }
        }

        public void DisplayAllItems()
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                Console.WriteLine("We found an item, here is the details. Name: " + itemList[i].itemName + " Price: " + itemList[i].itemCost + " Stock level: " +  itemList[i].itemStock);
            }

            Console.WriteLine("That is all items in the list.");
        }

        public int GetSingleProduct(string itemName)
        {
            for (int i = 0; i < itemList.Count(); i++)
            {
                if (itemList[i].itemName == itemName)
                {
                    return i;
                }
            }

            return -1;
        }

        public void ItemToSell(string itemName)
        {
            int itemIndex = GetSingleProduct(itemName);

            if (itemIndex == -1)
            {
                Console.WriteLine("The item does not exists in the inventory.");
            }
            else
            {
                Console.WriteLine("Item sold.");
                moneyInBank += itemList[itemIndex].itemCost;
                RemoveItemFromInventory(itemIndex, 1);
            }
        }

        public void RemoveItem(string itemName)
        {
            int itemIndex = GetSingleProduct(itemName);

            if (itemIndex == -1)
            {
                Console.WriteLine("The item does not exists in the inventory.");
            }
            else
            {
                Console.WriteLine("Item removed.");
                RemoveItemFromInventory(itemIndex, itemList[itemIndex].itemStock);
            }
        }

        public void RemoveItemFromInventory(int indexOfItemToRemove, int amountToReduce)
        {
            itemList.RemoveAt(indexOfItemToRemove);
        }

        public void AddNewItemToInventory(string newItemName, float newItemCost, int newItemStock)
        {
            int itemIndex = GetSingleProduct(newItemName);

            if (itemIndex == -1)
            {
                Item newItem = new Item(newItemName, newItemCost, newItemStock);
                itemList.Add(newItem);
                Console.WriteLine("New Item added to the list of inventroy");
            }
            else
            {
                itemList[itemIndex].ChangeStock(newItemStock);
            }
        }
    }
}