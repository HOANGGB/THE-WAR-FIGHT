using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] bool left;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePosWall();
    }

    // Update is called once per frame
    void UpdatePosWall()
    {
        if(left){
            Vector3 NewPos = Camera.main.transform.position - Camera.main.transform.right * Camera.main.aspect * Camera.main.orthographicSize;
            transform.position = new Vector2(NewPos.x,transform.position.y);        
        }else{
            Vector3 NewPos = Camera.main.transform.position + Camera.main.transform.right * Camera.main.aspect * Camera.main.orthographicSize;
            transform.position = new Vector2(NewPos.x,transform.position.y);                   
        }
    }
}
