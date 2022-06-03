using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Animator anim;

    void Start(){

        anim = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        Vector3 movement =  new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position = transform.position + movement * speed * Time.deltaTime;

        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(Input.GetAxis("Vertical") > 0f){
            anim.SetBool("Climb", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

         if(Input.GetAxis("Vertical") < 0f){
            anim.SetBool("Climb", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }


        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("Walk", false);
        }

        if(Input.GetAxis("Vertical") == 0f){
            anim.SetBool("Climb", false);
        }
        
    }
}
