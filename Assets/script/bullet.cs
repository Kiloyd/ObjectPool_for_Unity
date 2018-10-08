using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private ObjectPool op;

	void Start ()
    {
        op = FindObjectOfType<ObjectPool>();
	}
	
	void Update ()
    {
        if (this.transform.position.y <= 0)
        {
            op.ReleaseObject(this.gameObject);
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

	}
}
