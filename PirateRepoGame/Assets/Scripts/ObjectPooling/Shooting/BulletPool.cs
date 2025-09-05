using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (bulletPool.Count > 0)
        {
            GameObject obj = bulletPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        return Instantiate(bulletPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        bulletPool.Enqueue(obj);
    }
}
