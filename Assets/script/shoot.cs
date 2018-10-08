using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private GameObject go;
    private ObjectPool op;

    public Vector3 v;
    public Vector3 offset;

    private void Start()
    {
        op = FindObjectOfType<ObjectPool>();
    }

    void shootObject()
    {
        go = op.GetObject();
        go.transform.position = this.transform.position + offset;
        go.GetComponent<Rigidbody>().isKinematic = false;
        go.GetComponent<Rigidbody>().velocity = v;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
            shootObject();
    }
}
