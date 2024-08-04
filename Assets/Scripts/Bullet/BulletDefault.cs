
using TMPro;
using UnityEngine;

public class BulletDefault : Bullet
{
    protected override void DoHit(GameObject gameObject)
    {
        Destroy(this.gameObject);
    }
    protected override void DoHitOther()
    {
            Instantiate(effectCollide,transform.position,Quaternion.identity);
            Destroy(gameObject);
    }

}
