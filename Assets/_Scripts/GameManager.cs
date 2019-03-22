using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletGameObject;
    private static Queue<GameObject> bulletsQueue;
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null && GameManager.instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        GameManager.instance = this;
        DontDestroyOnLoad(GameManager.instance.gameObject);

        bulletsQueue = new Queue<GameObject>();
    }

    public static GameObject GetBullet()
    {
        GameObject bullet;
        if (bulletsQueue.Count != 0)
        {
            bullet = bulletsQueue.Dequeue();
        }
        else
        {
            bullet = Instantiate(GameManager.instance.bulletGameObject);
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
