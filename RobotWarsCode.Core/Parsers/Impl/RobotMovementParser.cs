using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;
using RobotWarsCode.Core.Models.Enums;

namespace RobotWarsCode.Core.Parsers.Impl {
   public class RobotMovementParser : IRobotMovementParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<a>[MRL]*)[\s]*$";

      public const string REGEX_EXPRX_ACTIONS = "a";

      internal static Dictionary<char, Actions> mappings = new Dictionary<char, Actions>() {
         ['M'] = Actions.Move,
         ['L'] = Actions.TurnLeft,
         ['R'] = Actions.TurnRight,
      };

      public Task<IModel> Parse(string line, CancellationToken cancellationToken) {
         IModel output = null;

         if (!string.IsNullOrEmpty(line)) {
            var matches = Regex.Matches(line, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               var actions = m.Groups[REGEX_EXPRX_ACTIONS]?.Value?.ToUpperInvariant();

               if (!string.IsNullOrEmpty(actions)) {
                  output = new Robot() {
                     Actions = new Queue<Actions>(actions.Select(c => mappings[c]))
                  };

                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
