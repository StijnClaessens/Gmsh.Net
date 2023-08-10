using Gmsh_wrap;
using System;
using System.Reflection;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// FLTK graphical user interface functions
        /// </summary>
        public static class Fltk
        {
            /// <summary>
            /// Create the FLTK graphical user interface. Can only be called in the main
            /// thread.
            /// </summary>
            public static void Initialize()
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkInitialize(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Wait at most `time' seconds for user interface events and return. If `time'
            /// &lt; 0, wait indefinitely. First automatically create the user interface if it
            /// has not yet been initialized. Can only be called in the main thread.
            /// </summary>
            public static void Wait(double time = -1)
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkWait(time, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Update the user interface (potentially creating new widgets and windows).
            /// First automatically create the user interface if it has not yet been
            /// initialized. Can only be called in the main thread: use `awake("update")' to
            /// trigger an update of the user interface from another thread.
            /// </summary>
            public static void Update()
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkUpdate(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Awake the main user interface thread and process pending events, and
            /// optionally perform an action (currently the only `action' allowed is
            /// "update").
            /// </summary>
            public static void Awake(string action = "")
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkAwake(action, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Block the current thread until it can safely modify the user interface.
            /// </summary>
            public static void Lock()
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkLock(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Release the lock that was set using lock.
            /// </summary>
            public static void Unlock()
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkUnlock(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Run the event loop of the graphical user interface, i.e. repeatedly call
            /// `wait()'. First automatically create the user interface if it has not yet
            /// been initialized. Can only be called in the main thread.
            /// </summary>
            public static void Run()
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkRun(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Check if the user interface is available (e.g. to detect if it has been
            /// closed).
            /// </summary>
            public static int IsAvailable()
            {
                var index = Gmsh_wrap.Gmsh_wrap.GmshFltkIsAvailable(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return index;
            }

            /// <summary>
            /// Select entities in the user interface. If `dim' is >= 0, return only the
            /// entities of the specified dimension (e.g. points if `dim' == 0).
            /// </summary>
            public static int SelectEntities(out ValueTuple<int, int>[] dimTags, int dim = -1)
            {
                unsafe
                {
                    int* dimTags_ptr;
                    long dimTags_n = 0;
                    var index = Gmsh_wrap.Gmsh_wrap.GmshFltkSelectEntities(&dimTags_ptr, ref dimTags_n, dim, ref Gmsh._staticreff);
                    dimTags = UnsafeHelp.ToIntArray(dimTags_ptr, dimTags_n).ToIntPair();
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }
            }

            /// <summary>
            /// Select elements in the user interface.
            /// </summary>
            public static int SelectElements(out long[] elementTags)
            {
                unsafe
                {
                    long* elementTags_ptr;
                    long elementTags_n = 0;
                    var index = Gmsh_wrap.Gmsh_wrap.GmshFltkSelectElements(&elementTags_ptr, ref elementTags_n, ref Gmsh._staticreff);
                    elementTags = UnsafeHelp.ToLongArray(elementTags_ptr, elementTags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }
            }

            /// <summary>
            /// Select elements in the user interface.
            /// </summary>
            public static int SelectViews(out int[] viewTags)
            {
                unsafe
                {
                    int* viewTags_ptr;
                    long viewTags_n = 0;
                    var index = Gmsh_wrap.Gmsh_wrap.GmshFltkSelectViews(&viewTags_ptr, ref viewTags_n, ref Gmsh._staticreff);
                    viewTags = UnsafeHelp.ToIntArray(viewTags_ptr, viewTags_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return index;
                }
            }

            /// <summary>
            /// Set a status message in the current window. If graphics is set, display the message inside the graphic window instead of the status bar.
            /// </summary>
            public static void SetStatusMessage(string message, bool graphics = false)
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkSetStatusMessage(message, Convert.ToInt32(graphics), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Show context window for the entity of dimension dim and tag tag.
            /// </summary>
            public static void ShowContextWindow(int dim, int tag)
			{
                Gmsh_wrap.Gmsh_wrap.GmshFltkShowContextWindow(dim, tag, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Open the name item in the menu tree.
            /// </summary>
            public static void OpenTreeItem(string name)
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkOpenTreeItem(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Open the name item in the menu tree.
            /// </summary>
            public static void CloseTreeItem(string name)
            {
                Gmsh_wrap.Gmsh_wrap.GmshFltkCloseTreeItem(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}