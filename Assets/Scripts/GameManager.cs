using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float DurationGame;
    public static float SpawnEnemyTime;
    private float timeInit = 0f;
    private bool EndGame = false;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Game"))
        {
            timeInit =+ Time.deltaTime;
            if (Time.time - timeInit >= DurationGame * 60 && !EndGame)
            {
                LoadsTheNextsScene("EndGame");
                EndGame = true;
            }
        }
    }
    
    
    public static void LoadsTheNextsScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
