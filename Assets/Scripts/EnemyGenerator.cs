using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateEnemy", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateEnemy();
        }
	}

    public void CreateEnemy()
    {
        Vector2 startingLocation = new Vector2(3, 6);
        Enemy enemy = new Enemy(startingLocation);
    }
}
