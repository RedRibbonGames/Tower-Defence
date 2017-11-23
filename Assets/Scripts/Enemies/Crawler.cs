using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : BasicEnemy
{


    public Crawler(Vector2 startingPosition)
    {
        go.name = "Crawler";
        go.tag = "Enemy";

        health = 100;
        speed = 3f;
        goldWorth = 2;

        go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("EnemySprites/Crawler");
        go.GetComponent<SpriteRenderer>().sortingLayerName = "Enemies";
        go.AddComponent<EnemyScript>().Setup(speed, health, goldWorth);

        go.transform.position = startingPosition;

        go.SetActive(false);
    }

    public override void MakeElite()
    {
        go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("EnemySprites/EliteCrawler");
        go.GetComponent<EnemyScript>().MakeElite();
        go.name = "EliteCrawler";
    }

    public override void MakeActive()
    {
        go.SetActive(true);
    }
}
