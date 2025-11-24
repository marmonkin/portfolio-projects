using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    enum Pattern { Straight, Spin, SideToSide }

    [Header("Bullet Stuff")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float lifetime;

    [Header("Spawner Stuff")]
    [SerializeField] private float fireRate;
    [SerializeField] private Pattern pattern;
    [SerializeField] private float spinRotation;
    [SerializeField] private int PooledAmount = 20;


    private Quaternion rotation;

    List<GameObject> bulletList;


    void Start()
    {
        rotation = transform.localRotation;

        bulletList = new List<GameObject>();
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            bulletList.Add(obj);
        }

        switch (pattern)
        {
            case Pattern.Straight:
                transform.localRotation = rotation;
                InvokeRepeating("SimpleAttack", fireRate, fireRate);
                break;

            case Pattern.Spin:
                transform.localRotation = rotation;
                InvokeRepeating("SpinAttack", fireRate, fireRate);
                break;

            case Pattern.SideToSide:

                break;
        }

        
    }
    private void SimpleAttack()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.localRotation;
                bulletList[i].SetActive(true);
                bulletList[i].GetComponent<EnemyBullet>().speed = bulletSpeed;
                bulletList[i].GetComponent<EnemyBullet>().lifetime = lifetime;

                break;
            }
        }
    }

    private void SpinAttack()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                bulletList[i].GetComponent<EnemyBullet>().speed = bulletSpeed;
                bulletList[i].GetComponent<EnemyBullet>().lifetime = lifetime;
                transform.Rotate(0, 0, spinRotation);
                break;
            }
        }
    }


    private void OnDisable()
    {
        CancelInvoke();
    }

}
