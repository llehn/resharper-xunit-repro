using System;
using System.Linq;

namespace Lol.Utils.Extensions
{
    /// <summary>
    /// Extensions for TypeInfo
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// This method returns true if the type implements a specified interface
        /// </summary>
        /// <param name="t">TypeInfo</param>
        /// <param name="iface">Interface type</param>
        /// <returns>true of false</returns>
        public static bool ImplementsInterface(this Type t, Type iface)
        {
            if (!iface.ContainsGenericParameters)
            {
                return t.GetInterfaces().Contains(iface);
            }

            var g = iface.GetGenericTypeDefinition();
            return t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == g);
        }

        /// <summary>
        /// Returns instance of an attribute of a given type
        /// </summary>
        /// <typeparam name="T">Type of the Attribute</typeparam>
        /// <param name="type">type</param>
        /// <returns>attrbute instance</returns>
        public static T GetAttribute<T>(this Type type) where T : Attribute =>
            (T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault();

        /// <summary>
        /// Returns instance of an attribute of a given type
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="attributeType">attribute type</param>
        /// <returns>attrbute instance</returns>
        public static object GetAttribute(this Type type, Type attributeType) =>
            type.GetCustomAttributes(attributeType, true).FirstOrDefault();
    }
}
