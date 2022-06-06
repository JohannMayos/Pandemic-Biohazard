using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   private void onTriggerEnter2D(Collider2D col){

        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
   }
}
