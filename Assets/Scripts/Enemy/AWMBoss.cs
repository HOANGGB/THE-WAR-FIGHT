
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AWMBoss : Enemy
{
    [SerializeField] private LineRenderer lineRenderer;
    bool isMove;
    float rdPosx;
    float rdPosy;


    protected override void Move()
    {
        Vector3 topRight = Camera.main.transform.position 
                        + Camera.main.transform.forward * Camera.main.orthographicSize 
                        + Camera.main.transform.right * Camera.main.aspect * Camera.main.orthographicSize;
        Vector3 topLeft = Camera.main.transform.position 
                        + Camera.main.transform.forward * Camera.main.orthographicSize 
                        - Camera.main.transform.right * Camera.main.aspect * Camera.main.orthographicSize;
        if(!isMove){
            rdPosx = Random.Range(topRight.x - 10,topLeft.x + 14);
            rdPosy = Random.Range(topRight.y +20,topRight.y + 10);


        }
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(rdPosx,rdPosy),speed /2 * Time.deltaTime);
        isMove = true;
        if(Vector2.Distance(transform.position,new Vector3(rdPosx,rdPosy)) <=2f){
            isMove = false;
        }
        // Debug.Log("topLeft   :" +topLeft);


    }
    protected override void Fire()
    {
        
        lineRenderer.SetPosition(0,posFire.position);
        lineRenderer.SetPosition(1,player.transform.position);

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
            bullet.GetComponent<Bullet>().damage = gun.Damage;
            bullet.GetComponent<Bullet>().speedBullet = gun.speedBullet *2;
            bullet.GetComponent<Rigidbody2D>().velocity = dir.normalized * gun.speedBullet /2;

            timeFire = gun.SpeedReload *2 ;
        }else{
            Move();
        }
    }





}
