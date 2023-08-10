﻿using Gmsh_wrap;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        public enum MessageLevel
        {
            Info,
            Warning,
            Error
        }

        public static class Logger
        {
            /// <summary>
            /// Write a `message'. `level' can be "info", "warning" or "error".
            /// </summary>
            public static void Write(string message, string level = "info")
            {
                Gmsh_wrap.Gmsh_wrap.GmshLoggerWrite(message, level, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            public static void Write(string message, MessageLevel level)
            {
                Gmsh_wrap.Gmsh_wrap.GmshLoggerWrite(message, Enum.GetName(level.GetType(), level).ToLower(), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Start logging messages.
            /// </summary>
            public static void Start()
            {
                Gmsh_wrap.Gmsh_wrap.GmshLoggerStart(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get logged messages.
            /// </summary>
            public static string[] Get()
            {
                unsafe
                {
                    byte** errorptr;
                    long log_n = 0;
                    Gmsh_wrap.Gmsh_wrap.GmshLoggerGet(&errorptr, ref log_n, ref _staticreff);

                    var messages = UnsafeHelp.ToString(errorptr, log_n);
                    if (_staticreff != 0)
                    {
                        var method = MethodBase.GetCurrentMethod();
                        var where = $"{method.DeclaringType.FullName}.{method.Name}";
                        throw new GmshException("Could not get", where, _staticreff);
                    }
                    return messages;
                }
            }

            /// <summary>
            /// Stop logging messages.
            /// </summary>
            public static void Stop()
            {
                Gmsh_wrap.Gmsh_wrap.GmshLoggerStop(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Return wall clock time.
            /// </summary>
            public static double GetWallTime()
            {
                var time = Gmsh_wrap.Gmsh_wrap.GmshLoggerGetWallTime(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return time;
            }

            /// <summary>
            /// Return CPU time.
            /// </summary>
            public static double GetCpuTime()
            {
                var time = Gmsh_wrap.Gmsh_wrap.GmshLoggerGetCpuTime(ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                return time;
            }

            /// <summary>
            /// Return last error message, if any.
            /// </summary>
            public static string GetLastError()
            {
                unsafe
                {
                    byte* errorptr;
                    Gmsh_wrap.Gmsh_wrap.GmshLoggerGetLastError(&errorptr, ref Gmsh._staticreff);

                    var ptr = new IntPtr(errorptr);
                    var error = Marshal.PtrToStringAnsi(ptr);
                    Gmsh_wrap.Gmsh_wrap.GmshFree(ptr);

                    if (Gmsh._staticreff != 0)
                    {
                        var method = MethodBase.GetCurrentMethod();
                        var where = $"{method.DeclaringType.FullName}.{method.Name}";
                        throw new GmshException("Could not get last error", where, _staticreff);
                    }
                    return error;
                }
            }
        }
    }
}