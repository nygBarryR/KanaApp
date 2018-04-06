using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : MonoBehaviour {

    public GameObject infoPanel;

    public void OpenInfoPanel ()
{
    infoPanel.SetActive(true); // Opening the information prompt //
    Invoke("CloseInfoPanel", 2); // Invoke means that after the Assigned value of 2 (equals seconds) the Function below will run //
}

    public void CloseInfoPanel ()
{
    infoPanel.SetActive(false); // Closing the information prompt //
}
}
