using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    public Text myText;
    public UnityEngine.UI.Slider mySlider;
    public bool type;

    void Update() {
        
        myText.text = (mySlider.value*60).ToString();

        if(type){
            GameManager.DurationGame = mySlider.value*60;
        }
        else{
            GameManager.SpawnEnemyTime = mySlider.value*60;
        }
    }

}
