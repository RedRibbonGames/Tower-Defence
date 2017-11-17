using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    // Use this for initialization
    List<Vector2> pathList = new List<Vector2>();
    GameObject tileHolder;
    GameObject pathHolder;
    void Start()
    {
        pathHolder = GameObject.Find("PathHolder");
        tileHolder = GameObject.Find("TileHolder");
        GenerateMap();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GenerateMap()
    {

        for (int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                if (GeneratePath(x, y))
                {
                    continue;
                }
                Tile t = new Tile(x, y);
                t.go.transform.SetParent(tileHolder.transform);
            }
        }
    }

    private bool GeneratePath(int x, int y)
    {

        if (x == 3 && y >= 6 && y < 14)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (y == 8 && x == 12)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (y == 13 && x >= 4 && x < 7)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }

        if (y == 7 && x >= 7 && x <= 12)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (y == 9 && x >= 8 && x <= 12)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (y == 12 && x >= 9 && x <= 16)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (y == 8 && x >= 17 && x <= 19)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (x == 6 && y >= 7 && y < 13)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (x == 8 && y >= 10 && y < 13)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        if (x == 16 && y >= 8 && y < 12)
        {
            Path p = new Path(x, y);
            p.go.transform.SetParent(pathHolder.transform);
            return true;
        }
        return false;
    }
}
