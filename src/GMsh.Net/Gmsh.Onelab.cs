﻿using Gmsh_wrap;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnsafeEx;

namespace GmshNet
{
    public static partial class Gmsh
    {
        /// <summary>
        /// ONELAB server functions
        /// </summary>
        public static class Onelab
        {
            /// <summary>
            /// Set one or more parameters in the ONELAB database, encoded in `format'.
            /// </summary>
            public static void Set(string data, string format = "json")
            {
                Gmsh_wrap.Gmsh_wrap.GmshOnelabSet(data, format, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Set one or more parameters in the ONELAB database, encoded in `format'.
            /// </summary>
            public static string Get(string name = "", string format = "json")
            {
                unsafe
                {
                    byte* data_ptr;
                    Gmsh_wrap.Gmsh_wrap.GmshOnelabGet(&data_ptr, name, format, ref Gmsh._staticreff);
                    var data = UnsafeHelp.ToString(data_ptr);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return data;
                }
            }

            /// <summary>
            /// Set the value of the number parameter `name' in the ONELAB database. Create
            /// the parameter if it does not exist; update the value if the parameter
            /// exists.
            /// </summary>
            public static void SetNumber(string name, double[] value)
            {
                Gmsh_wrap.Gmsh_wrap.GmshOnelabSetNumber(name, value, value.LongLength, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the value of the number parameter `name' from the ONELAB database.
            /// Return an empty vector if the parameter does not exist.
            /// </summary>
            public static double[] GetNumber(string name)
            {
                unsafe
                {
                    double* value_ptr;
                    long value_n = 0;
                    Gmsh_wrap.Gmsh_wrap.GmshOnelabGetNumber(name, &value_ptr, ref value_n, ref Gmsh._staticreff);
                    var value = UnsafeHelp.ToDoubleArray(value_ptr, value_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }
            }

            /// <summary>
            /// Set the value of the string parameter `name' in the ONELAB database. Create
            /// the parameter if it does not exist; update the value if the parameter
            /// exists.
            /// </summary>
            public static void SetString(string name, string[] value)
            {
                unsafe
                {
                    long value_n = 0;
                    var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(value, 0);
                    Gmsh_wrap.Gmsh_wrap.GmshOnelabSetString(name, (byte**)ptr.ToPointer(), value_n, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                }
            }

            /// <summary>
            /// Get the value of the string parameter `name' from the ONELAB database.
            /// Return an empty vector if the parameter does not exist.
            /// </summary>
            public static string[] GetString(string name)
            {
                unsafe
                {
                    byte** valueptr;
                    long value_n = 0;
                    Gmsh_wrap.Gmsh_wrap.GmshOnelabGetString(name, &valueptr, ref value_n, ref Gmsh._staticreff);
                    var value = UnsafeHelp.ToString(valueptr, value_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return value;
                }
            }

            /// <summary>
            /// Clear the ONELAB database, or remove a single parameter if `name' is given.
            /// </summary>
            public static void Clear(string name)
            {
                Gmsh_wrap.Gmsh_wrap.GmshOnelabClear(name, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Run a ONELAB client. If `name' is provided, create a new ONELAB client with
            /// name `name' and executes `command'. If not, try to run a client that might
            /// be linked to the processed input files.
            /// </summary>
            public static void Run(string name, string command = "")
            {
                Gmsh_wrap.Gmsh_wrap.GmshOnelabRun(name, command, ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }

            /// <summary>
            /// Get the names of the parameters in the ONELAB database matching the search regular expression. If search is empty, return all the names.
            /// </summary>
            public static string[] GetNames(string search = "")
            {
                unsafe
                {
                    byte** valueptr;
                    long value_n = 0;
                    Gmsh_wrap.Gmsh_wrap.GmshOnelabGetNames(search, &valueptr, ref value_n, ref Gmsh._staticreff);
                    var names = UnsafeHelp.ToString(valueptr, value_n);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return names;
                }
            }

            /// <summary>
            /// Check if any parameters in the ONELAB database used by the client name have been changed.
            /// </summary>
            public static bool GetChanged(string name)
            {
                unsafe
                {                    
                    int value = Gmsh_wrap.Gmsh_wrap.GmshOnelabGetChanged(name, ref Gmsh._staticreff);
                    Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
                    return Convert.ToBoolean(value);
                }
            }

            /// <summary>
            /// Set the changed flag to value `value' for all the parameters in the ONELAB
            /// database used by the client `name'.
            /// </summary>
            public static void SetChanged(string name, bool value)
			{
                Gmsh_wrap.Gmsh_wrap.GmshOnelabSetChanged(name, Convert.ToInt32(value), ref Gmsh._staticreff);
                Gmsh.CheckException(MethodBase.GetCurrentMethod().MethodHandle);
            }
        }
    }
}