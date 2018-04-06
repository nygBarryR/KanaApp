using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {     // The Question class called from the Letter.cs Script // 
                                 // Entries below this line are found in the Selection Button(s) Letter (Script inspector Window //
    public string title; // The entry to this determines what letter or character is being Questioned on the the Testing Screen //
    public string[] answers = new string[4]; // The number of answers to be provided, set to 4 to match the corresponding Answer Button Amount, values manually entered in Inspector //
    public string correctAnswer; // The value entered here must match one of the values from the answers string in order to provide a correct answer for the user //
}
