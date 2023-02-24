using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    private List<Vector3> position = new List<Vector3>();
    public GameObject Obj;

    void Update(){
        Invoke("CreateMapRandom",10.0f);
    }

    void CreateMapRandom()
    {
        Vector3 positionRandom = new Vector3(Random.Range(-100.0f, -100.0f),Random.Range(-50.0f, -50.0f),0);

        if(checkArea(positionRandom)){
            Instantiate(Obj, positionRandom, Quaternion.identity);
            position.Add(positionRandom);
        }
        else{
            CreateMapRandom();
        }
    }

    bool checkArea(Vector3 positionV)
    {
        foreach (Vector3 positionArmazenada in position)
        {
            float distance = Vector3.Distance(positionV, positionArmazenada);
            if (distance <= 10.0f)
            {
                return false;
            }
        }
        return true;
    }
}
