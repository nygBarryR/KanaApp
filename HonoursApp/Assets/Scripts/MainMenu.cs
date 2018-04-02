using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartLearningPage()
    {
        SceneManager.LoadScene("LearningMenu");
    }

    public void QuitApp ()
    {
        Debug.Log("Application Closed"); // Displays a Message in the bottom left corner of the Unity 5 Software Development. //  
                                         // Needed since an application in Unity can't be closed and no other way to test inside Unity. //

        Application.Quit();

    }
}
