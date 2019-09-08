using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneID;
    public bool forceUseString;

    public void ChangeScene(LoadSceneMode mode) {
        int sceneNumericID;
        bool isNumber = int.TryParse(sceneID, out sceneNumericID);
        if (isNumber && !forceUseString) {
            SceneManager.LoadSceneAsync(sceneNumericID, mode);
            return;
        }

        SceneManager.LoadSceneAsync(sceneID, mode);
    }

    public void ChangeScene(bool additive) {
        ChangeScene((additive) ? LoadSceneMode.Additive : LoadSceneMode.Single);
    }
}
