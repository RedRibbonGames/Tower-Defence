using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    Turret placeable;
    public Tile(int x, int y)
    {
        GameObject go = new GameObject("Tile" + x + "-" + y);
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Floor1");
        go.transform.position = new Vector2(x, y);
    }

    public bool PlaceTurret(Turret turret)
    {
        if (placeable != null)
        {
            Debug.LogError("There is already something in that location");
            return false;
        }

        placeable = turret;
        return true;
    }

}
