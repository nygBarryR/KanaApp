using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {

    public string title;
    public string[] answers = new string[4];
    public string correctAnswer;
}
