using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerWin : MonoBehaviour
{

    public AudioClip sound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(sound);
    }
}
