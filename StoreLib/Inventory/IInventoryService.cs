using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IInventoryService
    {
        void AddInventoryItem(InventoryItem inventoryItem);
        void DeleteInventoryItem(InventoryItem inventoryItem);
        List<InventoryItem> GetAllInventoryItemsById(int id);
        List<InventoryItem> GetAllInventoryItemsByLocationId(int id);
        InventoryItem GetInventoryItemById(int id);
        InventoryItem GetInventoryItemByLocationId(int id);
        InventoryItem GetItemByLocationIdBookId(int locationId, int bookId);
        void UpdateInventoryItem(InventoryItem inventoryItem);
    }
}