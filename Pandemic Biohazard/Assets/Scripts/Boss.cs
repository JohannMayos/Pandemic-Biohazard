using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    private Animator anim;
    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthbar;
    public GameObject bulletProjectile;
    public Transform Gun;
    private bool shot;
    public float shotForce;
    private bool flipX = false;
    

    void Start(){

        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        shot = true;
    }


    public void LookAtPlayer(){

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped){
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            
        }
        else{
            if(transform.position.x < player.position.x && !isFlipped){
                transform.localScale = flipped;
                transform.Rotate(0f,180f,0f);
                isFlipped = true;
                
            }
        }
    }

    public void Shot(){
        if(shot == true){
            GameObject temp = Instantiate(bulletProjectile);
            temp.transform.position = Gun.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shotForce, 0f);
            Destroy(temp.gameObject, 1.5f);
        }
    }

    public void FlipBullet(){

        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        shotForce *= -1;

    }

    void TakeDamage(int damage){
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        anim.SetTrigger("Die");
        Destroy(gameObject, 0.9f);
        GameController.instance.ShowVictory();
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
        
            anim.SetTrigger("Damage");
            Destroy(col.gameObject);
            TakeDamage(100);
            
            
            
        }

    
    }
}
