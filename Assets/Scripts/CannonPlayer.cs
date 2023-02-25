using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPlayer : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float speed = 1.0f;
    private float TimeExtend = 0.0f;

    private Vector2 PointStart;
    private Vector2 PointEnd;

    void Start(){
        Invoke("DestroyCannon", 4.0f);
        PointStart = PlayerController.pointStart;
        PointEnd = PlayerController.pointEnd;
    }

    void Update()
    {
        TimeExtend += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(PointStart, PointEnd, TimeExtend);
    }

    void DestroyCannon(){
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chanser" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Shooter")
        {
            DestroyCannon();
        }
    }
}
