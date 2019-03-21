using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletGameObject;
    private static GameObject staticBulletGameObject;
    private static Queue<GameObject> bulletsQueue;

    private void Awake()
    {
        staticBulletGameObject = bulletGameObject;
        bulletsQueue = new Queue<GameObject>();
    }

    public static GameObject GetBullet()
    {
        GameObject bullet;
        if (bulletsQueue.Count != 0)
        {
            bullet = bulletsQueue.Dequeue();
            bullet.transform.position = Vector3.zero;
            bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        else
        {
            bullet = Instantiate(staticBulletGameObject);
            bullet.SetActive(false);
        }
        return bullet;
    }

    public static void PutBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletsQueue.Enqueue(bullet);
    }
}
