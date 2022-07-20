using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISKINBox : MonoBehaviour
{
    GUIStyle style;
    private void OnGUI()
    {
        if (GUILayout.Button("press me"))
            Debug.Log("Hello");
        GUI.skin.box = style;
        GUILayout.Box("This is a box");


        //make a background box
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        //make the first button, if it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "level1 1")) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        //make the second button,
        if (GUI.Button(new Rect(20, 70, 80, 20), "level 2"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
