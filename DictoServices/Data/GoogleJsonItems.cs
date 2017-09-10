using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Dictionary.Dict
{
    /// <summary>
    /// items for dictionary json
    /// </summary>
    [JsonObject]
    class GTextItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("labels")]
        public GLabelItem[] Labels { get; set; }
    }

    [JsonObject]
    class GMeaningItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("terms")]
        public GTextItem[] Terms {get;set;}
    }

    [JsonObject]
    class GWebDefItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("terms")]
        public GTextItem[] Terms { get; set; }
        [JsonProperty("entries")]
        public GMeaningItem[] Entries { get; set; } 
    }

    [JsonObject]
    class GLabelItem
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    [JsonObject]
    class GContainerItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("labels")]
        public GLabelItem[] Labels { get; set; }
        [JsonProperty("entries")]
        public GMeaningItem[] Entries { get; set; }
    }

    [JsonObject]
    class GPrimarieItem
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("terms")]
        public GTextItem[] Terms { get; set; }
        [JsonProperty("entries")]
        public GContainerItem[] Entries { get; set; }
    }

    [JsonObject]
    class GDictionary
    {
        [JsonProperty("query")]
        public string Query { get; set; }
        [JsonProperty("sourceLanguage")]
        public string SourceLanguage { get; set; }
        [JsonProperty("targetLanguage")]
        public string TargetLanguage { get; set; }
        [JsonProperty("primaries")]
        public GPrimarieItem[] Primaries { get; set; }
        [JsonProperty("webDefinitions")]
        public GWebDefItem[] WebDefinitions { get; set; }
    }


    // items for translate json
    //
    [JsonObject]
    class TSentanceItem
    {
        [JsonProperty("trans")]
        public string Translation { get; set; }
        [JsonProperty("orig")]
        public string Original { get; set; }
        [JsonProperty("translit")]
        public string Translit { get; set; }
        [JsonProperty("src_translit")]
        public string SourceTranslit { get; set; }
    }
    [JsonObject]
    class TDictionaryItem
    {
        [JsonProperty("pos")]
        public string Position { get; set; }
        [JsonProperty("terms")]
        public string[] Terms { get; set; }
    }
    [JsonObject]
    class TLD_Result
    {
        [JsonProperty("srclangs")]
        public string[] SrcLangs { get; set; }
        [JsonProperty("srclangs_confidences")]
        public double[] SrcLangConfidence { get; set; }
    }

    // main object for translate
    [JsonObject]
    class TTranslateDictionary
    {
        [JsonProperty("sentences")]
        public TSentanceItem[] Sentences { get; set; }
        [JsonProperty("dict")]
        public TDictionaryItem[] Dict { get; set; }
        [JsonProperty("src")]
        public string Src { get; set; }
        [JsonProperty("ld_result")]
        public TLD_Result LD_Result { get; set; }
        [JsonProperty("server_time")]
        public double Server_Time { get; set; }
    }
}
