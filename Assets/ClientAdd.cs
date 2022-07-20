using System;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Unity.Editor.Example
{
    static class AddPackageExample
    {
        static AddRequest Request;

        [MenuItem("MyMenuItem/Item")]
        private static void Item1Do1() {
            Debug.Log("MyMenuItem Item1");
        }

        [MenuItem("GameObject/Item1")]
        private static void Item1Do2()
        {
            Debug.Log("MyMenuItem Item1");
        }

        [MenuItem("MyMenuItem/Item2")]
        private static void Item2Do1()
        {
            if(Selection.activeGameObject != null)
                Debug.Log(Selection.activeTransform.gameObject.name);
        }

        [MenuItem("Window/Add Package Example")]
        static void Add()
        {
            // Add a package to the Project
            Request = Client.Add("com.unity.textmeshpro");
            EditorApplication.update += Progress;
        }

        static void Progress()
        {
            if (Request.IsCompleted)
            {
                if (Request.Status == StatusCode.Success)
                    Debug.Log("Installed: " + Request.Result.packageId);
                else if (Request.Status >= StatusCode.Failure)
                    Debug.Log(Request.Error.message);

                EditorApplication.update -= Progress;
            }
        }
    }
}