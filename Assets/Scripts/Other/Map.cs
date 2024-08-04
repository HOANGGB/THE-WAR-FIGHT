using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] GameObject Boss;
    MapController map;
    Rigidbody2D rb;
    void Start()
    {
        map = FindObjectOfType<MapController>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
            if( Camera.main.transform.position.x - transform.position.x > 100){
                Instantiate(map.ListMap[map.RandomNumberMap()], new Vector3(transform.position.x + 199,
                transform.position.y,transform.position.z),Quaternion.identity);
                map.numberMap+=1;

                if(map.numberMap >=20 && map.numberMap /10 == 0){
                    var bossSpawn =  Instantiate(Boss,new Vector3(100,-8,Boss.transform.position.z),Quaternion.identity);
                    bossSpawn.GetComponent<AWMBoss>().healMax *= map.numberMap;
                }
                Destroy(gameObject);
            }
    }
     void FixedUpdate()
    {
        if(PlayerPrefs.GetInt(Data.RunMap) == 1){
            rb.velocity = Vector2.left * speed;
        }else{
            rb.velocity = Vector2.zero;
        }
    }
    
}
