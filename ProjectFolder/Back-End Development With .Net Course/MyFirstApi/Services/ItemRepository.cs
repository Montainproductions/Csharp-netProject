using MyApi.Models;

namespace MyApi.Services;

public static class ItemRepository
{
    private static List<Item> _items = new()
    {
        new Item { Id = 1, Name = "Learn C#", IsComplete = false },
        new Item { Id = 2, Name = "Build an API", IsComplete = false }
    };

    public static List<Item> GetAll() => _items;

    public static Item? Get(int id) => _items.FirstOrDefault(i => i.Id == id);

    public static void Add(Item item)
    {
        item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
        _items.Add(item);
    }

    public static bool Update(int id, Item updatedItem)
    {
        var existing = Get(id);
        if (existing is null) return false;

        existing.Name = updatedItem.Name;
        existing.IsComplete = updatedItem.IsComplete;
        return true;
    }

    public static bool Delete(int id)
    {
        var item = Get(id);
        if (item is null) return false;
        return _items.Remove(item);
    }
}