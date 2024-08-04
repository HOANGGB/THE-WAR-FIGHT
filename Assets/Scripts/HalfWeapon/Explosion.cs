using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public string tagHit = "";

    [SerializeField] bool canHit;
    [SerializeField] GameObject DamageShow;
    [SerializeField] GameObject sound;
    [SerializeField] float timeDestroy;
    

    float time;

    void Start()
    {
        Instantiate(sound,transform.position,Quaternion.identity);
        Destroy(gameObject,timeDestroy);
    }
    private void Update() {
        time -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player" && tagHit =="Enemy" && canHit){
            if(time>0)return;
             var Dam = Instantiate(DamageShow,
            new Vector3(transform.position.x,transform.position.y + 3,DamageShow.transform .position.z),Quaternion.identity);
            Dam.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            other.GetComponent<Player>().TakeDamage(damage);
            time = .1f;
        }
        if((other.tag == "Enemy"  || other.tag == "HeadEnemy") && tagHit =="Player" && canHit){
            if(time>0)return;
             var Dam = Instantiate(DamageShow,
            new Vector3(Random.Range(transform.position.x-1,transform.position.x+2),transform.position.y + 3,DamageShow.transform .position.z),Quaternion.identity);
            Dam.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            if(other.tag =="Enemy") other.GetComponent<Enemy>().TakeDamgage(damage);
            else  other.GetComponentInParent<Enemy>().TakeDamgage(damage);
            time = .1f;
        }
    }
}
