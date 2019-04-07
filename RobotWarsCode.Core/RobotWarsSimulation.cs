using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RobotWarsCode.Core {
   public class RobotWarsSimulation : IRobotWarsSimulation {
      public async Task<List<string>> RunSimulation(List<string> input, CancellationToken cancellationToken) {
         var output = new List<string>();
         // parse the input 
         // #1 is the grid definition
         // #2 , #3  are the robots initial and movement commands
         // .... 


         // foreach robot run simulation and set output 


         return output;
      }

      #region IDisposable 
      public void Dispose() {

      }
      #endregion
   }
}
