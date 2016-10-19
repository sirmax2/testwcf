using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TestService
{
    public class MessageInspector : IDispatchMessageInspector
    {
        object IDispatchMessageInspector.AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return null;
        }

        void IDispatchMessageInspector.BeforeSendReply(ref Message reply, object correlationState)
        {
            if (!reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                reply.Properties.Add(HttpResponseMessageProperty.Name, new HttpResponseMessageProperty());
            }
            HttpResponseMessageProperty prop = (HttpResponseMessageProperty)reply.Properties[HttpResponseMessageProperty.Name];

            prop.Headers.Add("Server", string.Empty);
            //prop.Headers.Add("Foo", "Bar");
        }
    }

    class TestBehaviorAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher currentDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoint in currentDispatcher.Endpoints)
                {
                    Console.WriteLine("Endpoint: " + endpoint.EndpointAddress);
                    endpoint.DispatchRuntime.MessageInspectors.Add(new MessageInspector());
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
