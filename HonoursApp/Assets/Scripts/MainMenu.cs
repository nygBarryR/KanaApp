using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Required when switching scenes //

public class MainMenu : MonoBehaviour {

    public void StartLearningPage()
    {
        SceneManager.LoadScene("LearningMenu");     // The targeted Scene, only one scene runs at a time so the current scene automatically closes when switching //
    }

    public void QuitApp ()
    {
        Debug.Log("Application Closed"); // Displays a Message in the bottom left corner of the Unity 5 Software Development. //  
                                         // Needed since an application in Unity can't be closed and no other way to test inside Unity. //

        Application.Quit();

    }
}
