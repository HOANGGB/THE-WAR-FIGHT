using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "ScriptableObjects/Gun", order = 1)]

public class Gun : ScriptableObject{
    public string Name;
    public int Damage;
    public int NumberBullet;
    public float SpeedReload;
    public float speedBullet;
    public float TimeLoad;
    public int Price;
    public float Lenght;
    public int Status;
    public Sprite Sprite;
    public Sprite FrameGun;
    public GameObject Bullet;
    public AudioClip audio;
    public AudioClip audioReload;

  
}