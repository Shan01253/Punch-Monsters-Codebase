using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float waveDelay = 20;
    public float spawnDelayTime = 1;
    public Transform perimeter;

    public float forceMultiplier = 25;
    public float forceIncreasePerHit = 9;
    public float dilutionRate = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveDifficultyIncrease());
    }
    float start = Time.time;
    // Update is called once per frame
    void Update()
    {

        if (Time.time - start > spawnDelayTime * Random.Range(0.8f, 1.2f))
        {
            start = Time.time;
            float angle = Mathf.PI * 2 * Random.value;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)*(perimeter.localScale.x/2)+perimeter.position;
            Debug.Log(pos);
            GameObject g = ObjectPooler.Instance.SpawnFromPool("monster", pos, Quaternion.identity);
            g.transform.localScale = Vector3.one;
            g.transform.rotation = Quaternion.Euler(0, 0, 0);
            g.GetComponent<SpriteRenderer>().color = Color.white;
            Monster m = g.GetComponent<Monster>();
            m.forceMultiplier = forceMultiplier;
            m.forceIncrease = forceIncreasePerHit;
            m.dilutionRate = dilutionRate;
        }

    }

    IEnumerator WaveDifficultyIncrease()
    {
        yield return new WaitForSeconds(waveDelay);
        forceMultiplier -= 0.5f;
        forceIncreasePerHit -= 0.5f;
        spawnDelayTime -= 0.05f;
        dilutionRate -= 0.01f;
        UIManager.Instance.IncrementWave();
        StartCoroutine(WaveDifficultyIncrease());
    }

}
