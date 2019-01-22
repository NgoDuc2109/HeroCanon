using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class OnClickEventScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public static OnClickEventScript Instance;
    [HideInInspector]
    public bool isTouch;
    [HideInInspector]
    public bool isCanShoot;
    private Transform GunPosition;
    private Transform spawnPoint;
    private Vector3 direction;
    [SerializeField]
    [Range(1,100)]
    private float speed;
    private Animator playerAnim;
    private GameObject player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        isCanShoot = true;
        player = GameObject.FindGameObjectWithTag(Constants.Tag.PLAYER);
    }
    private void Start()
    {
        GunPosition = GameObject.FindGameObjectWithTag(Constants.Tag.GUN).transform;
        spawnPoint = GameObject.FindGameObjectWithTag(Constants.Tag.SPAWNPOINTBULLET).transform;
        playerAnim = player.transform.root.gameObject.GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isTouch = false;
        if (isCanShoot == true)
        {
            direction = spawnPoint.position - GunPosition.position;
            GameObject clone;
            if (BulletControl.TotalCombo ==4)
            {
                clone = PoolsManager.Instance.RetrievePlayerBulletFromPool(1);
            }
            else
            {
                 clone = PoolsManager.Instance.RetrievePlayerBulletFromPool(0);
            }
            clone.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().enabled = false;
            clone.transform.position = spawnPoint.position;
            clone.transform.rotation = Quaternion.identity;
            clone.GetComponent<Rigidbody2D>().velocity = direction * speed;
            clone.transform.Find("Trail").gameObject.GetComponent<TrailRenderer>().enabled = true;
            AudioManager.Instance.PlayShootAudio();
            playerAnim.Play(Constants.Animation.PLAYERATTACK);
            isCanShoot = false;
        }         
    }
}
