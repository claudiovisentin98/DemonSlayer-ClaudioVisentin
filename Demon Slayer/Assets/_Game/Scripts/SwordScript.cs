using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
    public bool isInRange = false;
    public BoxCollider trigger;
    public ZombieAI enemy;
    public bool animationtrigger;
   


    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag ("Enemy"))
        {
            enemy = col.gameObject.GetComponent<ZombieAI>();
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            enemy = null;
            isInRange = false;
        }
    }
    void isAttacking()
    {
        if (isInRange == true)
        {
            animationtrigger = true;
            enemy.health -= 1;
        }
    }
}
