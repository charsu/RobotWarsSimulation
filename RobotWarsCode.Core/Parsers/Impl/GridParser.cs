using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;

namespace RobotWarsCode.Core.Parsers.Impl {
   public class GridParser : IGridParser {
      public Task<IModel> Parse(string line, CancellationToken cancellationToken) {
         return null;
      }
   }
}
