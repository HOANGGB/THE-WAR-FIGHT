using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player" ||other.gameObject.tag == "HealPlayer" ){
            PlayerPrefs.SetInt(Data.ChipUpgrade,PlayerPrefs.GetInt(Data.ChipUpgrade) + 1);
            Destroy(gameObject);
        }
    }
}
