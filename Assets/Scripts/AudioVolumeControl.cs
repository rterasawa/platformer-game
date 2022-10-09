using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeControl : MonoBehaviour
{

    public AudioSource sounds;

    private float musicVolume = 0.2f;

    // Update is called once per frame
    void Update()
    {
        sounds.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
