using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models.Output
{
    public class ListJsonResponse<T>
    {
        public IList<T> Items { get; set; }
    }

    public class ItemJsonResponse<T>
    {
        public T Item { get; set; }
    }

    public class IdJsonOutput
    {
        public string Id { get; set; }
    }
}
