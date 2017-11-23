using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowtower : Tower
{


    public Slowtower(int x, int y)
    {
        Turret.name = "SlowTower";
        Turret.layer = LayerMask.NameToLayer("Tower");
        Turret.transform.position = new Vector2(x, y);

        TurretGun.AddComponent<CircleCollider2D>().isTrigger = true;
        TurretGun.GetComponent<CircleCollider2D>().radius = 2f;

        Debug.Log(LayerMask.NameToLayer("Slowarea"));
        TurretGun.layer = LayerMask.NameToLayer("Slowarea");
        TurretBase.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretBase");
        TurretGun.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Slowturret");

        TurretGun.AddComponent<SlowtowerScript>();
    }
}
