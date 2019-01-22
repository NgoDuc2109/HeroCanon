using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator platformAnim;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constants.Tag.PLAYERBULLET)
        {
            GameObject clone = PoolsManager.Instance.RetrieveExplosionFromPool();
            clone.transform.position = col.transform.position;
            clone.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            clone.transform.rotation = Quaternion.identity;
            AudioManager.Instance.PlayExplosionClip();
            platformAnim.SetTrigger(Constants.Animation.ISSHOOTFLYINGGROUND);
            UIInGameManager.Instance.SetActiveText(0);
            col.gameObject.SetActive(false);
            Safezone.isEnemyAttack = true;
        }
    }
}
