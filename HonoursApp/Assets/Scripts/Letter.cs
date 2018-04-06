using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public string letterName = ""; // Is not essentially, merely identifies the a name given to the Selection button that has the attached onClick QuestionController and Letter (Script) //
    public List<Question> questions = new List<Question>(); // Runs an arrays of New Question Classes , with each Questions content being Manually assigned on the Selection Button Letter (Script) //
}
