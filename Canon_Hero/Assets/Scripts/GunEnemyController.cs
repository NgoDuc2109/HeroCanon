using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GunEnemyController : MonoBehaviour
{
    [SerializeField]
    private Animator enemyAnim;
    private GameObject player;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    [Range(1, 100)]
    private float speedBullet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Constants.Tag.PLAYER);
    }
    private void LateUpdate()
    {
        if (Safezone.isEnemyAttack == true)
        {
            RotateGunEnemy();
            Safezone.isEnemyAttack = false;
        }
    }
    public void RotateGunEnemy()
    {
        Vector3 startDirection = new Vector3(-enemy.transform.position.x,0,0);
        Vector3 endDirection = player.transform.position  - enemy.transform.position;
        float Cos = (startDirection.x * endDirection.x + startDirection.y * endDirection.y) / (Mathf.Sqrt(startDirection.x*startDirection.x + startDirection.y*startDirection.y)*Mathf.Sqrt(endDirection.x*endDirection.x + endDirection.y*endDirection.y));
        transform.DOLocalRotate(new Vector3(0, 0, transform.rotation.eulerAngles.z + Mathf.Acos(Cos) * 180 / Mathf.PI),0.5f);
        StartCoroutine(ShootPlayer(endDirection));
    }

    IEnumerator ShootPlayer(Vector3 direction)
    {
        yield return new WaitForSeconds(1f);
        GameObject clone = PoolsManager.Instance.RetrieveEnemyBulletFromPool();
        clone.transform.position = spawnPoint.position;
        clone.transform.rotation = Quaternion.identity;
        clone.GetComponent<Rigidbody2D>().velocity = direction * speedBullet;
        AudioManager.Instance.PlayShootAudio();
        enemyAnim.SetTrigger(Constants.Animation.ISATTACK);
    }
}
