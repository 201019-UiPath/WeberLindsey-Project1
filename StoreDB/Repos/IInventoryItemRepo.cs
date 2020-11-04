using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface IInventoryItemRepo
    {
         void AddInventoryItem(InventoryItem inventoryItem);
         void UpdateInventoryItem(InventoryItem inventoryItem);
         InventoryItem GetInventoryItemById(int id);
         List<InventoryItem> GetAllInventoryItemsById(int id);
         InventoryItem GetInventoryItemByLocationId(int id);
         List<InventoryItem> GetAllInventoryItemsByLocationId(int id);
         void DeleteInventoryItem(InventoryItem inventoryItem);
         InventoryItem GetItemByLocationIdBookId(int locationId, int bookId);
    }
}