using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using NUnit.Framework;
using RobotWarsCode.Core.Models;
using RobotWarsCode.Core.Simulation;
using static RobotWarsCode.Core.Models.Enums.Actions;

namespace RobotWarsCode.Tests.Simulation {
   public class RobotSimulationTests {
      private static readonly CancellationToken _cancellationToken = CancellationToken.None;
      private AutoMock GetMock()
       => AutoMock.GetLoose();

      [Test]
      public async Task Simulate_RobotMoment_OK() {
         var s = GetMock().Create<RobotSimulation>();

         var grid = new Grid() { Rect = new System.Drawing.Rectangle(0, 0, 5, 5) };
         var robot = new Robot() {
            Location = new System.Drawing.Point(3, 3),
            Direction = Core.Models.Enums.Heading.E,
            Actions = new Queue<Core.Models.Enums.Actions>(new[]{
               Move,
               Move,
               TurnRight,
               Move,
               Move,
               TurnRight,
               Move,
               TurnRight,
               TurnRight,
               Move
            })
         };

         var r = await s.Simulate(grid, robot, _cancellationToken);

         Assert.AreEqual("5 1 E", r.GetPositionToString());
      }
   }
}
