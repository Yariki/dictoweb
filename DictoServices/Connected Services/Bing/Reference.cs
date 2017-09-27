﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bing
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TranslateOptions", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class TranslateOptions : object
    {
        
        private string CategoryField;
        
        private string ContentTypeField;
        
        private string GenderFromField;
        
        private string GenderToField;
        
        private bool IncludeMultipleMTAlternativesField;
        
        private string ProfanityActionField;
        
        private string ReservedFlagsField;
        
        private string StateField;
        
        private string UriField;
        
        private string UserField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Category
        {
            get
            {
                return this.CategoryField;
            }
            set
            {
                this.CategoryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ContentType
        {
            get
            {
                return this.ContentTypeField;
            }
            set
            {
                this.ContentTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string GenderFrom
        {
            get
            {
                return this.GenderFromField;
            }
            set
            {
                this.GenderFromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string GenderTo
        {
            get
            {
                return this.GenderToField;
            }
            set
            {
                this.GenderToField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public bool IncludeMultipleMTAlternatives
        {
            get
            {
                return this.IncludeMultipleMTAlternativesField;
            }
            set
            {
                this.IncludeMultipleMTAlternativesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ProfanityAction
        {
            get
            {
                return this.ProfanityActionField;
            }
            set
            {
                this.ProfanityActionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ReservedFlags
        {
            get
            {
                return this.ReservedFlagsField;
            }
            set
            {
                this.ReservedFlagsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Uri
        {
            get
            {
                return this.UriField;
            }
            set
            {
                this.UriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string User
        {
            get
            {
                return this.UserField;
            }
            set
            {
                this.UserField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetTranslationsResponse", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class GetTranslationsResponse : object
    {
        
        private string FromField;
        
        private string StateField;
        
        private Bing.TranslationMatch[] TranslationsField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string From
        {
            get
            {
                return this.FromField;
            }
            set
            {
                this.FromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public Bing.TranslationMatch[] Translations
        {
            get
            {
                return this.TranslationsField;
            }
            set
            {
                this.TranslationsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TranslationMatch", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class TranslationMatch : object
    {
        
        private int CountField;
        
        private string ErrorField;
        
        private int MatchDegreeField;
        
        private string MatchedOriginalTextField;
        
        private int RatingField;
        
        private string TranslatedTextField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Count
        {
            get
            {
                return this.CountField;
            }
            set
            {
                this.CountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int MatchDegree
        {
            get
            {
                return this.MatchDegreeField;
            }
            set
            {
                this.MatchDegreeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string MatchedOriginalText
        {
            get
            {
                return this.MatchedOriginalTextField;
            }
            set
            {
                this.MatchedOriginalTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Rating
        {
            get
            {
                return this.RatingField;
            }
            set
            {
                this.RatingField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string TranslatedText
        {
            get
            {
                return this.TranslatedTextField;
            }
            set
            {
                this.TranslatedTextField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Translation", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class Translation : object
    {
        
        private string OriginalTextField;
        
        private int RatingField;
        
        private int SequenceField;
        
        private string TranslatedTextField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string OriginalText
        {
            get
            {
                return this.OriginalTextField;
            }
            set
            {
                this.OriginalTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int Rating
        {
            get
            {
                return this.RatingField;
            }
            set
            {
                this.RatingField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int Sequence
        {
            get
            {
                return this.SequenceField;
            }
            set
            {
                this.SequenceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string TranslatedText
        {
            get
            {
                return this.TranslatedTextField;
            }
            set
            {
                this.TranslatedTextField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TranslateArrayResponse", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class TranslateArrayResponse : object
    {
        
        private string ErrorField;
        
        private string FromField;
        
        private int[] OriginalTextSentenceLengthsField;
        
        private string StateField;
        
        private string TranslatedTextField;
        
        private int[] TranslatedTextSentenceLengthsField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string From
        {
            get
            {
                return this.FromField;
            }
            set
            {
                this.FromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int[] OriginalTextSentenceLengths
        {
            get
            {
                return this.OriginalTextSentenceLengthsField;
            }
            set
            {
                this.OriginalTextSentenceLengthsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TranslatedText
        {
            get
            {
                return this.TranslatedTextField;
            }
            set
            {
                this.TranslatedTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int[] TranslatedTextSentenceLengths
        {
            get
            {
                return this.TranslatedTextSentenceLengthsField;
            }
            set
            {
                this.TranslatedTextSentenceLengthsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TranslateArray2Response", Namespace="http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class TranslateArray2Response : object
    {
        
        private string AlignmentField;
        
        private string ErrorField;
        
        private string FromField;
        
        private int[] OriginalTextSentenceLengthsField;
        
        private string StateField;
        
        private string TranslatedTextField;
        
        private int[] TranslatedTextSentenceLengthsField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Alignment
        {
            get
            {
                return this.AlignmentField;
            }
            set
            {
                this.AlignmentField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string From
        {
            get
            {
                return this.FromField;
            }
            set
            {
                this.FromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int[] OriginalTextSentenceLengths
        {
            get
            {
                return this.OriginalTextSentenceLengthsField;
            }
            set
            {
                this.OriginalTextSentenceLengthsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TranslatedText
        {
            get
            {
                return this.TranslatedTextField;
            }
            set
            {
                this.TranslatedTextField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int[] TranslatedTextSentenceLengths
        {
            get
            {
                return this.TranslatedTextSentenceLengthsField;
            }
            set
            {
                this.TranslatedTextSentenceLengthsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://api.microsofttranslator.com/V2", ConfigurationName="Bing.LanguageService")]
    public interface LanguageService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/AddTranslation", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/AddTranslationResponse")]
        System.Threading.Tasks.Task AddTranslationAsync(string appId, string originalText, string translatedText, string from, string to, int rating, string contentType, string category, string user, string uri);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/BreakSentences", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/BreakSentencesResponse")]
        System.Threading.Tasks.Task<int[]> BreakSentencesAsync(string appId, string text, string language);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/Detect", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/DetectResponse")]
        System.Threading.Tasks.Task<string> DetectAsync(string appId, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/DetectArray", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/DetectArrayResponse")]
        System.Threading.Tasks.Task<string[]> DetectArrayAsync(string appId, string[] texts);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/GetAppIdToken", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/GetAppIdTokenResponse")]
        System.Threading.Tasks.Task<string> GetAppIdTokenAsync(string appId, int minRatingRead, int maxRatingWrite, int expireSeconds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/GetLanguageNames", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/GetLanguageNamesResponse")]
        System.Threading.Tasks.Task<string[]> GetLanguageNamesAsync(string appId, string locale, string[] languageCodes, bool useSpokenVariant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/GetLanguagesForSpeak", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/GetLanguagesForSpeakRespons" +
            "e")]
        System.Threading.Tasks.Task<string[]> GetLanguagesForSpeakAsync(string appId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/GetLanguagesForTranslate", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/GetLanguagesForTranslateRes" +
            "ponse")]
        System.Threading.Tasks.Task<string[]> GetLanguagesForTranslateAsync(string appId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/GetTranslations", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/GetTranslationsResponse")]
        System.Threading.Tasks.Task<Bing.GetTranslationsResponse> GetTranslationsAsync(string appId, string text, string from, string to, int maxTranslations, Bing.TranslateOptions options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/Translate", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/TranslateResponse")]
        System.Threading.Tasks.Task<string> TranslateAsync(string appId, string text, string from, string to, string contentType, string category, string reservedFlags);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/AddTranslationArray", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/AddTranslationArrayResponse" +
            "")]
        System.Threading.Tasks.Task AddTranslationArrayAsync(string appId, Bing.Translation[] translations, string from, string to, Bing.TranslateOptions options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/GetTranslationsArray", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/GetTranslationsArrayRespons" +
            "e")]
        System.Threading.Tasks.Task<Bing.GetTranslationsResponse[]> GetTranslationsArrayAsync(string appId, string[] texts, string from, string to, int maxTranslations, Bing.TranslateOptions options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/Speak", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/SpeakResponse")]
        System.Threading.Tasks.Task<string> SpeakAsync(string appId, string text, string language, string format, string options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/TranslateArray", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/TranslateArrayResponse")]
        System.Threading.Tasks.Task<Bing.TranslateArrayResponse[]> TranslateArrayAsync(string appId, string[] texts, string from, string to, Bing.TranslateOptions options);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/V2/LanguageService/TranslateArray2", ReplyAction="http://api.microsofttranslator.com/V2/LanguageService/TranslateArray2Response")]
        System.Threading.Tasks.Task<Bing.TranslateArray2Response[]> TranslateArray2Async(string appId, string[] texts, string from, string to, Bing.TranslateOptions options);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public interface LanguageServiceChannel : Bing.LanguageService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.5.0.0")]
    public partial class LanguageServiceClient : System.ServiceModel.ClientBase<Bing.LanguageService>, Bing.LanguageService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public LanguageServiceClient() : 
                base(LanguageServiceClient.GetDefaultBinding(), LanguageServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_LanguageService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(LanguageServiceClient.GetBindingForEndpoint(endpointConfiguration), LanguageServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(LanguageServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(LanguageServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task AddTranslationAsync(string appId, string originalText, string translatedText, string from, string to, int rating, string contentType, string category, string user, string uri)
        {
            return base.Channel.AddTranslationAsync(appId, originalText, translatedText, from, to, rating, contentType, category, user, uri);
        }
        
        public System.Threading.Tasks.Task<int[]> BreakSentencesAsync(string appId, string text, string language)
        {
            return base.Channel.BreakSentencesAsync(appId, text, language);
        }
        
        public System.Threading.Tasks.Task<string> DetectAsync(string appId, string text)
        {
            return base.Channel.DetectAsync(appId, text);
        }
        
        public System.Threading.Tasks.Task<string[]> DetectArrayAsync(string appId, string[] texts)
        {
            return base.Channel.DetectArrayAsync(appId, texts);
        }
        
        public System.Threading.Tasks.Task<string> GetAppIdTokenAsync(string appId, int minRatingRead, int maxRatingWrite, int expireSeconds)
        {
            return base.Channel.GetAppIdTokenAsync(appId, minRatingRead, maxRatingWrite, expireSeconds);
        }
        
        public System.Threading.Tasks.Task<string[]> GetLanguageNamesAsync(string appId, string locale, string[] languageCodes, bool useSpokenVariant)
        {
            return base.Channel.GetLanguageNamesAsync(appId, locale, languageCodes, useSpokenVariant);
        }
        
        public System.Threading.Tasks.Task<string[]> GetLanguagesForSpeakAsync(string appId)
        {
            return base.Channel.GetLanguagesForSpeakAsync(appId);
        }
        
        public System.Threading.Tasks.Task<string[]> GetLanguagesForTranslateAsync(string appId)
        {
            return base.Channel.GetLanguagesForTranslateAsync(appId);
        }
        
        public System.Threading.Tasks.Task<Bing.GetTranslationsResponse> GetTranslationsAsync(string appId, string text, string from, string to, int maxTranslations, Bing.TranslateOptions options)
        {
            return base.Channel.GetTranslationsAsync(appId, text, from, to, maxTranslations, options);
        }
        
        public System.Threading.Tasks.Task<string> TranslateAsync(string appId, string text, string from, string to, string contentType, string category, string reservedFlags)
        {
            return base.Channel.TranslateAsync(appId, text, from, to, contentType, category, reservedFlags);
        }
        
        public System.Threading.Tasks.Task AddTranslationArrayAsync(string appId, Bing.Translation[] translations, string from, string to, Bing.TranslateOptions options)
        {
            return base.Channel.AddTranslationArrayAsync(appId, translations, from, to, options);
        }
        
        public System.Threading.Tasks.Task<Bing.GetTranslationsResponse[]> GetTranslationsArrayAsync(string appId, string[] texts, string from, string to, int maxTranslations, Bing.TranslateOptions options)
        {
            return base.Channel.GetTranslationsArrayAsync(appId, texts, from, to, maxTranslations, options);
        }
        
        public System.Threading.Tasks.Task<string> SpeakAsync(string appId, string text, string language, string format, string options)
        {
            return base.Channel.SpeakAsync(appId, text, language, format, options);
        }
        
        public System.Threading.Tasks.Task<Bing.TranslateArrayResponse[]> TranslateArrayAsync(string appId, string[] texts, string from, string to, Bing.TranslateOptions options)
        {
            return base.Channel.TranslateArrayAsync(appId, texts, from, to, options);
        }
        
        public System.Threading.Tasks.Task<Bing.TranslateArray2Response[]> TranslateArray2Async(string appId, string[] texts, string from, string to, Bing.TranslateOptions options)
        {
            return base.Channel.TranslateArray2Async(appId, texts, from, to, options);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_LanguageService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_LanguageService))
            {
                return new System.ServiceModel.EndpointAddress("http://api.microsofttranslator.com/V2/soap.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return LanguageServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_LanguageService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return LanguageServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_LanguageService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_LanguageService,
        }
    }
}