using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret
{
    public Turret(int x, int y)
    {
        GameObject Turret = new GameObject("Turret");
        Turret.transform.position = new Vector2(x, y);
        GameObject TurretBase = new GameObject("TurretBase");
        GameObject TurretGun = new GameObject("TurretGun");

        TurretBase.transform.SetParent(Turret.transform);
        TurretBase.transform.position = new Vector2(0, 0);
        TurretGun.transform.SetParent(Turret.transform);
        TurretGun.transform.position = new Vector2(0, 0);

        TurretBase.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretBase");
        TurretGun.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretGun");
        TurretGun.AddComponent<TurretScript>();
    }

}
