using System;

namespace TestService
{
    [TestBehavior]
    public class TestService : ITestService
    {
        public string hola()
        {
            return "HOLA";
        }
    }
}
