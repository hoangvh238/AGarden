using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : AutoMonoBehaviour
{
    [SerializeField] protected List<Transform> listPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabSetActive();
    }

    protected virtual void LoadPrefabSetActive()
    {
        Transform prefabObject = transform.Find("Prefab");
        foreach (Transform prefab in prefabObject)
            this.listPrefab.Add(prefab);
    }

    public virtual void SetObjectActive(string nameObject, Vector3 pos, Quaternion rot, bool staticObject)
    {
        Transform obj = this.GetObjectByName(nameObject);
        if (obj == null) return;

        obj.SetPositionAndRotation(pos, rot);
        obj.gameObject.SetActive(staticObject);
    }

    public virtual Transform GetObjectByName(string nameObject)
    {
        foreach (Transform objectPrefab in this.listPrefab)
            if (objectPrefab.name == nameObject) return objectPrefab;
        return null;
    }
}
