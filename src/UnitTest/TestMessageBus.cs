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
        [TestMethod]
        public void TestSubscribe()
        {
            var msg = new MessageModel { Name = "Rosen" };
            var messageBus = MessageBus.GetInstance();
            messageBus.Subscribe<MessageModel>(GetMessage);
            messageBus.Emit(msg);
        }

        public void GetMessage(MessageModel message)
        {
            Assert.AreEqual(message.Name, "Rosen");
        }
    }
}
