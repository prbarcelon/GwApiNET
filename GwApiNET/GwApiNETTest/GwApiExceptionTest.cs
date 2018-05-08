using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwApiNET;
using NUnit.Framework;

namespace GwApiNETTest
{
    public class GwApiExceptionTest
    {
        Exception innerException;

        [TestFixtureSetUp]
        public void GwApiExceptionTestFixture()
        {
            innerException = new InvalidOperationException();
        }

        [TestCase("PANDAS SHALL RULE THE WORLD!!!!!!")]
        public void GwApiExceptionInputTest1(string message)
        {
            GwApiException gwApiException = new GwApiException(message, innerException);
            Assert.AreEqual(message, gwApiException.Message);
            Assert.AreEqual(innerException, gwApiException.InnerException);
        }

        [TestCase("OBEY YOUR PANDA OVERLORDS!!!", "THIS IS NOT A SUGGESTION!")]
        public void GwApiExceptionInputTest2(string message, string suggestion)
        {
            GwApiException gwApiException = new GwApiException(message, suggestion, innerException);
            Assert.AreEqual(message, gwApiException.Message);
            Assert.AreEqual(suggestion, gwApiException.Suggestion);
            Assert.AreEqual(innerException, gwApiException.InnerException);
        }

        [TestCase("LOVE THY PANDA LIKE YOU LOVE YOUR OWN PANDA!","YOU LIE! I AM THE TRUE PANDA!")]
        public void GwApiExceptionInputTest3(string message, string responseError)
        {
            GwApiException gwApiException = new GwApiException(message, responseError);
            Assert.AreEqual(message, gwApiException.Message);
            Assert.AreEqual(responseError, gwApiException.ResponseError);
        }
    }
}
