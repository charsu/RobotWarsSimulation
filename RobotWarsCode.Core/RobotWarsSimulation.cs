using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Parsers;
using RobotWarsCode.Core.Simulation;

namespace RobotWarsCode.Core {
   public class RobotWarsSimulation : IRobotWarsSimulation {
      private readonly IParserEngine _parserEngine;
      private readonly IRobotSimulation _robotSimulation;

      public RobotWarsSimulation(IParserEngine parserEngine, IRobotSimulation robotSimulation) {
         _parserEngine = parserEngine;
         _robotSimulation = robotSimulation;
      }

      public async Task<List<string>> RunSimulation(List<string> input, CancellationToken cancellationToken) {
         var output = new List<string>();

         // parse the input 
         var (grid, robots) = await _parserEngine.Parse(input, cancellationToken);


         // foreach robot run simulation and set output 
         robots?.ForEach(async r => {
            var simulatedRobot = await _robotSimulation.Simulate(grid, r, cancellationToken);
            output.Add(simulatedRobot.GetPositionToString());
         });

         return output;
      }

      #region IDisposable 
      public void Dispose() {

      }
      #endregion
   }
}
