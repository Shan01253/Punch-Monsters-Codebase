using UnityEngine;

internal class M_Fall : IState
{
    private SpriteRenderer sprite;
    private Transform transform;
    private float fallTime;
    Color c;
    public M_Fall(SpriteRenderer sprite, Transform transform, float fallTime)
    {
        this.sprite = sprite;
        this.transform = transform;
        this.fallTime = fallTime;
    }
    float startTime = Time.time;
    public void Enter()
    {
        c = sprite.color;
    }

    public void Execute()
    {
        if (Time.time - startTime > fallTime)
        {
            Debug.Log("fell");
            sprite.color = Color.white;
            transform.rotation = Quaternion.identity;
            transform.localEulerAngles = Vector3.one;
            transform.gameObject.SetActive(false);
        }
        
        c.a = (1 - ((Time.time - startTime)/ fallTime));
        //Debug.Log(c.a);
        transform.localScale = c.a * Vector3.one;
        transform.rotation.SetEulerAngles(Vector3.forward * c.a);
        sprite.color = c;
    }

    public void Exit()
    {


    }
}