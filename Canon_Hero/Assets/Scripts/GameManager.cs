using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class Bullet
{
    public GameObject normalBullet;
    public GameObject superBullet;
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    private Transform spawnPointPlayer;
    [SerializeField]
    private GameObject enemyVsGround;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private List<GameObject> playerPrefabs;
    [SerializeField]
    private ObjectPoolScript normalBullet, superBullet;
    [SerializeField]
    private List<Bullet> bullets;
    [SerializeField]
    private Animator flyingGroundAnim;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Instantiate(playerPrefabs[PlayerPrefs.GetInt(Constants.CharacterInfo.CURRENTPLAYER)], spawnPointPlayer.position, Quaternion.identity);
        normalBullet.pooledObject = bullets[PlayerPrefs.GetInt(Constants.CharacterInfo.CURRENTPLAYER)].normalBullet;
        superBullet.pooledObject = bullets[PlayerPrefs.GetInt(Constants.CharacterInfo.CURRENTPLAYER)].superBullet;
    }


    private void Start()
    {
        enemyVsGround.transform.position = new Vector3(Random.Range(1f, 27f), Random.Range(-21f, 15f), 0);

    }

    public void InstatiateEnemy()
    {
        StartCoroutine(Delay());
    }

    private void SetPosition()
    {
        enemy.SetActive(true);
        enemyVsGround.SetActive(true);
        if (ScoreManager.Instance.CurrentScore < 10)
        {
            enemyVsGround.transform.position = new Vector3(Camera.main.orthographicSize / 2 + 8, Random.Range(-21f, 15f), 0);
            enemyVsGround.transform.DOMoveX(Random.Range(1f, 27f), 1.5f);
        }
        else
        {
            enemyVsGround.transform.position = new Vector3(Camera.main.orthographicSize / 2 + 8, Random.Range(-21f, 40f), 0);
            enemyVsGround.transform.DOMoveX(Random.Range(1f, 27f), 1.5f);
        }
    }
    IEnumerator Delay()
    {
        enemy.SetActive(false);
        yield return new WaitForSeconds(1f);
        enemyVsGround.SetActive(false);
        yield return new WaitForSeconds(3f);
        SetPosition();
    }

}
