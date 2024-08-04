using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int healShield;

   private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Bullet"){
        healShield -= other.GetComponent<Bullet>().damage;
        Destroy(other.gameObject);
        if(healShield<=0) gameObject.SetActive(false);
    }
   }

}
