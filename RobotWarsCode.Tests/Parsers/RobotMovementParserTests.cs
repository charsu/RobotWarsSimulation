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
   public class RobotMovementParserTests {
      private static readonly CancellationToken _cancellationToken = CancellationToken.None;
      private AutoMock GetMock()
       => AutoMock.GetLoose();

      [Test]
      [TestCase("MMRMMRMRRM")]
      [TestCase("LMLMLMLMM")]
      [TestCase("LMLMLrMLMM")]
      public async Task ParseOutput_OK(string input) {
         var s = GetMock().Create<RobotMovementParser>();

         var r = await s.Parse(input, _cancellationToken) as Robot;

         Assert.IsNotNull(r);
         Assert.IsNull(r.Location);
         Assert.IsNull(r.Direction);
         Assert.IsNotNull(r.Actions);
      }

      [Test]
      [TestCase("rrA")]
      [TestCase("bcR")]
      public async Task ParseOutput_NOT_OK(string input) {
         var s = GetMock().Create<RobotMovementParser>();

         var r = await s.Parse(input, _cancellationToken) as Robot;

         // we failed to create an object
         Assert.IsNull(r);
      }
   }
}
