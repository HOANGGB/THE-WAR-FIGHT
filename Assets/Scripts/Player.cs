using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed;

    [SerializeField] float highJump;
    
    [SerializeField] float coolDownFire;
    [SerializeField] float timeFire;

    [SerializeField] bool isGrounded;

    [SerializeField] GameObject PointBullet;
    [SerializeField] GameObject BulletGameOject;
    public Gun GunCurrent;

    [SerializeField] Joystick joystickAttack;
    [SerializeField] Joystick joystickMove;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Action();

        CoolDown();
       
    }
    void Action(){
        Move();
        Fire();
        Flip();
        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || joystickMove.Vertical >0.5f){
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Data.ResetKey();
        }
    }

    void Move(){
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(joystickMove.Horizontal !=0){
            rb.velocity = new Vector2(joystickMove.Horizontal * speed, rb.velocity.y);
        }
    }
    void Flip(){
        if(joystickAttack.Horizontal <0){
            transform.localScale = new Vector3(-1,1,1);
        }else if(joystickAttack.Horizontal>=0){
            transform.localScale = new Vector3(1,1,1);

        }
    }
    void Jump(){
        if(isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, highJump);
        }
    }
    void Fire(){
        if(timeFire >0) return;
        if(joystickAttack.Horizontal !=0 || joystickAttack.Vertical != 0){
            Vector2 direction = new Vector3(joystickAttack.Horizontal, joystickAttack.Vertical);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            var bullet = Instantiate(GunCurrent.Bullet, PointBullet.transform.position, Quaternion.Euler(0, 0, angle));
            bullet.GetComponent<Rigidbody2D>().velocity  =  direction.normalized * GunCurrent.speedBullet;
            timeFire = GunCurrent.SpeedReload;
        }
    }



    void CoolDown(){
        timeFire -= Time.deltaTime;
    }

 private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
