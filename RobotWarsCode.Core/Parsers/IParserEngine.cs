using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;

namespace RobotWarsCode.Core.Parsers {
   public interface IParserEngine {
      Task<(Grid, List<Robot>)> Parse(List<string> lines, CancellationToken cancellationToken);
   }
}
