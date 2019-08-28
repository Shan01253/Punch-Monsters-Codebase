using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWall : MonoBehaviour
{

    public int wallHealth;
    public GameObject wallOBJ;

    void Start()
    {
        wallHealth = 100;
        wallOBJ.SetActive(true);
        StartCoroutine(DecreaseHealth());
    }

    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSeconds(1);
        wallHealth -= 2;
        StartCoroutine(DecreaseHealth());
    }

    private void Update()
    {
       if(wallHealth <= 0)
       {
           wallOBJ.SetActive(false);
           Debug.Log("GAME OVER");
       }
    }
}
