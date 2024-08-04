using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotGun : MonoBehaviour
{
    public Gun Gun;
    Button button;
    Player player;
    PlayerFire playerFire;
    PointFireSpawn pointFireSpawn;
    Bag bag;
    Shop shop;
    Image sprite;
    AudioSource au;
    void Awake(){
        player = FindObjectOfType<Player>();
        playerFire = FindObjectOfType<PlayerFire>();
        bag = FindObjectOfType<Bag>();
        au = GetComponentInParent<AudioSource>();
        shop = FindObjectOfType<Shop>();
        pointFireSpawn = FindAnyObjectByType<PointFireSpawn>();
        button = GetComponent<Button>();
        sprite = GetComponent<Image>();
        button.onClick.AddListener(()=>addOnclick());
        ShowGun();

    }

    private void Start() {
        LoadBullet();
        
    }
    void ShowGun(){
            // Debug.Log("INDEX "+transform.GetSiblingIndex());

            if(PlayerPrefs.GetInt(Data.SlotGun + transform.GetSiblingIndex()) == 0) return;
            Gun = shop.ListGun[PlayerPrefs.GetInt(Data.SlotGun + transform.GetSiblingIndex())];
            sprite.sprite = Gun.FrameGun;
            // Debug.Log("INDEX GUN "+PlayerPrefs.GetInt(Data.SlotGun +  transform.GetSiblingIndex()));
            if(Gun != null) player.GunCurrent = Gun;
        
    }
    public void LoadBullet(){
        if(Gun != null){
            playerFire.ListIndexBulletGun[transform.GetSiblingIndex()] = Gun.NumberBullet;
            Debug.Log("LOADBULLET NÊF");
        }
    }
    void addOnclick(){
        if(!playerFire.canFire) return;
        bag.slotNumber = transform.GetSiblingIndex();
        if(Gun != null){
            au.Play();
            player.GunCurrent = Gun;
            player.GunSprite.GetComponent<SpriteRenderer>().sprite = Gun.Sprite;
            pointFireSpawn.UpdatePointFire(Gun.Lenght);
            playerFire.changeGun = true;


            playerFire.indexGun = transform.GetSiblingIndex();
            LoadBullet();
            Debug.Log("indexGun ==="+playerFire.indexGun);
            // playerFire.ListIndexBulletGun[transform.GetSiblingIndex()] = Gun.NumberBullet;
            // Debug.Log("INDEX GUN CHANGE == "+ transform.GetSiblingIndex()+" /r NUMBERBUULLET = "+Gun.NumberBullet);
        }
    }
}



