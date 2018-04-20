using Informer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestMessageBus
    {
        private MessageModel _msg = new MessageModel { Name = "Rosen" };

        [TestMethod]
        public void TestSubscribe()
        {
            var messageBus = MessageBus.GetInstance();
            messageBus.Subscribe<MessageModel>(GetMessage);
            messageBus.Emit(_msg);
        }

        [TestMethod]
        public void TestUnSubscribe()
        {
            var messageBus = MessageBus.GetInstance();
            var token = messageBus.Subscribe<MessageModel>(s =>
            {
                Assert.Fail("This should not be executed due to unsubscribing.");
            });
            messageBus.Unsubscribe(token);
            messageBus.Emit(_msg);
        }

        public void GetMessage(MessageModel message)
        {
            Assert.AreEqual(message.Name, "Rosen");
        }
    }
}
