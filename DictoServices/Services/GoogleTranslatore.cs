using System;
using System.IO;
using System.Net;
using System.Text;
using Dictionary.Dict;
using DictoServices.Data;
using Newtonsoft.Json;

namespace DictoServices.Services
{
    public class GoogleTranslatore
    {
                //string _baseAddress = "http://www.google.com/dictionary/json?callback=dict_api&q={0}&sl={1}&tl={2}&restrict=pr%2Cde&client=te";
        string _baseAddress = "https://clients5.google.com/translate_a/t?client=dict-chrome-ex&sl={0}&tl={1}&q={2}";
        string _soundUrl = "http://www.gstatic.com/dictionary/static/sounds/de/0/{0}.mp3";
#region properties
        public LanguageEnum SL
        {
            get;
            set;
        }

        public LanguageEnum TL
        {
            get;
            set;
        }

        public string Query
        {
            get;
            set;
        }

        public GoogleRequestResult Result
        {
            get;
            set;
        }

#endregion

#region public method
        public void Request()
        {
            string url = String.Format(_baseAddress, this.SL, this.TL, this.Query);

            Result = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (request != null)
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream resp = response.GetResponseStream();
                    if (resp != null)
                    {

                        Encoding fromenc = Encoding.GetEncoding(response.CharacterSet);
                        Encoding toenc = Encoding.Default;
                        
                        StreamReader reader = new StreamReader(resp,fromenc);
                        string resultRequest = reader.ReadToEnd();
                       //resultRequest = ReEncode(fromenc, toenc, resultRequest);
                        
                        TTranslateDictionary dict = JsonConvert.DeserializeObject<TTranslateDictionary>(resultRequest);
                        Result = (GoogleRequestResult)PasreJsonResult(dict, "utf-8");
                        reader.Close();
                        resp.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Result = null;
            }
        }
#endregion

#region private method
        private string GetNormalString(string resultRequest)
        {
            string temp = resultRequest.Trim();
            int index = temp.IndexOf("{");
            StringBuilder str1 = new StringBuilder(temp);
            str1.Remove(0, index);
            temp = str1.ToString();
            index = temp.LastIndexOf("}");
            str1 = new StringBuilder(temp);
            str1.Remove(index + 1, str1.Length - index - 1);
            //str1.Replace("\\x", "");
            temp = str1.ToString();

            return temp;
        }

        private GoogleRequestResult PasreJsonResult(TTranslateDictionary dict,string enc)
        {
            GoogleRequestResult res = new GoogleRequestResult();
            res.Encoding = enc;
            if (dict.Sentences.Length > 0)
            {
                res.Original = dict.Sentences[0].Original;
                //res.Phonetic = dict.Sentences[0].Translit;
                res.UrlSound = string.Format(_soundUrl, res.Original);
            }
            if (dict.Dict.Length > 0)
            {
                foreach (TDictionaryItem item in dict.Dict)
                {
                    res.Translate.Add(item.Position, item.Terms);
                }
            }

            return res;
        }

        private string ReEncode(
            System.Text.Encoding fromEncoding,
            System.Text.Encoding toEncoding,
            string text)
        {

            byte[] frombyte = fromEncoding.GetBytes(text);
            byte[] tobyte = Encoding.Convert(fromEncoding, toEncoding,
                frombyte);
            char[] tochar = new char[toEncoding.GetCharCount(tobyte,0,tobyte.Length)];
            toEncoding.GetChars(tobyte, 0, tobyte.Length, tochar, 0);
            string tostr = new string(tochar);

            return tostr;
        }

#endregion
    }
}