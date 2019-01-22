using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bg;
    [SerializeField]
    private float offset;
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == Constants.Tag.CHECKPOINT)
        {
            for (int i = 0; i < bg.Length; i++)
            {
                if (bg[i] == gameObject)
                {
                    StartCoroutine(Delay(i));
                }
            }
        }
    }

    IEnumerator Delay( int i)
    {
        yield return new WaitForSeconds(1f);
        bg[i].transform.localPosition = new Vector3(165, 0, 0);
    }
}
