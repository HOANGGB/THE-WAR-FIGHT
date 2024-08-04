using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    AudioSource au;

    void Start()
    {
        au = GetComponent<AudioSource>();
        
    }

    public void PlayAu(string nameAudio){
        if(nameAudio == "Fire"){
            var Fire = GetComponentInParent<Player>().GunCurrent.audio;
            au.clip = Fire;
        }
        if(nameAudio == "ReloadMagazine"){
            var ReloadMagazinee = GetComponentInParent<Player>().GunCurrent.audioReload;
            au.clip = ReloadMagazinee;
        }
        au.Play();
    }
    public AudioClip GetAudioClip(string nameAudio){
        if(nameAudio == "Fire"){
            var Fire = GetComponentInParent<Player>().GunCurrent.audio;
            return Fire;
        }
        if(nameAudio == "ReloadMagazine"){
            var ReloadMagazinee = GetComponentInParent<Player>().GunCurrent.audioReload;
            return ReloadMagazinee;
        }
        return null;
    } 
}
