﻿using System.Collections.Generic;
using Newtonsoft.Json;
using TehGM.Wolfringo.Messages.Serialization.Internal;

namespace TehGM.Wolfringo.Messages.Responses
{
    /// <summary>Represents a response for message tips summary request.</summary>
    public class TipSummaryResponse : WolfResponse, IWolfResponse
    {
        /// <summary>Dictionary, where key is message ID and value is a list of tips the message has received.</summary>
        [JsonProperty("body")]
        [JsonConverter(typeof(KeyAndValueDictionaryConverter<long, IEnumerable<WolfTip>>), "charmList")]
        public IReadOnlyDictionary<long, IEnumerable<WolfTip>> Tips { get; private set; }

        [JsonConstructor]
        protected TipSummaryResponse() { }
    }
}
