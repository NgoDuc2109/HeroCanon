using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GiftCoinEvent : MonoBehaviour
{
    [SerializeField]
    private Animator coinAnim;

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == Constants.Tag.PLATFORM)
        {
            AudioManager.Instance.PlayCoinAudio();
            coinAnim.SetTrigger("isTrigger");
            StartCoroutine(DelayDisable(gameObject));
            //PlayerPrefs.SetFloat(Constants.ScoreInfo.TOTALCOINS, PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS) + 1);
            //UIInGameManager.Instance.TotalCoins.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS).ToString();
            //UIInGameManager.Instance.TotalCoinsInShop.text = PlayerPrefs.GetFloat(Constants.ScoreInfo.TOTALCOINS).ToString();
        }
    }

    IEnumerator DelayDisable(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        coinAnim.ResetTrigger("isTrigger");
        obj.SetActive(false);
        obj.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
