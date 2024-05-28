using System.Collections.Generic;
using UnityEngine;

public class ListSpawner : AutoMonoBehaviour
{
    public List<StructSpawn> list;

    protected override void Reset()
    {
        base.Reset();
        this.list = new List<StructSpawn>();
    }

    public virtual float RequestSpawn(int count)
    {
        if (count < 0 || count >= this.list.Count) return 0;
        return ControllerSpawner.Instance.Spawn.SpawnEnemy(this.list[count]);
    }

    public virtual void AddElement(StructSpawn key)
    {
        this.list.Add(key);
    }
    
    public virtual void RemoveAllElement()
    {
        for (int i = 0; i < this.list.Count; i++)
            this.list.RemoveAt(i);
    }
}
