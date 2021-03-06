﻿using System.Collections.Generic;

namespace DictoServices.Data
{
    public class TranslateRequestResult
    {
        public TranslateRequestResult()
        {
            Translate = new Dictionary<string, string[]>();
        }
    	
        public string Original
        {
            get;
            set;
        }

        public Dictionary<string, string[]> Translate
        {
            get;
            set;
        }

        public string Phonetic
        {
            get;
            set;
        }

        public string UrlSound
        {
            get;
            set;
        }


        public string Encoding
        {
            get;
            set;
        }

        public bool IsExisting { get; set; }
    }
}