using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform trans;
    public Transform target;
    private Vector3 offset;
    public float speedMove = 1;
    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
        offset = trans.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        trans.position = Vector3.Lerp(trans.position, target.position + offset, Time.deltaTime * speedMove);
    }
}
