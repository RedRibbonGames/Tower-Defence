using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path
{
    public int x;
    public int y;
    public GameObject go;
    public Path(int x, int y)
    {
        go = new GameObject("Path" + x + "-" + y);
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretBase");
        go.transform.position = new Vector2(x, y);
        this.x = x;
        this.y = y;
    }
}
