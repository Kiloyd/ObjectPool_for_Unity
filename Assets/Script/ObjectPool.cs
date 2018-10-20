using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    #region Property

    // objectPrefab will use to Instantiate when object pool default amount is inadequate
    [Header("Object Prefab Here!"), Tooltip("Drag the object prefab which you put in the Pool")]
    public GameObject objectPrefab;

    // amount means the objects amount in the pool.
    [Header("Object default amount")]
    [Tooltip("The default amount of the objects, it should be enough for the rest of the scene.\n " +
            "Otherwise, it will instantiate the prefab you assign.")]
    public int amount = 10;

    // inObjectList tracks the objects which are ready to be use.
    [SerializeField]
    private List<GameObject> inObjectList;

    // usingObjectList tracks the objects which are being used.
    [SerializeField]
    private List<GameObject> usingObjectList;

    #endregion

    #region Unity

    private void Awake()
    {
        GameObject go;
        for (int i = 0; i < amount; i++)
        {
            go = Instantiate(objectPrefab, this.transform);
            inObjectList.Add(go);

            if (go.GetComponent<Rigidbody>() != null)
                go.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    #endregion

    #region Public Method

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
            //Debug.Log("Object doesn't contain in Object Pool !");
        }
    }

    #endregion
}
