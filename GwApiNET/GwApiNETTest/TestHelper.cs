using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GwApiNETTest
{

    public static class TestHelper
    {
        public static bool CompareObjects<T>(T expected, T actual)
        {
            PropertyInfo[] properties = typeof (T).GetProperties();
            MemberInfo[] members = typeof (T).GetMembers();
            foreach (var member in members)
            {
                if (member is FieldInfo)
                    CheckMember(member as FieldInfo, expected, actual);
                else if (member is PropertyInfo)
                    CheckMember(member as PropertyInfo, expected, actual);
            }

            return true;
        }

        public static void CheckMember<T>(PropertyInfo member, T expected, T actual)
        {
            string errorString = "Error for member: " + member.Name;
            var expectedVal = member.GetValue(expected);
            var actualVal = member.GetValue(actual);
            if (member.Name == "LastUpdated") return;
            if (member.Name == "Age") return;
            if (member.PropertyType.IsArray)
            {
                Assert.Fail("Cannot verify array values.");
            }
            else if (member.PropertyType.IsPrimitive)
            {
                Assert.AreEqual(expectedVal, actualVal, errorString);
            }
            else if (member.PropertyType == typeof(string))
            {
                Assert.AreEqual(expectedVal, actualVal, errorString);
            }
            else if (member.PropertyType.IsValueType)
            {
                Assert.AreEqual(expectedVal, actualVal, errorString);
            }
            else if (member.PropertyType.IsClass)
            {
                CompareObjects(expectedVal, actualVal);
            }
            Console.WriteLine(member.Name + ": Matches");
        }

        public static void CheckMember<T>(FieldInfo member, T expected, T actual)
        {
            var expectedVal = member.GetValue(expected);
            var actualVal = member.GetValue(actual);
            string errorString = "Error for member: " + member.Name;

            if (member.FieldType.IsArray)
            {
                Assert.Fail("Cannot verify array values.");
            }
            else if (member.FieldType.IsPrimitive)
            {
                Assert.AreEqual(expectedVal, actualVal, errorString);
            }
            else if (member.FieldType == typeof(string))
            {
                Assert.AreEqual(expectedVal, actualVal, errorString);
            }
            else if (member.FieldType.IsValueType)
            {
                Assert.AreEqual(expectedVal, actualVal, errorString);
            }
            else if (member.FieldType.IsClass)
            {
                CompareObjects(expectedVal, actualVal);
            }
            Console.WriteLine(member.Name + ": Matches");
        }
    }
}
