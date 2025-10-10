using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    private List<GameObject> poolList = new();

    public GameObject GetGameObject()
    {
        foreach (var obj in poolList)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
       
        GameObject newObj = Instantiate(Prefab,transform);
        poolList.Add(newObj);
        return newObj;
       
    }
   
}
