using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LearningMenu : MonoBehaviour
{

    public void StartMainMenuPage()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
