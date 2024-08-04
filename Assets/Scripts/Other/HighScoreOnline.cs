using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dan.Main;
using TMPro;
public class HighScoreOnline : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TextMeshProUGUI> Names;
    public List<TextMeshProUGUI> Score;
    public string publicKey = "e02d7d733e69d35f2abe69a4691f418bf78420ef01fc7f93b357c80199b54633";



    void Start()
    {
        LoadEntries();
    }

    // Update is called once per frame
    public void LoadEntries()
    {
        Leaderboards.HighScoreTheFightWar.GetEntries(entries =>{
             foreach(TextMeshProUGUI name in Names){
                name.text = "";
             }
             foreach(TextMeshProUGUI score in Score){
                score.text = "";
             }

             float lenght = Mathf.Min(Names.Count,entries.Length);
             for(int i=0; i<lenght; i++){
                Names[i].text = entries[i].Username;
                Score[i].text = entries[i].Score.ToString();
             }
        });
    }
    public void SetEntry(string name, int score)
    {
        Leaderboards.HighScoreTheFightWar.UploadNewEntry(name,score,isSuccessfull =>{
            if(isSuccessfull){
                LoadEntries();
            }
        });
    }
}
