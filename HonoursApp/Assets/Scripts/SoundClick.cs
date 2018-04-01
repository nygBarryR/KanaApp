using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class SoundClick : MonoBehaviour
{

    public AudioClip lettersound;

    private Button SoundButton { get { return GetComponent<Button>(); } }
    private AudioSource Source { get { return GetComponent<AudioSource>(); } }


    void Start()
    {

        gameObject.AddComponent<AudioSource>();
        Source.clip = lettersound;
        Source.playOnAwake = false;

        SoundButton.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        Source.PlayOneShot(lettersound);
    }
}
