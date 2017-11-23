using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    // Use this for initialization
    List<BasicEnemy> wave;
    float timeBetweenWaves = 0.5f;
    Coroutine WaveInReserve;
    Vector2 startingLocation = new Vector2(3, 6);
    void Start()
    {
        wave = new List<BasicEnemy>();
        //InvokeRepeating("CreateEnemy", 0f, 0.5f);
        CreateWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && WaveInReserve == null)
        {
            WaveInReserve = StartCoroutine(SendWave());

        }
    }
    void CreateWave()
    {
        for (int x = 0; x < 5; x++)
        {
            Crawler enemy = new Crawler(startingLocation);

            if (x == 2)
            {
                enemy.MakeElite();
                wave.Add(enemy);
            }
            else
            {

                wave.Add(enemy);
            }

        }
        Debug.Log(wave.Count);
    }
    public IEnumerator SendWave()
    {
        foreach (BasicEnemy enemy in wave)
        {
            enemy.MakeActive();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        WaveInReserve = null;
        wave.Clear();
        CreateWave();
    }
}
