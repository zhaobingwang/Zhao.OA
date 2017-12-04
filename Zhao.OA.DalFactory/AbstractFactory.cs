using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zhao.OA.IDAL;

namespace Zhao.OA.DalFactory
{
    /// <summary>
    /// 通过反射创建类的实例
    /// </summary>
    public class AbstractFactory
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// 创建UserInfoDal实例
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal";
            return CreateInstancs(fullClassName) as IUserInfoDal;
        }

        private static object CreateInstancs(string fullClassName)
        {
            var assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(fullClassName);
        }
    }
}
