using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public string tagHitDamage ="";
    [SerializeField] GameObject explosion;

    private void Start() {
        StartCoroutine(ExlosionGrenade());
    }
    IEnumerator ExlosionGrenade(){
        yield return new WaitForSeconds(3);
            var explo = Instantiate(explosion,transform.position,Quaternion.identity);
            explo.GetComponent<Explosion>().tagHit = tagHitDamage;
            explo.GetComponent<Explosion>().damage = damage;
            Destroy(gameObject);
    }

}
