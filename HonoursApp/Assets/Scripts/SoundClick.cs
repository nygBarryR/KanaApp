using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]   // Required a Button (Script) attached to the Game Element //

public class SoundClick : MonoBehaviour
{

    public AudioClip lettersound; // Assigning the lettersound variable an AudioClip so the Component Script attached to the buttons know what file type to look for //

    private Button SoundButton { get { return GetComponent<Button>(); } }
    private AudioSource Source { get { return GetComponent<AudioSource>(); } }


    void Start()
    {

        gameObject.AddComponent<AudioSource>(); // Adding audio media to the Game Object //
        Source.clip = lettersound;   // Assigning the one clip play to the Audio file Variable //
        Source.playOnAwake = false; // Required to stop the Audio from automatically play when is enabled Button but hasnt been pressed it //

        SoundButton.onClick.AddListener(() => PlaySound());  // Calls the PlaySound function below so the button starts to listen and play the assigned Lettersound file //
    }

    void PlaySound()
    {
        Source.PlayOneShot(lettersound); // The letter sound is the sound file, to be dragged into the Sound Click (Script) Lettersound slot //
    }
}
