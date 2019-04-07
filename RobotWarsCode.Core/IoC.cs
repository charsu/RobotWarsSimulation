using System;
using System.Collections.Generic;
using System.Text;
using RobotWarsCode.Core.Parsers;
using RobotWarsCode.Core.Parsers.Impl;
using RobotWarsCode.Core.Simulation;

namespace RobotWarsCode.Core {
   public static class IoC {
      // raw dependecy injection that assures that propper objects are setup and service instances in the right order
      // .. to be replaced by a proper framework 

      private static Dictionary<Type, Func<object>> _rawDependencyInjection = new Dictionary<Type, Func<object>>() {
         [typeof(IRobotWarsSimulation)] = ()
            => new RobotWarsSimulation(GetInstance<IParserEngine>(), GetInstance<IRobotSimulation>()),
         [typeof(IRobotSimulation)] = ()
            => new RobotSimulation(),
         // we have cut a few corners here but we dont expect these parsers to change in terms of depencies
         [typeof(IParserEngine)] = ()
            => new ParserEngine(new GridParser(), new RobotCoordonatesParser(), new RobotMovementParser()),
      };

      public static T GetInstance<T>() {
         var key = typeof(T);
         return (T)(_rawDependencyInjection.ContainsKey(key) ? _rawDependencyInjection[key].Invoke() : default(T));
      }
   }
}
