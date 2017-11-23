using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int x;
    public int y;
    public GameObject go;
    public bool hasTower { get; set; }
    public Tile(int x, int y)
    {
        go = new GameObject("Tile" + x + "-" + y);
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Floor");
        go.AddComponent<BoxCollider2D>();
        go.layer = LayerMask.NameToLayer("Tile");
        go.transform.position = new Vector2(x, y);
        go.tag = "Tile";
        this.x = x;
        this.y = y;
    }
}
