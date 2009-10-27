﻿using System;
using System.Runtime.Serialization;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using ServiceStack.LogicFacade;
using ServiceStack.ServiceHost.Tests.Support;

namespace ServiceStack.ServiceHost.Tests
{
	[TestFixture]
	public class ServiceHostTests
	{
	
		[Test]
		public void Can_execute_BasicService()
		{
			var serviceController = new ServiceController();

			serviceController.Register(() => new BasicService());
			var result = serviceController.Execute(new BasicRequest()) as BasicRequest;

			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public void Can_execute_BasicService_from_dynamic_Type()
		{
			var requestType = typeof(BasicRequest);

			var serviceController = new ServiceController();
			serviceController.Register(requestType, typeof(BasicService));

			object request = Activator.CreateInstance(requestType);

			var result = serviceController.Execute(request) as BasicRequest;

			Assert.That(result, Is.Not.Null);
		}

	}
}