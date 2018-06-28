using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web;

namespace GameExChange.Infrastructure.Utils
{
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public static T GetConfig<T>(string configFileName)
        {
            return XmlHelper.XmlDeserialize<T>(File.ReadAllText(configFileName));
        }

        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="configFileName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool SetConfig(string configFileName,object content)
        {
            return XmlHelper.SaveXml(content, configFileName);
        }
             
    }
}
