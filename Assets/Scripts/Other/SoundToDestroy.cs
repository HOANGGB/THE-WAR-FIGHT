using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip sound;
    AudioSource au;

    void Start()
    {
        au = GetComponent<AudioSource>();
        au.Play();
    }


}
