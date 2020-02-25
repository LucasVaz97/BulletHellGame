using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RenderArea : MonoBehaviour
{
    private EnemyController enemyController;


    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("ForegroundObject") || collider.CompareTag("Bullet")) {
            Destroy(collider.gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Enemy")){
            enemyController = collider.gameObject.GetComponent<EnemyController>();
            if(enemyController){
                if(!enemyController.active){
                    enemyController.Activate();
                }
            }
        }
    }
}
