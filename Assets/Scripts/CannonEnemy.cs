using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEnemy : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float speed = 1.0f;
    private float TimeExtend = 0.0f;

    void Start(){
        Invoke("DestroyCannon", 3.0f);
    }
    

    void Update()
    {
        TimeExtend += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(Shooter.pointStart, Shooter.pointEnd, TimeExtend);
        
    }
    void DestroyCannon(){
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            DestroyCannon();
        }
    }
}
