using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(1, 1000)]
    private float speedUp;
    [SerializeField]
    [Range(1, 1000)]
    private float speedDown;

    private void Update()
    {
        RotateGun();
    }

    private void RotateGun()
    {
        if (OnClickEventScript.Instance.isTouch == true && OnClickEventScript.Instance.isCanShoot == true)
        {
            if (transform.rotation.z >= 0.7f)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                return;
            }
            transform.Rotate(Vector3.forward, Time.deltaTime * speedUp);
        }
        else
        {
            if (transform.rotation.z <= 0)
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                return;
            }
            transform.Rotate(Vector3.back, Time.deltaTime * speedDown);
        }
    }
}
