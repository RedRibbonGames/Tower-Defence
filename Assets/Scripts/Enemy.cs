﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public GameObject go;
    public Enemy(Vector2 startingPosition)
    {
        go = new GameObject("Enemy");
        go.tag = "Enemy";
        go.AddComponent<BoxCollider2D>();
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Diamond");
        go.AddComponent<EnemyScript>();
        go.AddComponent<Rigidbody2D>().gravityScale = 0;
        go.transform.position = startingPosition;
    }
}
