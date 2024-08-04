using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeChar : MonoBehaviour
{P
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI chipUpgrade;
    [SerializeField] TextMeshProUGUI HealCurrent;
    [SerializeField] TextMeshProUGUI HealAfter;
    [SerializeField] TextMeshProUGUI HealShow;
    [SerializeField] GameObject ButtonUpgrade;
    HealBar healBar;
    Player player;

    void Start()
    {
        healBar = FindObjectOfType<HealBar>();
        player = FindObjectOfType<Player>();
        Reload();
    }
    void Reload(){
        chipUpgrade.text = PlayerPrefs.GetInt(Data.ChipUpgrade).ToString();
        HealCurrent.text = PlayerPrefs.GetInt(Data.Heal).ToString();
        HealAfter.text = (PlayerPrefs.GetInt(Data.Heal) + 100).ToString();
        HealShow.text = PlayerPrefs.GetInt(Data.Heal).ToString();
        healBar.UpdateHealBar(PlayerPrefs.GetInt(Data.Heal),PlayerPrefs.GetInt(Data.Heal));
        player.healCurrent = PlayerPrefs.GetInt(Data.Heal);
        if(PlayerPrefs.GetInt(Data.Heal) >= 1000){
            ButtonUpgrade.SetActive(false);
            HealAfter.text = "MAX";
        }
    }

    public void UpgradeHealChar(){
        if(PlayerPrefs.GetInt(Data.ChipUpgrade) > 0){
            PlayerPrefs.SetInt(Data.ChipUpgrade, PlayerPrefs.GetInt(Data.ChipUpgrade) - 1); 
            PlayerPrefs.SetInt(Data.Heal,PlayerPrefs.GetInt(Data.Heal) + 100);
            Reload();
        }
    }

    
}
