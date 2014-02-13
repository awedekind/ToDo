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

    //public class TestClass : one<int>, one
    //{
    //    public TestClass(int cost)
    //    {
    //        Cost = cost;
    //    }

    //    public int Cost { get; private set; }

    //    object one.Cost
    //    {
    //        get { return Cost; }
    //    }
    //}

    //public class Example
    //{
    //    public Example()
    //    {
    //        var list = new List<one>();
    //        var test = new TestClass(10);
    //        one<int> a = test;
    //        one b = test;
    //        list.Add(b);
    //        list.Add(test);

    //    }
    //}


    //public interface one<T>
    //{
    //    T Cost { get; }
    //}

    //public interface one
    //{
    //    object Cost { get; }
    //}
}