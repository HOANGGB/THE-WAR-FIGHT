using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    HighScore highScore;
    Button button;
    HealBar healBar;
    void Start()
    {
        healBar = FindObjectOfType<HealBar>();
        highScore = FindObjectOfType<HighScore>();
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(()=>Tap());
    }
    void Tap(){
        highScore.PlayGame();
        gameObject.SetActive(false);
        PlayerPrefs.SetInt(Data.RunMap,1);
        ///

    }


}
