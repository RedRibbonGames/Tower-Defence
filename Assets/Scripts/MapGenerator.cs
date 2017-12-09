using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    // Use this for initialization
    GameObject tileHolder;
    GameObject pathHolder;
    public List<Vector3> randomPath;
    void Start()
    {
        pathHolder = GameObject.Find("PathHolder");
        tileHolder = GameObject.Find("TileHolder");
        randomPath = new List<Vector3>();
        GenerateRandomPath();
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
                //if (GeneratePath(x, y))
                //{
                //    continue;
                //}

                if (randomPath.Contains(new Vector3(x,y)))
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

    private void GenerateRandomPath()
    {
        Vector2 start = new Vector2(3, 6);
        Vector2 end = new Vector2(18, 8);
        Vector2 currentNode = start;

        int randomX = (int)Random.Range(currentNode.x + 1, currentNode.x + 5);
        int randomY = (int)Random.Range(currentNode.y + 1, currentNode.y + 5);

        Vector2 randomNode = new Vector2(randomX, randomY);

       
        bool xComplete = false;
        bool yComplete = false;
        int counter = 0;
        while (!xComplete || !yComplete)
        {
            if (counter == 400)
            {
                Debug.Log("Oops");
                return;
            }
            int direction = Random.Range(0, 2);


            switch (direction)
            {
                case 0:
                for (int x = (int)currentNode.x; x <= (int)randomNode.x; x++)
                {
                    if (x == (int)randomNode.x)
                    {
                        Debug.Log("X completed");
                        xComplete = true;
                    }
                    Path p = new Path(x, (int)currentNode.y);
                    p.go.transform.SetParent(pathHolder.transform);
                    currentNode = new Vector2(x + 1, currentNode.y);
                    randomPath.Add(currentNode);

                    Debug.Log("Current Node " + currentNode);
                    break;
                }
                break;
                case 1:
                for (int y = (int)currentNode.y; y <= (int)randomNode.y; y++)
                {
                    if (y == (int)randomNode.y)
                    {
                        Debug.Log("Y completed");
                        yComplete = true;
                    }
                    Path p = new Path((int)currentNode.x, y);
                    p.go.transform.SetParent(pathHolder.transform);

                    currentNode = new Vector2(currentNode.x, y + 1);
                    randomPath.Add(currentNode);

                    Debug.Log("Current Node " + currentNode);
                    break;
                }
                break;
            }

            if(currentNode.x == randomNode.x && currentNode.y == randomNode.y)
            {
                currentNode = randomNode;

                randomX = (int)Random.Range(end.x + 1, end.x + 5);
                randomY = (int)Random.Range(end.y + 1, end.y + 5);

                randomNode = new Vector2(randomX, randomY);

                xComplete = false;
                yComplete = false;

            }
            counter++;
        }
    }
}
