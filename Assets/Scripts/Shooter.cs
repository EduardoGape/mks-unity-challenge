using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //Spawn
    public GameObject objectToSpawn;
    public Transform objectToSpawnPosition;
    public Transform pointEnd1;
    public static Vector2 pointStart;
    public static Vector2 pointEnd;
    public static bool shoot=false;
    //public List<GameObject> positions;
    public float speed = 5.0f;
    //private int currentPosIndex = 0;

    public float maxLife = 4.0f; 
    public float currentLife = 4.0f; 
    public float decreaseValue = 1.0f; 
    public Transform fill; 
    public List<string> colliderList;
    public bool type;

    public Transform objCentral; 
    public float distance; 


    private float angle = 0f;

    
    Animator anim;
    int status;

     void Start()
    {
        anim = GetComponent<Animator>();
        status = 100;
    }



    void Update()
    {
        checkLife();
        // if (currentPosIndex < positions.Count && positions[currentPosIndex] != null)
        // {
        //     GameObject currentPos = positions[currentPosIndex];

        //     if (Vector3.Distance(transform.position, currentPos.transform.position) > 0.1f)
        //     {
        //         transform.position = Vector3.MoveTowards(transform.position, currentPos.transform.position, speed * Time.deltaTime);
        //         Quaternion newRotation = transform.rotation;
        //         newRotation.z = currentPos.transform.rotation.z;
        //         transform.rotation = newRotation;
        //     }
        //     else
        //     {
        //         currentPosIndex++;
        //     }
        // }
        // Calcula a posição do objeto em torno do objeto central usando o seno e o cosseno
        float x = objCentral.position.x + Mathf.Cos(angle) * distance;
        float y = objCentral.position.y + Mathf.Sin(angle) * distance;

        transform.position = new Vector2(x, y);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        angle += speed * Time.deltaTime;

        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
    void checkLife(){
        if(currentLife <= 2f){
            anim.SetInteger("status", 60);
        }
        else if(currentLife <= 1f){
            anim.SetInteger("status", 40);
        }
        else if(currentLife <= 0f){
           anim.SetInteger("status", 0);
            Destroy(gameObject);
        }
        
    }

    void callShoot(){
        pointStart = objectToSpawnPosition.position;
        pointEnd = pointEnd1.position;
        Instantiate(objectToSpawn, objectToSpawnPosition.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AreaPlayer")
        {
            Invoke("callShoot", 1.0f);
        }
        foreach (string colliderTag in colliderList)
        {
            if (collision.gameObject.tag == colliderTag)
            {
                currentLife -= decreaseValue;
                currentLife = Mathf.Clamp(currentLife, 0, maxLife);
                fill.localScale = new Vector3(currentLife, 1.0f, 0);
                break;
            }
        }
    }

}
