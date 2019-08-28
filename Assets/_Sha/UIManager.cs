using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* NOTES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 * [1] As of now, the score updates every 3 seconds. I want to make it update every time 
 * an enemy is hit. So as of now it will remain that way until we get the player and 
 * enemy working with collisions etc.
 */
public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text wallHPText;
    public Text waveText;

    public Slider wallHP;

    public TheWall wall;

    public int currentScore;

    private void Awake()
    {
        UpdateScore();
        wallHPText.text = "Wall HP";
        waveText.text = "Wave: ";
    }

    // Update is called once per frame
    void Update()
    {
        CalculateWallHealth();
        UpdateScore();
    }

    //EXAMPLE TO ADD TO SCORE//
    private void Start()
    {
        StartCoroutine(Score());
    }

    IEnumerator Score()
    {
        yield return new WaitForSeconds(3);
        currentScore += 1;
        StartCoroutine(Score());
    }       

    public void UpdateScore()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void CalculateWallHealth()
    {
        wallHP.value = wall.wallHealth;
    }
}
