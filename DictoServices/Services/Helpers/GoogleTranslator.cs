using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dictionary.Dict;
using DictoData.Model;
using DictoInfrasctructure.Enums;
using DictoServices.Base;
using DictoServices.Data;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DictoServices.Services.Helpers
{
    public class GoogleTranslator : CoreTranslator
    {
        string _baseAddress = "https://clients5.google.com/translate_a/t?client=dict-chrome-ex&sl={0}&tl={1}&q={2}";
        string _soundUrl = "https://www.gstatic.com/dictionary/static/sounds/de/0/{0}.mp3";

        public GoogleTranslator(ILogger logger, Language source, Language target, string query)
            :base(logger,source,target,query)
        {

        }

#region public method
        public override async Task<TranslateRequestResult> Request()
        {
            string url = String.Format(_baseAddress, _soundUrl, Target, Query);
            TranslateRequestResult result = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                if (request != null)
                {
                    var response = await request.GetResponseAsync();
                    var webResponse = (HttpWebResponse) response;
                    if (webResponse == null)
                    {
                        return null;
                    }
                    Stream resp = webResponse.GetResponseStream();
                    if (resp != null)
                    {
                        Encoding fromenc = Encoding.GetEncoding(webResponse.CharacterSet);
                        Encoding toenc = Encoding.Default;
                        
                        StreamReader reader = new StreamReader(resp,fromenc);
                        string resultRequest = reader.ReadToEnd();
                        
                        TTranslateDictionary dict = JsonConvert.DeserializeObject<TTranslateDictionary>(resultRequest);
                        result  = (TranslateRequestResult)PasreJsonResult(dict, "utf-8");
                        reader.Close();
                        resp.Close();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                
            }
            return null;
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

        private TranslateRequestResult PasreJsonResult(TTranslateDictionary dict,string enc)
        {
            TranslateRequestResult res = new TranslateRequestResult();
            res.Encoding = enc;
            if (dict.Sentences.Length > 0)
            {
                res.Original = dict.Sentences[0].Original;
                //res.Phonetic = dict.Sentences[0].Translit;
                res.UrlSound = string.Format(_soundUrl, res.Original);
            }
            if (dict.Dict != null && dict.Dict.Length > 0)
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