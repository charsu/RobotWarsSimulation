using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RobotWarsCode.Core.Models;

namespace RobotWarsCode.Core.Parsers.Impl {
   public class GridParser : IGridParser {
      /// <summary>
      /// reg ex with named capture group for quick extraction 
      /// </summary>
      public const string REGEX_EXPR = @"^[\s]*(?<w>[0-9]*)[\s](?<h>[0-9]*)[\s]*$";
      public const string REGEX_EXPRX_HEIGHT = "h";
      public const string REGEX_EXPRX_WIDTH = "w";

      public Task<IModel> Parse(string input, CancellationToken cancellationToken) {
         IModel output = null;

         if (!string.IsNullOrEmpty(input)) {
            var matches = Regex.Matches(input, REGEX_EXPR, RegexOptions.IgnoreCase);
            foreach (Match m in matches) {
               var height = m.Groups[REGEX_EXPRX_HEIGHT]?.Value;
               var width = m.Groups[REGEX_EXPRX_WIDTH]?.Value;

               if (!string.IsNullOrEmpty(height)
                  && !string.IsNullOrEmpty(width)) {

                  output = new Grid() {
                     Rect = new System.Drawing.Rectangle(0, 0, int.Parse(width), int.Parse(height))
                  };

                  break;
               }
            }
         }

         return Task.FromResult(output);
      }
   }
}
