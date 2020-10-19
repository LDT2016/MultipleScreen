using System;
using System.Reflection;
using System.Resources;

namespace MultipleScreen.Common
{
    /// <summary>
    /// QRTool.DependentFiles.LoadResourceDll();       // 载入资源dll文件
    /// </summary>
    public class DependentFiles
    {
        #region methods

        /// <summary>
        /// 载入资源文件中附带的所有dll文件
        /// </summary>
        public static void LoadResourceDll()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dllName = args.Name.Contains(",")
                              ? args.Name.Substring(0, args.Name.IndexOf(','))
                              : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources"))
            {
                return null;
            }

            var nameSpace = Assembly.GetEntryAssembly()
                                      ?.GetTypes()[0]
                                    .Namespace;
            var rm = new ResourceManager(nameSpace + ".Properties.Resources", Assembly.GetExecutingAssembly());
            var bytes = (byte[])rm.GetObject(dllName);

            return Assembly.Load(bytes);
        }

        #endregion
    }
}
