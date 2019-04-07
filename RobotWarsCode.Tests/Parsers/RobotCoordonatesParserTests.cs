using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RobotWarsCode.Core.Models;
using RobotWarsCode.Core.Parsers.Impl;

namespace RobotWarsCode.Tests.Parsers {
   public class RobotCoordonatesParserTests {
      private static readonly CancellationToken _cancellationToken = CancellationToken.None;
      private AutoMock GetMock()
       => AutoMock.GetLoose();

      [Test]
      [TestCase("1 2 N")]
      [TestCase("10 0 E")]
      [TestCase(" 5 5 W ")]
      public async Task ParseOutput_OK(string input) {
         var s = GetMock().Create<RobotCoordonatesParser>();

         var r = await s.Parse(input, _cancellationToken) as Robot;

         Assert.IsNotNull(r);
         Assert.IsNotNull(r.Location);
         Assert.IsNotNull(r.Direction);
         Assert.IsNull(r.Actions);
      }

      [Test]
      [TestCase("10")]
      [TestCase("10 10")]
      [TestCase("10 10 EE")]
      [TestCase("10 10 Ec")]
      public async Task ParseOutput_NOT_OK(string input) {
         var s = GetMock().Create<RobotCoordonatesParser>();

         var r = await s.Parse(input, _cancellationToken) as Robot;

         // we failed to create an object
         Assert.IsNull(r);
      }
   }
}
