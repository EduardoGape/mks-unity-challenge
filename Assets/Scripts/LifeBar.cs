using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public float maxLife = 4.0f; 
    public float currentLife = 4.0f; 
    public float decreaseValue = 1.0f; 
    public Transform fill; 
    public List<string> colliderList;
    public bool type;
    

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
