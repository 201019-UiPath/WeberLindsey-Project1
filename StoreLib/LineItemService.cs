using StoreDB.Repos;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreLib
{
    public class LineItemService
    {
        private ILineItemRepo repo;

        public LineItemService(ILineItemRepo repo) {
            this.repo = repo;
        }

        public void AddLineItem(LineItem lineItem) {
            repo.AddLineItem(lineItem);
        }
        public void UpdateLineItem(LineItem lineItem) {
             repo.UpdateLineItem(lineItem);
         }
        public LineItem GetLineItemByOrderId(int id) {
             LineItem item = repo.GetLineItemByOrderId(id);
             return item;
         }
        public List<LineItem> GetAllLineItemsByOrderId(int id) {
             List<LineItem> items = repo.GetAllLineItemsByOrderId(id);
             return items;
         }
        public void DeleteLineItem(LineItem lineItem) {
             repo.DeleteLineItem(lineItem);
         }
    }
}