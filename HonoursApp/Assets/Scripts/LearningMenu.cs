using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   // Required when switching scenes //

public class LearningMenu : MonoBehaviour
{

    public void StartMainMenuPage()
    {
        SceneManager.LoadScene("MainMenu");  // The targeted Scene, only one scene runs at a time so the current scene automatically closes when switching //
    }
}
