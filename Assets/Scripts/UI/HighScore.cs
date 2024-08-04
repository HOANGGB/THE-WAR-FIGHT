
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI highNumber;
    [SerializeField] TextMeshProUGUI Text;
    Animator anim;

    public int scoreCurrent = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        highNumber.text = PlayerPrefs.GetInt(Data.HighScore).ToString();
    }
    public void PlayGame(){
        Text.text = "Score";
        highNumber.text = "0";
    }

    public void UpdateScore(int score){
        anim.SetTrigger("PlayAnim");
        scoreCurrent += score;
        Text.text = "Score";
        highNumber.text = scoreCurrent.ToString();
        if(scoreCurrent > PlayerPrefs.GetInt(Data.HighScore)) PlayerPrefs.SetInt(Data.HighScore,scoreCurrent);
    }
}
