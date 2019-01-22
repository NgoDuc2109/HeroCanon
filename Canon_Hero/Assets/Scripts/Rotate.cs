using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    [Range(1,100)]
    private float speed;
	void Update ()
    {
        transform.Rotate(Vector3.forward* Time.deltaTime*speed);
	}
}
