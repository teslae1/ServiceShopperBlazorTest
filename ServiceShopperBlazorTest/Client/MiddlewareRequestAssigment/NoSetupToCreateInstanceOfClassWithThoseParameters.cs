using System;
using System.Runtime.Serialization;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    [Serializable]
    internal class NoSetupToCreateInstanceOfClassWithThoseParameters : Exception
    {
        public NoSetupToCreateInstanceOfClassWithThoseParameters()
        {
        }

        public NoSetupToCreateInstanceOfClassWithThoseParameters(string message) : base(message)
        {
        }

        public NoSetupToCreateInstanceOfClassWithThoseParameters(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSetupToCreateInstanceOfClassWithThoseParameters(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}