using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Spawn
    public GameObject objectToSpawn;
    public Transform objectToSpawnPosition;
    ///object direction ball
    public Transform pointEnd1;
    public Transform pointEnd2;
    public Transform pointEnd3;
    ///object direction ball static
    public static Vector2 pointEnd;
    public static Vector2 pointStart;
    public static Vector3 position;
    //variable float 
    private float moveSpeed = 5f;
    private float rotationSpeed = 100f;
    private float timeInit = 0f;
    private float timeMax = 5f; 
    private bool canShoot = true; 
    private float shotDifferential;
    //variable vector2
    private Vector2 direction;
    //Controller Button
    public GameObject _buttonRun;
    public GameObject _buttonManivela1;
    public GameObject _buttonManivela2;
    public GameObject _buttonShot;
    public GameObject _buttonTripleShot;
    Button _BtnRun;
    Button _BtManivela1;
    Button _BtnManivela2;
    Button _BtnShot;
    Button _BtnTripleShot;

    public float maxLife = 4.0f; 
    public float currentLife = 4.0f; 
    public float decreaseValue = 1.0f; 
    public Transform fill; 
    public List<string> colliderList; 

    Animator anim;
    int status;


    void Start()
    {
        direction = new Vector2(0,0);
        _BtnRun = _buttonRun.GetComponent<Button> ();
        _BtManivela1 = _buttonManivela1.GetComponent<Button> ();
        _BtnManivela2 = _buttonManivela2.GetComponent<Button> ();
        _BtnShot = _buttonShot.GetComponent<Button>();
        _BtnTripleShot = _buttonTripleShot.GetComponent<Button>();
        anim = GetComponent<Animator>();
        status = 100;
    }

    void Update()
    {
        position = transform.position;   
        pointStart = objectToSpawnPosition.position;
        rotationPlayer(_BtManivela1.input);
        rotationPlayer(-_BtnManivela2.input);
        movimentPlayer(_BtnRun.input );
        checkLife();
    }
    void checkLife(){
        Debug.Log(currentLife);
        if(currentLife <= 0.9f){
            anim.SetInteger("statusLife", 60);
        }
        else if(currentLife <= 0.6f){
            anim.SetInteger("statusLife", 40);
        }
        else if(currentLife <= 0.3f){
           anim.SetInteger("statusLife", 20); 
        }
        else if(currentLife == 0){
           anim.SetInteger("statusLife", 0);
            Destroy(gameObject);
            GameManager.LoadsTheNextsScene("EndGame");
        }
    }
    void callShoot1ParametersTriplo1(){
        callShoot(pointEnd1.position);
    }
    void callShoot1ParametersTriplo2(){
        callShoot(pointEnd2.position);
    }
    void callShoot1ParametersTriplo3(){
        callShoot(pointEnd3.position);
    }

    void callShoot(Vector2 pointEndVector){
        pointEnd = pointEndVector;
        Instantiate(objectToSpawn, objectToSpawnPosition.position, Quaternion.identity);
    }

    public void BtnShoot(bool triple){
        if(!triple){
            callShoot(pointEnd2.position);
        }
        else{
            Invoke("callShoot1ParametersTriplo1", 0.1f);
            Invoke("callShoot1ParametersTriplo2", 0.3f);
            Invoke("callShoot1ParametersTriplo3", 0.2f);
            
        }

    }

    void movimentPlayer(float vertical){
        transform.Translate(Vector2.up * -vertical  * moveSpeed * Time.deltaTime);
    }

    void rotationPlayer(float rotation){
        transform.Rotate(0f, 0f, rotation * rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
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
