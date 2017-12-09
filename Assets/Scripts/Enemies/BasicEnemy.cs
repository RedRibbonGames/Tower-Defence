using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicEnemy
{


    /*
        All enemies will enherite from this class.
        
    */
    public GameObject go;
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


    public abstract void MakeActive();
    public abstract void MakeStronger(float speed, int health, int gold);

    // The make elite function will enemies stronger
    // and have a diffrent sprite 
    public abstract void MakeElite(int healthFactor, int goldFactor);

}
