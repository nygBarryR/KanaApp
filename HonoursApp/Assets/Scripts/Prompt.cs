using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : MonoBehaviour {

    public GameObject infoPanel;

    public void OpenInfoPanel ()
{
    infoPanel.SetActive(true);
    Invoke("CloseInfoPanel", 2);
}

    public void CloseInfoPanel ()
{
    infoPanel.SetActive(false);
}
}
