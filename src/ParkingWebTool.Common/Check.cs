using System;
using System.Diagnostics;
using ParkingWebTool.Common.Properties;

namespace ParkingWebTool.Common
{
    [DebuggerStepThrough]
    public static class Check
    {
        public static void ForNullReference<TObj>(TObj obj, string param = null, string message = null)
            where TObj : class
        {
            if (null == obj) throw new ArgumentNullException(Resources.Exc_NullArgument);
        }

        public static void ForEmptyString(string obj, string param = null, string message = null)
        {
            if (String.IsNullOrWhiteSpace(obj)) throw new ArgumentNullException(Resources.Exc_NullArgument);
        }

        public static void WhetherObjectInherits<TParent>(object obj, string param = null, string message = null)
        {
            if (!obj.GetType().IsAssignableFrom(typeof(TParent)))
                throw new ArgumentException(String.Format(Resources.Exc_InheritanceRequired_Frmt, typeof(TParent).FullName), param);
        }

        public static void WhetherObjectDoesNotInherit<TParent>(object obj, string param = null, string message = null)
        {
            if (!obj.GetType().IsAssignableFrom(typeof(TParent)))
                throw new ArgumentException(String.Format(Resources.Exc_InheritanceDoesNotAllowed_Frmt, typeof(TParent).FullName), param);
        }
    }
}
