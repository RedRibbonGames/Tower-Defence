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
    List<Vector3> path;
    private int dificulty;
    void Start()
    {
        
        dificulty = 0;
        wave = new List<BasicEnemy>();
        //InvokeRepeating("CreateEnemy", 0f, 0.5f);
        CreateWave(20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && WaveInReserve == null)
        {
            WaveInReserve = StartCoroutine(SendWave());

        }
    }
    void CreateWave(int WaveSize)
    {
        path = gameObject.GetComponent<MapGenerator>().randomPath;
        int random = Random.Range(0, WaveSize + 1);
        for (int x = 0; x < WaveSize; x++)
        {


            Crawler enemy = new Crawler(startingLocation);
            enemy.go.GetComponent<EnemyScript>().SetPath(path);

            if (x % 20 == 9)
            {
                enemy.MakeElite(2, 3);
                wave.Add(enemy);
            }
            else
            {

                wave.Add(enemy);
            }
        }
        dificulty++;
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
        CreateWave(20);

    }
}
