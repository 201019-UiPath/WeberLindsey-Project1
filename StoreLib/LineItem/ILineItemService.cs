using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface ILineItemService
    {
        void AddLineItem(LineItem lineItem);
        void DeleteLineItem(LineItem lineItem);
        List<LineItem> GetAllLineItemsByOrderId(int id);
        LineItem GetLineItemByOrderId(int id);
        void UpdateLineItem(LineItem lineItem);
    }
}