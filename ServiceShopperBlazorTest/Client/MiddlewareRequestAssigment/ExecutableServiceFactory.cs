using System;
using System.Linq;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public class ExecutableServiceFactory
    {
        public IExecutableService GetServiceByAssigment(ServiceAssigment assigment)
        {
            return ExecuteableAssigmentLibrary.ServiceAssigments.First
                (s => s.RequestHeaderId == assigment.RequestHeaderId).service;
        }
    }
}