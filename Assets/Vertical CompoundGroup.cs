//Create a Vertical Compound Button

using UnityEngine;
using UnityEditor;

public class VerticalCompoundGroup : EditorWindow
{
    [MenuItem("Examples/Begin-End Vertical usage")]
    static void Init() {
        //VerticalCompoundGroup window = (VerticalCompoundGroup)EditorWindow.GetWindow(typeof(VerticalCompoundGroup), true, "My Empty Window");
        VerticalCompoundGroup window = GetWindow(typeof(VerticalCompoundGroup), true, "My Empty Window") as VerticalCompoundGroup;
        //window.minSize = new Vector2(LayoutSize.)
        window.Show();
    }

    private void OnGUI()
    {
        System.Object obj1 = 11;
        if (obj1 is int) {
            int nValue = (int)obj1;
        }
        //Rect r = (Rect)EditorGUILayout.BeginVertical("Button");
        //if (GUI.Button(r, GUIContent.none))
        //    Debug.Log("Go here");
        //GUILayout.Label("I'm inside the button");
        //GUILayout.Label("So am I");
        //EditorGUILayout.EndVertical();
    }
}
