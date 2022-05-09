using Newtonsoft.Json;

namespace SecretServerCLI.API.Models
{
    public class SecretItem
    {
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("fileAttachmentId")]
        public object FileAttachmentId { get; set; }

        [JsonProperty("filename")]
        public object Filename { get; set; }

        [JsonProperty("itemValue")]
        public string ItemValue { get; set; }

        [JsonProperty("fieldId")]
        public int FieldId { get; set; }

        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("fieldDescription")]
        public string FieldDescription { get; set; }

        [JsonProperty("isFile")]
        public bool IsFile { get; set; }

        [JsonProperty("isNotes")]
        public bool IsNotes { get; set; }

        [JsonProperty("isPassword")]
        public bool IsPassword { get; set; }
    }
}