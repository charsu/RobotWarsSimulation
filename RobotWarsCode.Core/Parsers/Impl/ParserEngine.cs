using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;

namespace RobotWarsCode.Core.Parsers.Impl {
   public class ParserEngine : IParserEngine {
      private readonly IGridParser _gridParser;
      private readonly IRobotCoordonatesParser _robotCoordonatesParser;
      private readonly IRobotMovementParser _robotMovementParser;

      public ParserEngine(IGridParser gridParser, IRobotCoordonatesParser robotCoordonatesParser, IRobotMovementParser robotMovementParser) {
         _gridParser = gridParser;
         _robotCoordonatesParser = robotCoordonatesParser;
         _robotMovementParser = robotMovementParser;
      }

      public async Task<(Grid, List<Robot>)> Parse(List<string> lines, CancellationToken cancellationToken) {
         if (lines == null || lines.Count == 0) {
            throw new ArgumentException("invalid input, missing grid definition");
         }

         // #1 st line is always the grid definition 
         // after that they come in pairs (2 lines) : 
         //    - #1 initial coordonates and heading 
         //    - #2 list of actions to be taken

         var input = new Queue<string>(lines);

         // getting the grid 
         var grid = await _gridParser.Parse(input.Dequeue(), cancellationToken) as Grid;

         // getting the robot states and expectations
         // note : we will use a dictionary in order to facilitate access to the list of models 
         // as we need to access the same model twice in order to fill in both values from 2 diffrent parsers
         var robots = new Dictionary<int, Robot>();
         var idx = -1;
         while (input.Count > 0) {
            idx++;
            var line = input.Dequeue();
            var key = idx / 2;
            // make sure we have the object created for use 
            if (!robots.ContainsKey(key)) {
               robots.Add(key, new Robot());
            }

            var robot = robots[key];
            var parser = (idx % 2 == 0 ? _robotCoordonatesParser as IParser : _robotMovementParser as IParser);
            var model = await parser.Parse(line, cancellationToken) as Robot;

            // we update the model with the new values
            // note : not ideal and in most cases confusing but in this case makes due and makes the code simple.
            robots[key] = robot + model;
         }

         return (grid, robots.Values.ToList());
      }
   }
}
