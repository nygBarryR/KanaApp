using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsControls : MonoBehaviour
{

    public GameObject[] letterPanels = new GameObject[92];

    public void LetterPressed(int letter)
    {

        letterPanels[letter].SetActive(!letterPanels[letter].activeSelf);
    }
}