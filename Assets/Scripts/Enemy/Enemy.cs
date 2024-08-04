using System;
using TMPro;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool ISBOSS;
    public int healCurrent;
    public int healMax;

    [SerializeField] protected int score;
    [SerializeField]protected int goldPlus;
    protected bool canAction;
    protected bool isRun;
    protected bool isRunBack = false;

    [SerializeField]protected float speed;
    [SerializeField]protected float shootingRange;
    [SerializeField]protected float safeRange;

    [SerializeField] protected float timeFire;
    [SerializeField]protected Gun gun;
    [SerializeField]protected GameObject GunSprite;

    [SerializeField]protected SpriteRenderer HeadSprite;

    [SerializeField]protected Transform posFire;
    [SerializeField] GameObject ChipPrefab;


    protected Player player;
    protected Rigidbody2D rb;
    protected Animator anim;
    protected AudioSource audioSource;

    SpriteRenderer spriteRenderer;
     HealBar healBar;
     Gold gold;
     HeadController headController;
     HighScore highScore;
     Vector3 ScaleEnemy;

  


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        gold = FindObjectOfType<Gold>();
        highScore = FindObjectOfType<HighScore>();
        headController = FindObjectOfType<HeadController>();
        healBar = GetComponentInChildren<HealBar>();
        GunSprite.GetComponent<SpriteRenderer>().sprite = gun.Sprite;
        healCurrent = healMax;
        healBar.UpdateHealBar(healCurrent,healMax);
        ScaleEnemy = transform.lossyScale;
        timeFire = gun.SpeedReload;
        RandomSpriteEnemy();

        
    }

    // Update is called once per frame
     void Update()
    {
        Action();
        CoolDown();
        Flip();
        Animation();
        CheckEnemy();

    }
    void RandomSpriteEnemy(){
        Color randomColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        spriteRenderer.color = randomColor; 
        int rd = UnityEngine.Random.Range(0,headController.listHeadEnemy.Count);
        HeadSprite.sprite = headController.listHeadEnemy[rd];

    }
    protected abstract void Fire();
    protected abstract void Move();

     void OnBecameVisible(){
        canAction = true;
    }


     void Action(){
        if(!canAction) return;
        if(Vector2.Distance(transform.position,player.transform.position) < safeRange && timeFire>0){
            KeepDistance();
        }
        else if(Vector2.Distance(transform.position,player.transform.position) > shootingRange){
            Move();
        }else if(Vector2.Distance(transform.position,player.transform.position) < shootingRange){
            if(!player.isDeal){
                Fire();
            }
        }
      
        
    }
     
    void KeepDistance(){
        isRunBack = true;
         if(player.transform.position.x < transform.position.x){
            rb.velocity = Vector2.right * speed /2 ;
        }else{
             rb.velocity = Vector2.left * speed;
        }
    }
     void Flip(){
        if(player.transform.position.x > transform.position.x){
            transform.localScale = new Vector3(-ScaleEnemy.x,ScaleEnemy.y,ScaleEnemy.z);
            // GunSprite.transform.localScale = new Vector3(-1,-1,1);
        }else{
            transform.localScale = new Vector3(ScaleEnemy.x,ScaleEnemy.y,ScaleEnemy.z);
            // GunSprite.transform.localScale = new Vector3(1,1,1);
        }
    }
    void CheckEnemy(){
        if(transform.parent != null){
            if(Vector2.Distance(transform.position,transform.parent.position) > 70) transform.SetParent(null);
        }
        if(Vector2.Distance(transform.position,Camera.main.transform.position) >400) Destroy(gameObject);
    }
    public void TakeDamgage(int damage){
    
        healCurrent -= damage;
        healBar.UpdateHealBar(healCurrent,healMax);
        if(healCurrent <=0){
            Deal();
        }
    }
     void Deal(){
        gold.PlusGold(goldPlus);
        highScore.UpdateScore(score);
        if(ISBOSS) Instantiate(ChipPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);

    }
     void CoolDown(){
        if(!canAction) return;
        timeFire -= Time.deltaTime;
    }

    void Animation(){

        anim.SetBool("Run",isRun);
        anim.SetTrigger("RunBackT");
        anim.SetBool("RunBack",isRunBack);

    }
    private void OnDrawGizmosSelected() {
        Gizmos.color  = Color.green;
        Gizmos.DrawWireSphere(transform.position,shootingRange);
        Gizmos.color  = Color.red;
        Gizmos.DrawWireSphere(transform.position,safeRange);
    }

    internal void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

}
