using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public List<Transform> positions;
    public GameObject objectToSpawn;
    public float speed;
    private bool colliderPlayer = false;

    void Update() {
        if(colliderPlayer){
            Vector2 direction = PlayerController.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AreaPlayer"){
            colliderPlayer = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(objectToSpawn, positions[0].position, Quaternion.identity);
            Instantiate(objectToSpawn, positions[1].position, Quaternion.identity);
            Instantiate(objectToSpawn, positions[2].position, Quaternion.identity);
            Instantiate(objectToSpawn, positions[3].position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
