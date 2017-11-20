using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public GameObject go;
    public Enemy(Vector2 startingPosition)
    {
        go = new GameObject("Enemy");
        go.tag = "Enemy";
        go.AddComponent<BoxCollider2D>().isTrigger = true;
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("EnemySprites/BlackVehicle");
        go.GetComponent<SpriteRenderer>().sortingLayerName = "Enemies";
        go.AddComponent<Rigidbody2D>().gravityScale = 0;
        go.AddComponent<EnemyScript>();
        go.transform.position = startingPosition;
    }
}
