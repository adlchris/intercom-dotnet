﻿using NUnit.Framework;
using System;
using Intercom.Core;
using Intercom.Data;
using Intercom.Clients;
using Intercom.Exceptions;
using Intercom.Factories;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Newtonsoft.Json;
using Moq;

namespace Intercom.Test
{
    [TestFixture()]
    public class AdminClientTest : TestBase
    {
        private AdminsClient adminsClient;

        public AdminClientTest()
            : base()
        {
            var auth = new Authentication(AppId, AppKey);
            var restClientFactory = new RestClientFactory(auth);
            adminsClient = new AdminsClient(restClientFactory);
        }

        [Test()]
        public void View_WithEmptyString_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => adminsClient.View(String.Empty));
        }

        [Test()]
        public void View_NoId_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => adminsClient.View(new Admin()));
        }
    }
}