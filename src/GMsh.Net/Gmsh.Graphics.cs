using Gmsh_wrap;
using System.Reflection;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// Graphics functions
        /// </summary>
        public static class Graphics
        {
            /// <summary>
            /// Draw all the OpenGL scenes.
            /// </summary>
            public static void Draw()
            {
                Gmsh_wrap.Gmsh_wrap.GmshGraphicsDraw(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}