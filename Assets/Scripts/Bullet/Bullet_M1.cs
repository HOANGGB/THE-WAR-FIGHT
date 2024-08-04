using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_M1 : Bullet
{
    [SerializeField] GameObject Boom;
    [SerializeField] int DamageBoom;



    protected override void DoHit(GameObject gameObject)
    {
        var boom = Instantiate(Boom,transform.position,Quaternion.identity);
        boom.GetComponent<Explosion>().damage = DamageBoom;
        boom.GetComponent<Explosion>().tagHit = tagHitDamage;
        Destroy(this.gameObject);
    }
    protected override void DoHitOther()
    {
        var boom = Instantiate(Boom,transform.position,Quaternion.identity);
        boom.GetComponent<Explosion>().damage = DamageBoom;
        boom.GetComponent<Explosion>().tagHit = tagHitDamage;
        Destroy(this.gameObject);
    }

}
