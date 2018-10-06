using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add maximum amount
public class objectPool : MonoBehaviour {

    // Parameter
   
    [SerializeField]
    private List<GameObject> inObjectList;
    [SerializeField]
    private List<GameObject> usingObjectList;
    private bool reset;

    public GameObject objectPrefab;
    public Transform returnTransform;
    
    // Monobehavior

    private void Start()
    {
        // Add the Children Objects to the inObjectList, which means the elements are unassigned.
        GameObject go;
        for (int i = 0; i < transform.childCount; i++)
        {
            go = transform.GetChild(i).gameObject;
            inObjectList.Add(go);

            if (go.GetComponent<Rigidbody>() != null)
                go.GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    // public method
    public GameObject GetObject()
    {
        GameObject obj;
        if (inObjectList.Count == 0)
        {
            obj = Instantiate(objectPrefab, this.transform, false);
            usingObjectList.Add(obj);
            return obj;
        }
        else
        {
            obj = inObjectList[0];
            usingObjectList.Add(obj);
            inObjectList.RemoveAt(0);

            return obj;
        }
    }

    public void ReleaseObject(GameObject obj)
    {
        if (usingObjectList.Contains(obj))
        {
            obj.transform.position = this.transform.position;
            inObjectList.Add(obj);
            usingObjectList.Remove(obj);
        }
        else
        {
            Debug.Log("Object doesn't contain in Object Pool !");
        }
    }
}
