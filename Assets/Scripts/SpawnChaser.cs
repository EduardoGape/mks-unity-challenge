using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChaser : MonoBehaviour
{
    public GameObject Chaser; 
    public float IntervalTime = GameManager.SpawnEnemyTime; 
    private float TimeDistance = 0f;
    public bool colliderPlayer = false;

    void Update()
    {
        if(colliderPlayer){
            TimeDistance += Time.deltaTime;
            if (TimeDistance >= IntervalTime)
            {
                TimeDistance = 0f;
                Instantiate(Chaser, transform.position, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "AreaPlayer") {
            colliderPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "AreaPlayer") {
            colliderPlayer = false;
        }
    }
}
