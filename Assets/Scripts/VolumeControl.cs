using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    //Reference to audio source
    private AudioSource audioSrc;

    private float musicVolumeValue = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

        //Updates Volume every frame
        audioSrc.volume = musicVolumeValue;
    }

    public void SetVolume(float volume)
    {
        musicVolumeValue = volume;
    }
}
