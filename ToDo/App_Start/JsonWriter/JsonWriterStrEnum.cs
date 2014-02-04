using FubuMVC.Core.Runtime;
using HtmlTags;
using Newtonsoft.Json;

namespace ToDo.JsonWriter
{
    public class JsonWriterStrEnum : IJsonWriter
    {
        private readonly IOutputWriter _outputWriter;

        public JsonWriterStrEnum(IOutputWriter outputWriter)
        {
            this._outputWriter = outputWriter;
        }

        public void Write(object output)
        {
            this.Write(output, MimeType.Json.ToString());
        }

        public void Write(object output, string mimeType)
        {
            
            this._outputWriter.Write(mimeType, JsonConvert.SerializeObject(output));

        }
    }
}
