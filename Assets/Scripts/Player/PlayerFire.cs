using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public int indexGun = 0;
    int numberBulletCurrent;
    float timeFire;
    public bool canFire = true;
    public bool changeGun = false;
    [SerializeField] LineRenderer Sights;
    Player  player;
    public Dictionary<int, int> ListIndexBulletGun;
    private void Awake() {
        ListIndexBulletGun = new Dictionary<int, int>();

        // Thêm các cặp khóa-giá trị vào từ điển
        ListIndexBulletGun.Add(0, 1);
        ListIndexBulletGun.Add(1, 1);
        ListIndexBulletGun.Add(2, 1);
        
    }

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        numberBulletCurrent = player.GunCurrent.NumberBullet;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        CoolDown();
    }
    void Fire(){
 
        // if(changeGun){
        //     // numberBulletCurrent = ListIndexBulletGun.GetValueOrDefault(indexGun);
        //     changeGun = false;
        // }
        if(!canFire) return;
        Vector2 direction = new Vector3(player.joystickAttack.Horizontal, player.joystickAttack.Vertical);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Sights.SetPosition(0,player.PointBullet.transform.position);
        Sights.SetPosition(1,player.PointBullet.transform.position * 
        (new Vector2(player.joystickAttack.Horizontal,player.joystickAttack.Vertical) * - 10));

        player.GunSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
            //rotation IconAttack
        player.IconAttack.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        if(timeFire >0) return;

        if(player.joystickAttack.Horizontal !=0 || player.joystickAttack.Vertical != 0){
            player.ParticleSystem.Play();

            player.au.PlayAu("Fire");

            var bullet = Instantiate(player.GunCurrent.Bullet, player.PointBullet.transform.position, Quaternion.Euler(0, 0, angle));
            bullet.GetComponent<Bullet>().damage = player.GunCurrent.Damage;
            bullet.GetComponent<Bullet>().speedBullet = player.GunCurrent.speedBullet;
            bullet.GetComponent<Bullet>().tagHitDamage  = gameObject.tag;


            bullet.GetComponent<Rigidbody2D>().velocity  =  direction.normalized * player.GunCurrent.speedBullet;
        
            timeFire = player.GunCurrent.SpeedReload;
            ListIndexBulletGun[indexGun] -=1;
            // Debug.Log("BULLET = = == "+ ListIndexBulletGun[indexGun]);
        }else{
            player.IconAttack.transform.rotation = Quaternion.Euler(0, 0, 0);
            player.GunSprite.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if(ListIndexBulletGun[indexGun] == 0){
            StartCoroutine(ReloadMagazine());
        }
        Sights.SetPosition(0,Vector3.zero);
        Sights.SetPosition(1,Vector3.zero);
    }
    IEnumerator ReloadMagazine(){
        Sights.SetPosition(1,player.PointBullet.transform.position * - 10);

        // Debug.Log("LOADDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
        canFire = false;
        yield return new WaitForSeconds(player.au.GetAudioClip("Fire").length);
        Sights.SetPosition(0,Vector3.zero);
        Sights.SetPosition(1,Vector3.zero);
        player.au.PlayAu("ReloadMagazine");
        yield return new WaitForSeconds(player.GunCurrent.TimeLoad);
        canFire = true;
        ListIndexBulletGun[indexGun] = player.GunCurrent.NumberBullet;
    }
    void CoolDown(){
        timeFire -= Time.deltaTime;
    }
}
