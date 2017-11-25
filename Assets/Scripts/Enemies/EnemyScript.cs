using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    /* 
        This script will be added to each enemy.
    */
    public int Health { get; set; }
    public float ConstantSpeed { get; private set; }

    public List<Vector3> pathList;
    private float movementSpeed;

    public int goldWorth;
    // Use this for initialization
    void Start()
    {
        movementSpeed = ConstantSpeed;
        pathList = new List<Vector3>();
        SetPath();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtWaypoint();
        Movement();

    }

    // The enemy will take damage based on the incoming damage. 
    // If the enemy dies it will give the player gold based 
    // base on how much de enemy is worth
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            ScoreBoard.IncreaseGold(goldWorth);
            DestroyThisObject();
        }
    }

    // This will make the Object move
    public void Movement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
    }


    public void LookAtWaypoint()
    {
        // Check to see if we reached out NEXT waypoint.
        // Remove the waypoint from our path if we have reached it.

        if (Vector3.Distance(transform.position, pathList[0]) < 0.1f && pathList.Count > 0)
        {
            pathList.RemoveAt(0);
        }

        // Check to see if we have reached the LAST waypoint.
        // If the waypoint has been reached:
        //  - Reduce the lives that the player has
        //  - Remove the object from the scene
        if (pathList.Count == 0 || (pathList.Count == 1 & Vector3.Distance(transform.position, pathList[0]) < 0.2f))
        {

            ScoreBoard.ReducesLives();
            DestroyThisObject();
            return;
        }

        // If we reach this part of the code it means the checks above have done their job
        // and we can now make our enemy look at the next waypoint.
        Vector3 dir = pathList[0] - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Add waypoint to our path
    public void SetPath()
    {

        pathList.Add(new Vector2(3, 6));
        pathList.Add(new Vector2(3, 13));
        pathList.Add(new Vector2(6, 13));
        pathList.Add(new Vector2(6, 7));
        pathList.Add(new Vector2(12, 7));
        pathList.Add(new Vector2(12, 9));
        pathList.Add(new Vector2(8, 9));
        pathList.Add(new Vector2(8, 12));
        pathList.Add(new Vector2(16, 12));
        pathList.Add(new Vector2(16, 8));
        pathList.Add(new Vector2(19, 8));
    }

    // Remove an object from the scene
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    // Calculate the new speed of an object after it has been slowed
    public void SlowMovement(float factor)
    {
        movementSpeed = (ConstantSpeed / factor);
    }

    // Reset the speed of an object after it is out of the 
    // Slowarea range
    public void ResetSpeed()
    {
        movementSpeed = ConstantSpeed;
    }

    public void SetSpeed(float speed)
    {
        ConstantSpeed = speed;
    }
    public void SetHealth(int health)
    {
        this.Health = health;
    }
    public void SetGoldWorth(int worth)
    {
        goldWorth = worth;
    }

    // Pass the values that are set in a type of enemy's class
    // to this script
    public void Setup(float speed, int health, int goldWorth)
    {
        ConstantSpeed = speed;
        Health = health;
        this.goldWorth = goldWorth;
    }

    // Make an elite version of the enemy
    public void MakeElite()
    {
        Health = (this.Health * 2);
        goldWorth = (this.goldWorth * 3);
    }
}
