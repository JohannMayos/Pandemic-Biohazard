using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            GameController.instance.StartBoss();
        }
    }
}
