using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistance : MonoBehaviour
{
    [SerializeField] GameObject cube;

    void Update()
    {
        float dis = Vector3.Distance(this.transform.position, cube.transform.position);
        Debug.Log("‹——£ : " + dis);
    }
}

