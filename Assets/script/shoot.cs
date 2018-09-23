using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add Release() situation
public class shoot : MonoBehaviour
{
    private GameObject go;
    private objectPool op;

    public Vector3 v;
    public Vector3 offset;

    private void Start()
    {
        op = FindObjectOfType<objectPool>();
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
