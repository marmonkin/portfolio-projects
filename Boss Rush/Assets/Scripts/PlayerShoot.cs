using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;

    public int PooledAmount = 20;
    List<GameObject> bulletList;

    void Start()
    {
        bulletList = new List<GameObject>();
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject obj = Instantiate(bullet); 
            obj.SetActive(false);
            bulletList.Add(obj);
        }
        InvokeRepeating("ShootProjectile", fireRate, fireRate);
    }

    public void ShootProjectile()
    {
        for (int i = 0;i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                break;
            }
        }
    }
}
