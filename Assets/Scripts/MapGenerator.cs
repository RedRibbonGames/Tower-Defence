using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    // Use this for initialization

    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GenerateMap()
    {
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                if (GeneratePath(x, y))
                {
                    continue;
                }
                Tile t = new Tile(x, y);
            }
        }
    }

    private bool GeneratePath(int x, int y)
    {

        return false;
    }
}
