using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuCore;

namespace ToDo.Models.Input
{
    public interface IRavenId
    {
        string IdType { get; set; }
        string Id { get; set; }
    }

    public class UrlSaveUpdateInputModel : IRavenId
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string IdType { get; set; }
        public string Status { get; set; }
    }

    public class UrlIdInputModel : IRavenId
    {
        public string IdType { get; set; }
        public string Id { get; set; }
    }

    public static class Extensions
    {
        public static string GetId(this IRavenId instance)
        {
            return "{0}/{1}".ToFormat(instance.IdType, instance.Id);
        }
    }
}