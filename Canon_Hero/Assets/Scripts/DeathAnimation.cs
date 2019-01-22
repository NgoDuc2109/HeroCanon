using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float torque;
    private void OnEnable()
    {
        rb.AddForce(new Vector2(Random.Range(10, 20), Random.Range(60, 90)) * 130000 * Time.deltaTime);
        rb.AddTorque(-torque);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Constants.Tag.GAMECONTROLLER)
        {
            gameObject.SetActive(false);
        }
    }
}
