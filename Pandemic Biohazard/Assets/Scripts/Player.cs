using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public GameObject bulletProjectile;
    public Transform Gun;
    private bool shot;
    public float shotForce;
    private bool flipX = false;

    void Start(){

        anim = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
        shot = Input.GetButtonDown("Fire1");
        Shot();
    }

    private void Shot(){
        if(shot == true){
            GameObject temp = Instantiate(bulletProjectile);
            temp.transform.position = Gun.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shotForce, 0f);
            Destroy(temp.gameObject, 1.5f);
        }
    }


    private void FlipBullet(){

        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        shotForce *= -1;

    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Enemy"){
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Traps"){
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        

    }


    void Move(){
        Vector3 movement =  new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position = transform.position + movement * speed * Time.deltaTime;

        if(flipX == true && Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            FlipBullet();
        }

        if(Input.GetAxis("Vertical") > 0f){
            anim.SetBool("Climb", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

         if(Input.GetAxis("Vertical") < 0f){
            anim.SetBool("Climb", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }


        if(flipX == false && Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("Walk", true);
           // transform.eulerAngles = new Vector3(0f, 180f, 0f);
            FlipBullet();
        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("Walk", false);
        }

        if(Input.GetAxis("Vertical") == 0f){
            anim.SetBool("Climb", false);
        }
        
    }
}
