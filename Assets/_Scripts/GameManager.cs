using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletGameObject;
    public Transform bulletAnchor;
    public Transform screenBounds;
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

        FitScreenBounds();
    }

    public void FitScreenBounds()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;
        screenBounds.transform.localScale = new Vector3(width, height, 2);
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
            bullet.transform.SetParent(GameManager.instance.bulletAnchor);
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
