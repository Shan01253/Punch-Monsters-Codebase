using UnityEngine;

internal class M_Pursue : IState
{
    private Rigidbody2D rb;
    private Transform target;
    private Transform transform;
    private float speed;
    //private float speedRefreshRate;

    public M_Pursue(Rigidbody2D rb, Transform target, Transform transform, float speed)
    {
        this.rb = rb;
        this.target = target;
        this.transform = transform;
        this.speed = speed;
        //this.speedRefreshRate = speedRefreshRate;
    }
    float starttime;
    public void Enter()
    {
        starttime = Time.time;
    }

    public void Execute()
    {
        //if (Time.time - starttime > speedRefreshRate)
        //{
            //starttime = Time.time;
            rb.velocity = (target.position - transform.position).normalized * speed;
        //}

    }

    public void Exit()
    {
       
    }
}