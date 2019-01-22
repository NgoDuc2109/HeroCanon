using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDisalbe : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
