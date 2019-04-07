using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWarsCode.Core {
   public static class IoC {
      // raw dependecy injection that assures that propper objects are setup and service instances in the right order
      // .. to be replaced by a proper framework 

      private static Dictionary<Type, Func<object>> _rawDependencyInjection = new Dictionary<Type, Func<object>>() {
         [typeof(IRobotWarsSimulation)] = () => new RobotWarsSimulation() {

         }
      };

      public static T GetInstance<T>() {
         var key = typeof(T);
         return (T)(_rawDependencyInjection.ContainsKey(key) ? _rawDependencyInjection[key].Invoke() : default(T));
      }
   }
}
