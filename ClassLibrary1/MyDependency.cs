using Azure.Messaging.ServiceBus;

namespace ClassLibrary1
{
    public class MyDependency
    {
        private readonly ServiceBusClient sb;

        public MyDependency(ServiceBusClient sb)
        {
            this.sb = sb;
        }
    }
}