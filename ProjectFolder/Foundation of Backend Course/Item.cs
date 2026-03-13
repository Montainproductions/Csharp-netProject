namespace MyProject
{
    public class Item
    {
        public string itemName;
        public float itemCost;
        public int itemStock;
        public Item(string newItemName, float newItemCost, int newItemStock){
            itemName = newItemName;
            itemCost = newItemCost;
            itemStock = newItemStock;
        }

        public void ChangeStock(int stockDifference)
        {
            itemStock += stockDifference;
        }
    }
}