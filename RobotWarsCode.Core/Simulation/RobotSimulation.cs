using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;
using RobotWarsCode.Core.Models.Enums;

namespace RobotWarsCode.Core.Simulation {
   public class RobotSimulation : IRobotSimulation {

      private static Dictionary<Heading, Func<Point, Point>> _movement = new Dictionary<Heading, Func<Point, Point>>() {
         [Heading.E] = (p) => new Point(p.X + 1, p.Y),
         [Heading.N] = (p) => new Point(p.X, p.Y + 1),
         [Heading.W] = (p) => new Point(p.X - 1, p.Y),
         [Heading.S] = (p) => new Point(p.X, p.Y - 1),
      };

      public Task<Robot> Simulate(Grid grid, Robot robot, CancellationToken cancelationToken) {
         var output = new Robot() {
            Actions = robot.Actions,
            Direction = robot.Direction,
            Location = robot.Location
         };

         while ((output?.Actions.Count ?? 0) > 0) {
            cancelationToken.ThrowIfCancellationRequested();

            var action = output.Actions.Dequeue();
            var currentDirection = output.Direction.Value;
            switch (action) {
               // in both cases we take advantage that they have been defined in a sequence 
               case Actions.TurnLeft: {
                     output.Direction = (Heading)(((int)currentDirection + 4 - 1) % 4);
                     break;
                  }
               case Actions.TurnRight: {
                     output.Direction = (Heading)(((int)currentDirection + 4 + 1) % 4);
                     break;
                  }
               case Actions.Move: {
                     // update the location
                     output.Location = _movement[output.Direction.Value].Invoke(output.Location.Value);

                     /// check if we are still within the grid ?!?
                     /// what if we are not as the current definition doesnt define what to do in case of errors
                     if (!grid.Rect.Contains(output.Location.Value)) {

                     }

                     break;
                  }
            }
         }

         return Task.FromResult(output);
      }
   }
}
