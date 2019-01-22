using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScrollBackground : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> bg;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float timeScrollMap;
    private Animator playerAnim;
    public static ScrollBackground Instance;
    private GameObject player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        player = GameObject.FindGameObjectWithTag(Constants.Tag.PLAYER);
    }

    private void Start()
    {
        playerAnim = player.transform.root.gameObject.GetComponent<Animator>();
    }
    public void Scroll()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        // wait 1s for enemy's animation
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < bg.Count; i++)
        {
            bg[i].transform.DOMoveX(bg[i].transform.position.x - offset, timeScrollMap);
        }
        playerAnim.Play(Constants.Animation.PLAYERMOVE);
        AudioManager.Instance.PlayWalkAudio();
        // wait 2s for next turn
        yield return new WaitForSeconds(3f);
        OnClickEventScript.Instance.isCanShoot = true;
    }
}
