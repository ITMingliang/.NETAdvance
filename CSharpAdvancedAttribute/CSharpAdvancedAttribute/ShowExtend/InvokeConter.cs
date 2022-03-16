using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ShowExtend
{
   public static class InvokeConter
    {
        public static void InvokeManager<T>( this T showTest) where T:new()
        {
            Type type = showTest.GetType();
            if (type.IsDefined(typeof(ShowAttribute),true))
            {
                //在类上面查找特性
                object[] attributes=type.GetCustomAttributes(typeof(ShowAttribute), true);
                foreach (ShowAttribute attribute in attributes)
                {
                    attribute.Show();
                }
                //在方法上查找
                foreach (MethodInfo method in type.GetMethods())
                {
                    if (method.IsDefined(typeof(ShowAttribute), true))
                    {
                        object[] attributeMethods = method.GetCustomAttributes(typeof(ShowAttribute), true);
                        foreach (ShowAttribute attribute in attributeMethods)
                        {
                            attribute.Show();
                        }
                    }
                }

                //在属性上查找
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.IsDefined(typeof(ShowAttribute), true))
                    {
                        object[] attributeProperty = property.GetCustomAttributes(typeof(ShowAttribute), true);
                        foreach (ShowAttribute attribute in attributeProperty)
                        {
                            attribute.Show();
                        }
                    }
                }

                //在字段上查找
                foreach (FieldInfo field in type.GetFields())
                {
                    if (field.IsDefined(typeof(ShowAttribute), true))
                    {
                        object[] attributeField = field.GetCustomAttributes(typeof(ShowAttribute), true);
                        foreach (ShowAttribute attribute in attributeField)
                        {
                            attribute.Show();
                        }
                    }
                }


            }
        }

    }
}
