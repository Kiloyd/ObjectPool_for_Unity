using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private objectPool op;

	void Start ()
    {
        op = FindObjectOfType<objectPool>();
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
