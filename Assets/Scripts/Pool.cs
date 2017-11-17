using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    public static List<GameObject> BulletPool;
    // Use this for initialization
    void Start()
    {
        BulletPool = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void DeactivateObjectAndAddToPool(GameObject bullet)
    {
        
        bullet.transform.position = new Vector2(-10, -10);
        bullet.gameObject.SetActive(false);
        BulletPool.Add(bullet);
        //Debug.Log(BulletPool.Count);
    }

    public static GameObject GetBulletFromPool()
    {
        if(BulletPool.Count <= 0)
        {
            return null;
        }
        GameObject temp = BulletPool[0];
        BulletPool.Remove(temp);
        return temp;
    }
}
