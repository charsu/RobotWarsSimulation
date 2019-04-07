using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RobotWarsCode.Core.Models;
using RobotWarsCode.Core.Parsers;
using RobotWarsCode.Core.Parsers.Impl;

namespace RobotWarsCode.Tests.Parsers {
   public class GridParserTests {
      private static readonly CancellationToken _cancellationToken = CancellationToken.None;
      private AutoMock GetMock()
       => AutoMock.GetLoose();

      [Test]
      [TestCase("10 10")]
      [TestCase("10 30 ")]
      [TestCase(" 5 5")]
      public async Task ParseOutput_OK(string input) {
         var s = GetMock().Create<GridParser>();

         var r = await s.Parse(input, _cancellationToken) as Grid;
         Assert.IsNotNull(r);
         Assert.IsNotNull(r.Rect);
         Assert.IsTrue(!r.Rect.IsEmpty);
         Assert.IsTrue(r.Rect.Width > 0);
         Assert.IsTrue(r.Rect.Height > 0);
      }
   }
}
