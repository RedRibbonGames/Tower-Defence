using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : Tower
{
    public Laserbeam(int x, int y)
    {
        Turret.name = "Laserbeam";
        TurretGun.name = "Laserbeam";

        Turret.transform.position = new Vector2(x, y);

        TurretGun.AddComponent<LineRenderer>().material = Resources.Load<Material>("laser");
        TurretGun.GetComponent<LineRenderer>().startWidth = 0.06f;
        TurretGun.GetComponent<LineRenderer>().endWidth = 0.06f;
        TurretGun.GetComponent<LineRenderer>().startColor = Color.white;
        TurretGun.GetComponent<LineRenderer>().endColor = Color.cyan;

        TurretBase.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretBase");
        TurretGun.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Laserbeam");

        Cost = 70;
        TurretGun.AddComponent<LaserbeamScript>();
        
    }
}
