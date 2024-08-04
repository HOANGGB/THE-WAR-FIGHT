using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static string Gold = "Gold";
    public static string Heal = "Heal";
    public static string ChipUpgrade = "ChipUpgrade";



    //GUN
    public static string NamePlayer = "NamePlayer";
    public static string HighScore = "HighScore";
    public static string RunMap = "RunMap";
    public static string SlotGun = "SlotGun";


    public static void ResetKey(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(Gold,50000);
        PlayerPrefs.SetInt(Heal,100);
        PlayerPrefs.SetInt(ChipUpgrade,10);

        PlayerPrefs.SetString(NamePlayer,"PLAYER HEHEHE");
    }
    

}

