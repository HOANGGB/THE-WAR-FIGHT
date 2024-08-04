using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Price;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Price.text = PlayerPrefs.GetInt(Data.Gold).ToString();
    }

    void Update()
    {
        
    }
    public void UpdateGold(){
        Price.text = PlayerPrefs.GetInt(Data.Gold).ToString();
        anim.SetTrigger("PlayAnim");
    }
    public void SubtracGold(int price){
        PlayerPrefs.SetInt(Data.Gold,PlayerPrefs.GetInt(Data.Gold)-price);
        PlayerPrefs.Save();
        UpdateGold();
    }
    public void PlusGold(int price){
        PlayerPrefs.SetInt(Data.Gold,PlayerPrefs.GetInt(Data.Gold)+price);
        PlayerPrefs.Save();
        UpdateGold();
    }
}
