using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : BasicEnemy
{


    public Crawler(Vector2 startingPosition)
    {
        // Identifie the object
        go.name = "Crawler";
        go.tag = "Enemy";

        // Give the object ingame values
        health = 30;
        speed = 2f;
        goldWorth = 10;
        go.AddComponent<EnemyScript>().Setup(speed, health, goldWorth);

        // Give the object ingame visuals
        go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("EnemySprites/Crawler");
        go.GetComponent<SpriteRenderer>().sortingLayerName = "Enemies";
    
        // Give the object a starting position
        go.transform.position = startingPosition;

        // Because of how our wave system works the object 
        // will be deactivated when it is first created
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
