using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform target;
    public float wallMunchDelay = 2;
    public float forceMultiplier = 1;
    public float forceIncrease = 2;
    private float currentForceMultiplier;
    public Color dilutionColor = Color.red;
    public float dilutionRate = 0.1f;
    Rigidbody2D rb;
    public float speed;
    public float flinchTime = 0.5f;
    public float fallTime = 2f;
    private StateMachine machine = new StateMachine();
    // Start is called before the first frame update
    private SpriteRenderer sprite;

    float start = 0;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        machine.ChangeTo(new M_Pursue(rb, target, transform, speed));
        sprite = GetComponent<SpriteRenderer>();
        currentForceMultiplier = forceMultiplier;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 velocity = (target.position - transform.position).normalized * speed;
        //rb.velocity = velocity;
        machine.Execute();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Glove"))
        {
            rb.AddForce(-(target.position - transform.position).normalized * currentForceMultiplier, ForceMode2D.Force);
            machine.ChangeTo(new M_Flinch(flinchTime, OnFinishedFlinchingCallback));

            sprite.color = (sprite.color + dilutionRate * dilutionColor) / (1 + dilutionRate);
            currentForceMultiplier += forceIncrease;
        }
        
           
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Time.time - start > wallMunchDelay)
            {
                TheWall.Instance.DecreaseHealth();
            }
        }
    }

    public void OnFinishedFlinchingCallback()
    {
        Debug.Log("Finished Flinching");
        machine.ChangeTo(new M_Pursue(rb, target, transform, speed));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enemy Disabled!");
        currentForceMultiplier = forceMultiplier;
        machine.ChangeTo(new M_Fall(sprite, transform, fallTime));
        UIManager.Instance.IncrementScore();
    }

}
