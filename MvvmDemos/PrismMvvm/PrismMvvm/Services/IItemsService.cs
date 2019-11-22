using System;
using System.Collections.Generic;
using System.Text;

namespace PrismMvvm.Services
{
    public interface IItemsService
    {
        IEnumerable<string> GetItems();
    }
}
