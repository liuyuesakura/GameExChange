using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GameExChange.Infrastructure
{
    public class XmlHelper
    {
        /// <summary>
        /// 将对象序列化为XML字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T item)
        {
            var serialize = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            using (var write = new StringWriter(sb))
            {
                serialize.Serialize(write, item);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将对象序列化为XML字符串
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string XmlSerialize(object item)
        {
            Type type = item.GetType();
            var serialize = new XmlSerializer(type);
            StringBuilder sb = new StringBuilder();
            using (var write = new StringWriter(sb))
            {
                serialize.Serialize(write, item);
            }
            return sb.ToString();
        }

        /// <summary>
        /// xml反序列化为指定对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlData))
            {
                T entity = (T)serializer.Deserialize(reader);
                return entity;
            }

        }

        /// <summary>
        /// 将xml文件反序列化为指定对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string fileName, Type type = null)
        {
            type = type ?? typeof(T);
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return (T)serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }


        /// <summary>
        /// 保存XML文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveXml(object obj, string fileName)
        {
            bool success = false;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return success;
        }

        /// <summary>
        /// 获取xml节点值
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        public static string GetStrFromXml(string xmlDoc,string xmlNode)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlDoc);
            XmlNode node = xml.SelectSingleNode(xmlNode);
            return node.Value;
        }

    }
}
