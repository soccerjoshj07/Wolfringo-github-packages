﻿using System;

namespace TehGM.Wolfringo.Messages.Responses
{
    public static class ResponseTypeResolverExtensions
    {
        /// <summary>Gets response type for the message.</summary>
        /// <typeparam name="TFallbackType">Type of response to use as fallback.</typeparam>
        /// <param name="message">Sent message.</param>
        /// <returns>Type of the response.</returns>
        public static Type GetMessageResponseType<TFallbackType>(this IResponseTypeResolver resolver, IWolfMessage message) where TFallbackType : IWolfResponse
            => resolver.GetMessageResponseType(message.GetType(), typeof(TFallbackType));
    }
}
