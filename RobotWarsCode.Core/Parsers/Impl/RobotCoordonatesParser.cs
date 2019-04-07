using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;
using RobotWarsCode.Core.Models.Enums;

namespace RobotWarsCode.Core.Parsers.Impl {
   public class RobotCoordonatesParser : IRobotCoordonatesParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<x>[0-9]*)[\s](?<y>[0-9]*)[\s](?<d>[NWSE])[\s]*$";

      public const string REGEX_EXPRX_HEADING = "d";
      public const string REGEX_EXPRX_X = "x";
      public const string REGEX_EXPRX_Y = "y";
      public Task<IModel> Parse(string line, CancellationToken cancellationToken) {
         IModel output = null;

         if (!string.IsNullOrEmpty(line)) {
            var matches = Regex.Matches(line, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               var heading = m.Groups[REGEX_EXPRX_HEADING]?.Value;
               var x = m.Groups[REGEX_EXPRX_X]?.Value;
               var y = m.Groups[REGEX_EXPRX_Y]?.Value;

               if (!string.IsNullOrEmpty(heading)
                  && !string.IsNullOrEmpty(x)
                  && !string.IsNullOrEmpty(y)) {

                  output = new Robot() {
                     Location = new System.Drawing.Point(int.Parse(x), int.Parse(y)),
                     Direction = Enum.Parse<Heading>(heading.ToUpperInvariant())
                  };

                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
