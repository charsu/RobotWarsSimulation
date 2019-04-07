using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;

namespace RobotWarsCode.Core.Simulation {
   public interface IRobotSimulation {
      Task<Robot> Simulate(Grid rid, Robot robot, CancellationToken cancelationToken);
   }
}
