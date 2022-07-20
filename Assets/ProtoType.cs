using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using TMPro;
using System.IO;

public class ProtoType : MonoBehaviour
{
    public string package;
    public Button AddButton;
    public TMP_InputField getPath;
    AddRequest request;
    public string Uri = @"https://objects.githubusercontent.com/github-production-release-asset-2e65be/204036367/bc2e8da0-d007-4a60-937c-6c19a669cc11?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIWNJYAX4CSVEH53A%2F20220720%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220720T200550Z&X-Amz-Expires=300&X-Amz-Signature=f60968883919f836b76ad3d8cec6b2265ba41398abfa12a2b12fbd3b16483029&X-Amz-SignedHeaders=host&actor_id=0&key_id=0&repo_id=204036367&response-content-disposition=attachment%3B%20filename%3Darcore-unity-extensions-1.32.0.tgz&response-content-type=application%2Foctet-stream";
    public string Uri2 = @"https://dl.google.com/games/registry/unity/com.google.android.performancetuner/android-performance-tuner-1.1.2.unitypackage";
    // Start is called before the first frame update
    void Start()
    {
        AddButton.onClick.AddListener(AddButton_OnClick);
        StartCoroutine(DownloadFile());
    }


    IEnumerator DownloadFile() {
        var uwr = new UnityWebRequest(Uri2, UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.persistentDataPath, @"android-performance-tuner-1.1.2.unitypackage");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void AddButton_OnClick() {
        //request
        //Debug.Log("Add button is clicked!!");
        string path = getPath.text;
        if (!string.IsNullOrEmpty(getPath.text))
        {
            request = Client.Add(path);
            EditorApplication.update += Progress;
        }
        else {
            Debug.Log("There is no valid path!");
        }
    }
    void Progress()
    {
        AddButton.interactable = false;
        if (request.IsCompleted)
        {
            if (request.Status == StatusCode.Success)
                Debug.Log("Installed: " + request.Result.packageId);
            else if (request.Status >= StatusCode.Failure)
                Debug.Log(request.Error.message);
            AddButton.interactable = true;
            EditorApplication.update -= Progress;
        }
    }
}
