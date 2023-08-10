using Gmsh_wrap;
using System.Reflection;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// Plugin functions
        /// </summary>
        public static class Plugin
        {
            /// <summary>
            /// Set the numerical option `option' to the value `value' for plugin `name'.
            /// </summary>
            public static void SetNumber(string name, string option, double value)
            {
                Gmsh_wrap.Gmsh_wrap.GmshPluginSetNumber(name, option, value, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Set the string option `option' to the value `value' for plugin `name'.
            /// </summary>
            public static void SetString(string name, string option, string value)
            {
                Gmsh_wrap.Gmsh_wrap.GmshPluginSetString(name, option, value, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Run the plugin `name'.
            /// </summary>
            public static void Run(string name)
            {
                Gmsh_wrap.Gmsh_wrap.GmshPluginRun(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}