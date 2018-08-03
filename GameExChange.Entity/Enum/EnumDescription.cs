using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

namespace GameExChange.Entity.Enum
{
    [AttributeUsage(AttributeTargets.Enum|AttributeTargets.Field)]
    public class EnumDescription : Attribute
    {
        public string Description {set;get;}
    }

    /// <summary>
    /// 枚举描述特性扩展
    /// </summary>
    public static class EnumDescriptionExtension
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(Type type)
        {
            var fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                EnumDescription desc = null;
                object[] attrs = field.GetCustomAttributes(typeof(EnumDescription), false);
                if (attrs != null && attrs.Length > 0)
                {
                    desc = attrs[0] as EnumDescription;
                    return desc.Description;
                }
                else
                {
                    continue;
                }
            }
            return "";
        }
        /// <summary>
        /// 获得枚举的 value--->EnumDescription 对应字典
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDesciptions(this System.Enum @enum)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            string[] values = System.Enum.GetNames(@enum.GetType());
            if (values == null || values.Length <= 0)
            {
                return result;
            }

            for (int i = 0; i < values.Length; i++)
            {
                result[i] = "";
            }
            foreach (string key in values)
            {
                int i = (int)System.Enum.Parse(@enum.GetType(), key);
                result[i] = GetDescription(System.Enum.Parse(@enum.GetType(), key).GetType());
            }
            return result;
        }
    }
}
