using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoolObj : AutoMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = gameObject.transform.Find("Holder").transform;
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabObj = gameObject.transform.Find("Prefab").transform;
        foreach (Transform prefab in prefabObj)
            this.prefabs.Add(prefab);
    }

    public virtual Transform Spawn(string namePrefab, Vector3 postion, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(namePrefab);
        if (prefab == null)
        {
            Debug.LogError("Can find the object in prefabs list.");
            return null;
        }

        Transform poolPrefab = this.GetPrefabFromPool(prefab); 
        poolPrefab.SetPositionAndRotation(postion, rotation);

        poolPrefab.SetParent(this.holder);
        return poolPrefab;
    }

    protected virtual Transform GetPrefabFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs) 
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }

        Transform newPool = Instantiate(prefab);
        newPool.name = prefab.name;
        return newPool;
    }

    public virtual Transform GetPrefabByName(string namePrefab)
    {
        foreach (Transform prefab in this.prefabs)
            if (prefab.name == namePrefab) return prefab;
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
