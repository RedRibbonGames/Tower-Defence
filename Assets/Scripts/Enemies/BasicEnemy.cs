using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy
{
    protected GameObject go;
    protected int health;
    protected float speed;
    protected int goldWorth;
    public BasicEnemy()
    {
        go = new GameObject();
        
        go.AddComponent<BoxCollider2D>().isTrigger = true;
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<Rigidbody2D>().gravityScale = 0;
    }

    public virtual void MakeActive()
    {

    }

    public virtual void MakeElite()
    {

    }

}
