using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsControls : MonoBehaviour
{

    public GameObject[] letterPanels = new GameObject[92];  // An array variable with the Letter Panels being used to link the Buttons to the Panel Controller's Elements //
                                                            // The buttons being linked are required to be in order in order to open up the intended panel for each button //
    public void LetterPressed(int letter)
    {

        letterPanels[letter].SetActive(!letterPanels[letter].activeSelf); // The [letter] refers to the manually inputed element number to the Button Object that corresponds to the Panel Controller //
                                                                          // The .setActive and the ![].active Self allow the same button to OPEN and CLOSE the targeted letter panel //
    }
}