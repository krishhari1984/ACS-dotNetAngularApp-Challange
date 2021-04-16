using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACS_dotNetAngularApp.Business.Tests
{
    [TestClass]
    public class BusinessExtenssionsTest
    {
        private IConfiguration _configuration { get; set; }
       
        [TestMethod]
        public void ManageExtenssions_Should_UserServiceExtenssions()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(x => configurationBuilder.Build());
            var result = BusinessExtenssions.AddUserServiceExtenssions(serviceCollection, _configuration);
            Assert.AreEqual(5, result.Count);
        }
    }
}
