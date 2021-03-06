using System;
using System.Linq;
using System.Reflection;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static string[] GetMethodNames(object TestObject)
        {
            if (TestObject == null)
            {
                return new string[0];
            }
            return TestObject.GetType()
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Select(s => s.Name)
                .ToArray();
        }

        public static string InvokeMethod(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return typeName;
            }

            Type Type = Type.GetType(typeName, false);
            if (Type == null)
            {
                return null;
            }

            object Object = null;

            for (int i = 0; Object == null; i++)
            {
                try
                {
                    Object = Activator.CreateInstance(Type, new object[i]);
                }
                catch (Exception e) { }
            }

            return Type.GetMethods()[0].Invoke(Object, null).ToString();
        }
    }
}