using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RobotWarsCode.Core {
   public interface IRobotWarsSimulation : IDisposable {
      Task<List<string>> RunSimulation(List<string> input, CancellationToken cancellationToken);
   }
}