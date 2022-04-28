using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{

    public AudioClip music;
    public AudioClip sound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(sound);
        audioSource.clip = music;
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying) {
            audioSource.Play();
        }
    }
}
