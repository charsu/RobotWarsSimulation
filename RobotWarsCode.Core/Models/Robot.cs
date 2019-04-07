using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using RobotWarsCode.Core.Models.Enums;

namespace RobotWarsCode.Core.Models {
   public class Robot : IModel {
      public Point? Location { get; set; }
      public Heading? Direction { get; set; }
      public Queue<Actions> Actions { get; set; }

      public string GetPositionToString()
         => $"{Location?.X} {Location?.Y} {Direction}";

      /// <summary>
      /// attempts to concatenate the values from 2 isntances by favoring the values from the right side(if available)
      /// </summary>
      /// <param name="a"></param>
      /// <param name="b"></param>
      /// <returns></returns>
      public static Robot operator +(Robot a, Robot b)
         => new Robot() {
            Actions = b.Actions ?? a.Actions,
            Direction = b.Direction ?? a.Direction,
            Location = b.Location ?? a.Location
         };
   }
}
