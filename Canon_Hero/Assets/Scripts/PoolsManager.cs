using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsManager : MonoBehaviour
{
    public static PoolsManager Instance;
    [SerializeField]
    private ObjectPoolScript []  playerBullet;
    [SerializeField]
    private ObjectPoolScript enemyBullet;
    [SerializeField]
    private ObjectPoolScript giftCoin;
    [SerializeField]
    private ObjectPoolScript[] cloud;
    [SerializeField]
    private ObjectPoolScript explosion;
    [SerializeField]
    private ObjectPoolScript[] enemyBody;
    [SerializeField]
    private ObjectPoolScript[] enemyGun;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject RetrievePlayerBulletFromPool(int number)
    {
        ObjectPoolScript tempPool;
        GameObject obj;
        tempPool = playerBullet[number];
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = tempPool.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }

    public GameObject RetrieveEnemyBulletFromPool()
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = enemyBullet.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }

    public GameObject RetrieveCloudFromPool()
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = cloud[(int) Random.Range(0,cloud.Length-1)].GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }
    public GameObject RetrieveGiftCoinFromPool()
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = giftCoin.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }

    public GameObject RetrieveExplosionFromPool()
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = explosion.GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }
    public GameObject RetrieveEnemyBodyFromPool(int number)
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = enemyBody[number].GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }
    public GameObject RetrieveEnemyGunFromPool(int number)
    {
        GameObject obj;
        //new GameObject named obj and it calls GetPooledObejct on the tempPool. 
        obj = enemyGun[number].GetPooledObject();
        obj.SetActive(true);
        //objectPoolScript named tempPool gets accesses the elements in the array at position R
        return obj;
    }
}
