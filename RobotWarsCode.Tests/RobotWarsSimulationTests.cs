using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using RobotWarsCode.Core;
using RobotWarsCode.Tests;

namespace Tests {
   public class RobotWarsSimulationTests {
      private static readonly CancellationToken _cancellationToken = CancellationToken.None;

      [Test, Category(Config.Integration)]
      public async Task Run2Robots_On5x5Grid_OK() {
         var input = Get2RobotsOn5x5GridDataInput();

         var service = IoC.GetInstance<IRobotWarsSimulation>();

         var output = await service.RunSimulation(input, _cancellationToken);

         Assert.AreEqual(Get2RobotsOn5x5GridDataOuput(), output);
      }

      #region test data 

      internal List<string> Get2RobotsOn5x5GridDataInput()
         => new List<string>(){
            "5 5",
            "1 2 N",
            "LMLMLMLMM",
            "3 3 E",
            "MMRMMRMRRM"
         };

      internal List<string> Get2RobotsOn5x5GridDataOuput()
         => new List<string>(){
          "1 3 N",
          "5 1 E"
         };

      #endregion
   }
}