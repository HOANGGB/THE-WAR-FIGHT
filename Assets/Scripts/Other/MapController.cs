
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]public List<GameObject> ListMap;
    public int numberMap = 0;
    public int RandomNumberMap(){

        int number = 0;
        if(numberMap < 5) number = Random.Range(0,5);
        else if(numberMap <10)  number = Random.Range(5,10);
        else if(numberMap <15)  number = Random.Range(10,15);
        else if(numberMap <18)  number = Random.Range(15,19);
        else number = Random.Range(17,20);
        return number;
    }
}
