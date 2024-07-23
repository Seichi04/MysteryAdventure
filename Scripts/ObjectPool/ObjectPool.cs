using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private  Dictionary<string, List<GameObject>> pooledObjects = new Dictionary<string, List<GameObject>>();

    [SerializeField] List<ObjectData> Prefab = new();


    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for(int i=0; i< Prefab.Count;i++)
        {
            for(int j=0; j< Prefab[i].AmountToPool ;j++)
            {
                GameObject obj = Instantiate(Prefab[i].GameObjectPrefab);
                obj.transform.parent = transform;
                obj.SetActive(false);
                if(!pooledObjects.ContainsKey(Prefab[i].NameGameObjectPrefab))
                {
                    pooledObjects.Add(Prefab[i].NameGameObjectPrefab,new List<GameObject>());
                }
                pooledObjects[Prefab[i].NameGameObjectPrefab].Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string name)
    {
        for(int i=0;i<pooledObjects[name].Count;i++)
        {
            if(!pooledObjects[name][i].activeInHierarchy)
            {
                return pooledObjects[name][i];
            }
        }
        CreateObject(name, 1);
        for(int i=0;i<pooledObjects[name].Count;i++)
        {
            if(!pooledObjects[name][i].activeInHierarchy)
            {
                return pooledObjects[name][i];
            }
        }
        Debug.Log(name +" null");
        return null;
    }

    public List<GameObject> GetListPooledObject(string name,int quantity)
    {
        int count=0;
        List<GameObject> list = new List<GameObject>();
        for(int i=0;i<pooledObjects[name].Count;i++)
        {
            if(!pooledObjects[name][i].activeInHierarchy)
            {
                list.Add(pooledObjects[name][i]);
                count++;
                if(count == quantity)
                {
                    return list;
                }
            }
        }
        if(count < quantity)
        {
            CreateObject(name,quantity - count);
            for(int i=0;i<pooledObjects[name].Count;i++)
            {
                if(!pooledObjects[name][i].activeInHierarchy)
                {
                    list.Add(pooledObjects[name][i]);
                    count++;
                    if(count == quantity)
                    {
                        return list;
                    }
                }
            }
        }


        return list;
    } 


    public void CreateObject(string name, int quantity)
    {
        ObjectData prefab = Prefab.Find(obj => obj.NameGameObjectPrefab == name);
        for(int i=0;i< quantity;i++)
        {
            GameObject obj = Instantiate(prefab.GameObjectPrefab);
            obj.transform.parent = transform;
            obj.SetActive(false);
            if(!pooledObjects.ContainsKey(prefab.NameGameObjectPrefab))
            {
                pooledObjects.Add(prefab.NameGameObjectPrefab,new List<GameObject>());
            }
            pooledObjects[prefab.NameGameObjectPrefab].Add(obj);
        }
    }
}
