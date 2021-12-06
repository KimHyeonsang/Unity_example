using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    static private SoundManager Instance;
    static public SoundManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new SoundManager();

            return Instance;
        }
    }

    private List<AudioClip> SoundList = new List<AudioClip>();
 //   private AudioSource AudioPlayer = null;
    public void Initalize()
    {
        //모든 오브젝트를 말한다.
        object[] Obj = Resources.LoadAll("Sound");

        for(int i=0;i < Obj.Length;++i)
        {
            SoundList.Add(Obj[i] as AudioClip);
        }
    }

    public AudioClip GetAudioClip(int _Index)
    {
        if (_Index >= SoundList.Count)
        {
            Debug.Log("재생 가능한 사운드가 없습니다. Index :"
                + _Index + " max Index : " + (SoundList.Count - 1));
            
        }
     //   AudioSource Source = new AudioSource();
     //   Source.clip = SoundList[_Index];

        return SoundList[_Index];
    }

    public void PlayerSound(int _Index, bool _Loop = false)
    {
        if (_Index >= SoundList.Count)
        {
            Debug.Log("재생 가능한 사운드가 없습니다. Index :"
                + _Index + " max Index : " + (SoundList.Count - 1));
            return;
        }

        
        

    }

    public void PlayerSound(string _Name, bool _Loop = false)
    {

    }
}
