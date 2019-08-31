using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWall : MonoBehaviour
{
    public static TheWall Instance;
    public float healthDecreasePerHit = 0.5f;
    public float wallHealth = 100;
    public GameObject wallOBJ;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        wallHealth = 100;
        wallOBJ.SetActive(true);
    }

    public void DecreaseHealth()
    {
        wallHealth -= healthDecreasePerHit;
    }

    private void Update()
    {
       if(wallHealth <= 0)
       {
            GameOver();
       }
    }

    public void GameOver()
    {
        wallOBJ.SetActive(false);
        Debug.Log("GAME OVER");
    }
}
