using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_M82 : Bullet
{
    protected override void DoHit(GameObject gameObject)
    {
        Destroy(this.gameObject,.2f);
    }

    protected override void DoHitOther()
    {
            Instantiate(effectCollide,transform.position,Quaternion.identity);
            Destroy(gameObject);
    }
}
