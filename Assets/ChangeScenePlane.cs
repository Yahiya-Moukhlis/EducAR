using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePlane : MonoBehaviour
{


    // Update is called once per frame
    public void ChangeToScene(string sceneToChangeTo)
    {
        //Application.LoadLevel(sceneToChangeTo);
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
