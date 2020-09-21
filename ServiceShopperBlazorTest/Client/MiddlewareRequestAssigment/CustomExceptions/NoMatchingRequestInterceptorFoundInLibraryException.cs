using System;
using System.Runtime.Serialization;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    [Serializable]
    internal class NoMatchingRequestInterceptorFoundInLibraryException : Exception
    {
        public NoMatchingRequestInterceptorFoundInLibraryException()
        {
        }

        public NoMatchingRequestInterceptorFoundInLibraryException(string message) : base(message)
        {
        }

        public NoMatchingRequestInterceptorFoundInLibraryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoMatchingRequestInterceptorFoundInLibraryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}