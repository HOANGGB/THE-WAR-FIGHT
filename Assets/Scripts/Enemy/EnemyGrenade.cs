using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrenade : Enemy
{
    protected override void Move(){

        isRun = true;
        isRunBack = false;
        if(player.transform.position.x < transform.position.x){
            rb.velocity = Vector2.left * speed;
        }else rb.velocity = Vector2.right * speed;
    }
     protected override void Fire(){
        isRun = false;
        isRunBack = false;

        Vector3 dirPlayer = player.transform.position - transform.position;
        float angleBullet = Mathf.Atan2(dirPlayer.y,dirPlayer.x) * Mathf.Rad2Deg;

        if(player.transform.position.x > transform.position.x) angleBullet = 10;
        else angleBullet = 170;

        float angleRadian = angleBullet * Mathf.Deg2Rad;

        Vector3 dirFire = new Vector3(Mathf.Cos(angleRadian),Mathf.Sin(angleRadian),0);

        if(timeFire<=0){
            var bullet = Instantiate(gun.Bullet,posFire.position,Quaternion.Euler(0,0,angleBullet));
            
            bullet.GetComponent<Grenade>().damage = gun.Damage;
            bullet.GetComponent<Rigidbody2D>().velocity = dirFire.normalized *gun.speedBullet;
            bullet.GetComponent<Grenade>().tagHitDamage  = gameObject.tag;
            // bullet.GetComponent<Rigidbody2D>().velocity = Vector3.Slerp(player.transform.position,transform.position,5f);

            timeFire = gun.SpeedReload * 5;
        }

    }

}
