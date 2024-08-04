using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Enemy
{

    protected override void Fire(){
        isRun = false;
        isRunBack = false;

        Vector3 dir = player.transform.position - transform.position;
        float angleBullet = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

        if(player.transform.position.x <= transform.position.x){
            GunSprite.transform.rotation = Quaternion.Euler(0, 0, angleBullet + 180);
        }else{
            GunSprite.transform.rotation = Quaternion.Euler(0, 0, angleBullet);
        }
        if(timeFire<=0){
            audioSource.clip = gun.audio;
            audioSource.Play();

            var bullet = Instantiate(gun.Bullet,posFire.position,Quaternion.Euler(0,0,angleBullet));
            
            bullet.gameObject.tag = "BulletEnemy";
            bullet.gameObject.layer = 12;
            bullet.GetComponent<Bullet>().tagHitDamage  = gameObject.tag;

            bullet.GetComponent<Bullet>().damage = gun.Damage;
            bullet.GetComponent<Bullet>().speedBullet = gun.speedBullet;
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * gun.speedBullet /2;

            timeFire = gun.SpeedReload * 10;

        }
    }

    protected override void Move()
    {
        isRunBack = false;
        isRun = true;
        if(player.transform.position.x < transform.position.x){
            rb.velocity = Vector2.left * speed;
        }else rb.velocity = Vector2.right * speed;
       
    }
}
