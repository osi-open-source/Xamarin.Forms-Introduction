using System;
using System.Collections.Generic;
using System.Text;

namespace PrismMvvm.Services
{
    public class ItemsService : IItemsService
    {
        public IEnumerable<string> GetItems()
        {
            return new List<string>
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
        }
    }
}
