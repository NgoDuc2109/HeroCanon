using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private const string createNewCloud = "CreateNewCloud";
    private void Start()
    {
        InvokeRepeating(createNewCloud,0,5f);
    }

    public void CreateNewCloud()
    {
        float randomScale = Random.Range(3,6f);
        Vector3 temp = new Vector3 (Camera.main.orthographicSize /2 + 5f ,Random.Range(-20,53),0);
        GameObject clone = PoolsManager.Instance.RetrieveCloudFromPool();
        clone.transform.position = temp;
        clone.transform.localScale = new Vector3(randomScale,randomScale,0);
        clone.transform.rotation = Quaternion.identity;
    }
}
