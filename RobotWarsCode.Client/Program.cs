using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core;

namespace RobotWarsCode {
   class Program {
      static void Main(string[] args) {
         var ctoken = new CancellationToken();
         MainAsync(ctoken).GetAwaiter().GetResult();
      }

      static async Task MainAsync(CancellationToken cancellationToken) {
         var input = new List<string>();
         var output = new List<string>();

         // get the user's input (part of the consumer application)
         string line;
         while (!string.IsNullOrWhiteSpace(line = Console.ReadLine())) {
            // Do whatever you want here with line
            input.Add(line);
         }

         // push the input to be processed 
         using (var service = IoC.GetInstance<IRobotWarsSimulation>()) {
            output = await service.RunSimulation(input, cancellationToken);
         }

         // print output ?!?
         output?.ForEach(o => Console.WriteLine(o));
      }
   }
}
