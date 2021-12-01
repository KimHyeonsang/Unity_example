using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource SoundPlayer;
    private void Awake()
    {
    //    SoundPlayer = SoundManager.GetInstance.GetAudioClip(0);
    }
    void Start()
    {
        SoundPlayer = GetComponent<AudioSource>();
        SoundPlayer.clip = SoundManager.GetInstance.GetAudioClip(0);
        PlaySound();
    }

    public void PlaySound(bool _Loop = false)
    {
        SoundPlayer.volume = 1.0f;
        //��ý���
        SoundPlayer.time = 0;
        SoundPlayer.loop = _Loop;

        SoundPlayer.Play();
    }

    public void StopSound()
    {        
        SoundPlayer.Stop();
    }
}
