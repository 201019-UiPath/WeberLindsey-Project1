using StoreDB.Repos;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreLib
{
    public class InventoryService : IInventoryService
    {
        private IInventoryItemRepo repo;

        public InventoryService(IInventoryItemRepo repo)
        {
            this.repo = repo;
        }

        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            repo.AddInventoryItem(inventoryItem);
        }

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            repo.UpdateInventoryItem(inventoryItem);
        }

        public InventoryItem GetInventoryItemById(int id)
        {
            InventoryItem item = repo.GetInventoryItemById(id);
            return item;
        }

        public List<InventoryItem> GetAllInventoryItemsById(int id)
        {
            List<InventoryItem> items = repo.GetAllInventoryItemsById(id);
            return items;
        }

        public InventoryItem GetInventoryItemByLocationId(int id)
        {
            InventoryItem item = repo.GetInventoryItemByLocationId(id);
            return item;
        }

        public List<InventoryItem> GetAllInventoryItemsByLocationId(int id)
        {
            List<InventoryItem> items = repo.GetAllInventoryItemsByLocationId(id);
            return items;
        }

        public void DeleteInventoryItem(InventoryItem inventoryItem)
        {
            repo.DeleteInventoryItem(inventoryItem);
        }

        public InventoryItem GetItemByLocationIdBookId(int locationId, int bookId)
        {
            InventoryItem item = repo.GetItemByLocationIdBookId(locationId, bookId);
            return item;
        }
    }
}