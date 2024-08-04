using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public float speedBullet;
    protected Player player;
    [SerializeField] protected GameObject effectCollide;
    [SerializeField]protected GameObject DamageShow;
    [SerializeField]public string tagHitDamage;

    
    void Start(){
        // Destroy(gameObject,2);
        player = FindObjectOfType<Player>();
    }
    void Update(){

    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    protected abstract void DoHit(GameObject gameObject);
    protected abstract void DoHitOther();


     private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player" || other.tag == "HeadPlayer"|| other.gameObject.tag == "Enemy" || other.gameObject.tag == "HeadEnemy")
        {
            Hit(other.gameObject);
        }
        if(other.tag == "Bullet" || other.gameObject.tag == "Ground"){
            DoHitOther();
        }
        if(other.tag =="Shield"){
            Instantiate(effectCollide,transform.position,Quaternion.identity);
        }
    }
    protected void Hit(GameObject gameObject)
    {
        if(gameObject.tag != "HeadEnemy" && gameObject.tag != "HeadPlayer"){
            if(transform.position.x > gameObject.transform.position.x){
                if(gameObject.tag != "Player") gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * speedBullet/10;
            }else{
                if(gameObject.tag != "Player") gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speedBullet/10;
            }
        }

        if(gameObject.tag == "Player"){

            var Dam = Instantiate(DamageShow,
            new Vector3(transform.position.x,transform.position.y,DamageShow.transform.position.z),Quaternion.identity);
            Dam.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();

            Instantiate(effectCollide,transform.position,Quaternion.identity);
            player.TakeDamage(damage);
            DoHit(gameObject);
            return;
        }else if(gameObject.tag == "HeadPlayer"){


            var Dam = Instantiate(DamageShow,
            new Vector3(transform.position.x,transform.position.y,DamageShow.transform .position.z),Quaternion.identity);
            Dam.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
            Dam.GetComponentInChildren<TextMeshProUGUI>().text = (damage+ damage/2).ToString();
            player.TakeDamage(damage + damage/2);
            DoHit(gameObject);
            return;

        }

        if(gameObject.tag == "Enemy" && this.gameObject.tag == "Bullet"){

            var Dam = Instantiate(DamageShow,
            new Vector3(transform.position.x,transform.position.y,DamageShow.transform .position.z),Quaternion.identity);
            Dam.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();

            Instantiate(effectCollide,transform.position,Quaternion.identity);
            gameObject.GetComponent<Enemy>().TakeDamgage(damage);
            DoHit(gameObject);
            return;

        }else if(gameObject.tag == "HeadEnemy" && this.gameObject.tag == "Bullet"){

            var Dam = Instantiate(DamageShow,
            new Vector3(transform.position.x,transform.position.y,DamageShow.transform .position.z),Quaternion.identity);
            Dam.GetComponentInChildren<TextMeshProUGUI>().text = (damage+ damage/2).ToString();
            Dam.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
            gameObject.GetComponentInParent<Enemy>().TakeDamgage(damage+ damage/2);
            DoHit(gameObject);
            return;


        }else return;
        //CREATE Skill
        //Destroy


    }

}
