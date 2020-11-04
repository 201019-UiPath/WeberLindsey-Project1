using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface ILineItemRepo
    {
         void AddLineItem(LineItem lineItem);
         void UpdateLineItem(LineItem lineItem);
         LineItem GetLineItemByOrderId(int id);
         List<LineItem> GetAllLineItemsByOrderId(int id);
         void DeleteLineItem(LineItem lineItem);
    }
}