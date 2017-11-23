using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

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

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            ScoreBoard.IncreaseGold(goldWorth);
            DestroyThisObject();
        }
    }
    public void Movement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
    }
    public void LookAtWaypoint()
    {
        // if waypoit reached remove from list

        if (Vector3.Distance(transform.position, pathList[0]) < 0.1f && pathList.Count > 0)
        {
            pathList.RemoveAt(0);
        }
        if (pathList.Count == 0 || (pathList.Count == 1 & Vector3.Distance(transform.position, pathList[0]) < 0.2f))
        {

            ScoreBoard.ReducesLives();
            DestroyThisObject();
            return;
        }
        Vector3 dir = pathList[0] - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

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

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }

    public void SlowMovement(float factor)
    {
        movementSpeed = (ConstantSpeed / factor);
    }

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
    public void Setup(float speed, int health, int goldWorth)
    {
        ConstantSpeed = speed;
        Health = health;
        this.goldWorth = goldWorth;
    }
    public void MakeElite()
    {
        Health = (this.Health * 2);
        goldWorth = (this.goldWorth * 3);
    }
}
