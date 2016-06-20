using System;
using System.Text;
#if UNITY_WINRT
using UnityEngine.Windows;
#else
using System.IO;
#endif
using UnityEngine;
using System.Collections;

namespace Shoshone.CommonIO
{
    public class File
    {
        public static bool Exists(string path)
        {
#if UNITY_WSA_10_0
            return UnityEngine.Windows.File.Exists(path);
#else
            return System.IO.File.Exists(path);
#endif
        }

        public static string ReadAllText(string path)
        {
#if UNITY_WSA_10_0
            var data = ReadAllBytes(path);
            return Encoding.UTF8.GetString(data, 0, data.Length);
#else
            return System.IO.File.ReadAllText(path);
#endif
        }

        public static byte[] ReadAllBytes(string path)
        {
#if UNITY_WSA_10_0
            return UnityEngine.Windows.File.ReadAllBytes(path);
#else
            return System.IO.File.ReadAllBytes(path);
#endif
        }

        public static void WriteAllBytes(string path, byte[] data)
        {
#if UNITY_WSA_10_0
            UnityEngine.Windows.File.WriteAllBytes(path, data);
#else
            System.IO.File.WriteAllBytes(path, data);
#endif
        }

        public static void WriteAllText(string path, string data)
        {
#if UNITY_WSA_10_0
            WriteAllBytes(path, Encoding.UTF8.GetBytes(data));
#else
            System.IO.File.WriteAllText(path, data);
#endif
        }

        public static void Delete(string path)
        {
#if UNITY_WSA_10_0
            UnityEngine.Windows.File.Delete(path);
#else
            System.IO.File.Delete(path);
#endif
        }
    }

    public class Directory
    {
        public enum PresetFolders
        {
            Local,
            Roaming,
            Temporary
        }

        public static string GetPresetFolderPath(PresetFolders folder)
        {
#if UNITY_WSA_10_0
            switch (folder)
            {
                case PresetFolders.Roaming:
                    return UnityEngine.Windows.Directory.roamingFolder;
                case PresetFolders.Temporary:
                    return UnityEngine.Windows.Directory.localFolder;
                // ReSharper disable once RedundantCaseLabel
                case PresetFolders.Local:
                default:
                    return UnityEngine.Windows.Directory.localFolder;
            }
#else
            return "";
#endif
        }

        public static bool Exists(string path)
        {
#if UNITY_WSA_10_0
            return UnityEngine.Windows.Directory.Exists(path);
#else
            return System.IO.Directory.Exists(path);
#endif
        }

        public static void CreateDirectory(string path)
        {
#if UNITY_WSA_10_0
            UnityEngine.Windows.Directory.CreateDirectory(path);
#else
            System.IO.Directory.CreateDirectory(path);
#endif
        }

        public static void Delete(string path)
        {
#if UNITY_WSA_10_0
            UnityEngine.Windows.Directory.Delete(path);
#else
            System.IO.Directory.Delete(path);
#endif
        }
    }
}