using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public static int TotalCombo;
    private Rigidbody2D rb;
    private GameObject enemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag(Constants.Tag.ENEMY);
    }
    void Update()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void InstatiateEnemyDeath()
    {
        GameObject bodyClone = PoolsManager.Instance.RetrieveEnemyBodyFromPool(0);
        bodyClone.transform.position = enemy.transform.position;
        bodyClone.transform.rotation = Quaternion.identity;
        GameObject gunEnemyClone = PoolsManager.Instance.RetrieveEnemyGunFromPool(0);
        gunEnemyClone.transform.position = enemy.transform.position + new Vector3(0, 6, 0);
        gunEnemyClone.transform.rotation = Quaternion.identity;
    }

    private void InstatiateEnemyDeath1()
    {
        GameObject bodyClone = PoolsManager.Instance.RetrieveEnemyBodyFromPool(1);
        bodyClone.transform.position = enemy.transform.position;
        bodyClone.transform.rotation = Quaternion.identity;
        GameObject gunEnemyClone = PoolsManager.Instance.RetrieveEnemyGunFromPool(1);
        gunEnemyClone.transform.position = enemy.transform.position + new Vector3(0, 6, 0);
        gunEnemyClone.transform.rotation = Quaternion.identity;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constants.Tag.ENEMY)
        {
            TotalCombo++;        
        }
        if (col.tag == Constants.Tag.ENEMY_HEAD)
        {
            InstatiateExplosion(col.gameObject);
            if (TotalCombo == 5)
            {
                SetCombo();
            }
            else
            {
                gameObject.SetActive(false);
                AudioManager.Instance.PlayExplosionClip();
                InstatiateEnemyDeath1();
                ActiveGiftCoin(6);
                AddCoin(6);
                ScoreManager.Instance.AddScore(2);
                UIInGameManager.Instance.SetActiveText(2);
                UIInGameManager.Instance.ChangeCurrentScoreTextOnIngamePanel();
                GameManager.Instance.InstatiateEnemy();
                ScrollBackground.Instance.Scroll();
            }        
        }
        else if (col.tag == Constants.Tag.ENEMY_BODY)
        {
            InstatiateExplosion(col.gameObject);
            if (TotalCombo == 5)
            {
                SetCombo();
            }
            else
            {
                gameObject.SetActive(false);
                AudioManager.Instance.PlayExplosionClip();
                InstatiateEnemyDeath();
                ActiveGiftCoin(4);
                AddCoin(4);
                ScoreManager.Instance.AddScore(1);
                UIInGameManager.Instance.ChangeCurrentScoreTextOnIngamePanel();
                GameManager.Instance.InstatiateEnemy();
                UIInGameManager.Instance.SetActiveText(1);
                ScrollBackground.Instance.Scroll();
            }            
        }
        else if (col.tag == Constants.Tag.PLAYER)
        {
            InstatiateExplosion(col.gameObject);
            AudioManager.Instance.PlayExplosionClip();
            gameObject.SetActive(false);
            col.gameObject.transform.root.gameObject.SetActive(false);
            UIInGameManager.Instance.ShowGameOverPanel();
        }
    }

    private void AddCoin(int number)
    {
        PlayerPrefs.SetFloat(Constants.ScoreInfo.TOTALCOINS, PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS) + number);
        UIInGameManager.Instance.TotalCoins.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS).ToString();
        UIInGameManager.Instance.TotalCoinsInShop.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS).ToString();
    }

    private void InstatiateExplosion(GameObject obj)
    {
        GameObject clone = PoolsManager.Instance.RetrieveExplosionFromPool();
        clone.transform.position = obj.transform.position;
        clone.transform.localScale = new Vector3(2, 2, 2);
        clone.transform.rotation = Quaternion.identity;
    }

    private void SetCombo()
    {
        TotalCombo = 0;
        ActiveGiftCoin(10);
        AddCoin(10);
        AudioManager.Instance.PlayExplosionClip();
        InstatiateEnemyDeath();
        ScoreManager.Instance.AddScore(5);
        UIInGameManager.Instance.SetActiveText(3);
        UIInGameManager.Instance.ChangeCurrentScoreTextOnIngamePanel();
        gameObject.SetActive(false);
        GameManager.Instance.InstatiateEnemy();
        ScrollBackground.Instance.Scroll();
    }

    private void ActiveGiftCoin(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject clone = PoolsManager.Instance.RetrieveGiftCoinFromPool();
            clone.transform.position = enemy.transform.position;
            clone.transform.rotation = Quaternion.identity;
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-10, 10), Random.Range(20, 40), 0);
        }
    }
}
