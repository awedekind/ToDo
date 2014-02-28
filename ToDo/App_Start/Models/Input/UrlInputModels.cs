using FubuCore;

namespace ToDo.Models.Input
{
    public interface IRavenId
    {
        string IdType { get; set; }
        string Id { get; set; }
    }

    public class DutyPageInput : IRavenId
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
i
