using System.ServiceModel;

namespace TestService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        string hola();
    }
}
