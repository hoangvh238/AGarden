using System.Collections.Generic;
using UnityEngine;

public class RandEnemy : AutoMonoBehaviour
{
    [Header("List Enemy Information")]
    [SerializeField] protected int sizeList;
    protected List<List<StructMonsterGet>> listEnemy;

    [Header("Level enemy list")]
    [SerializeField] protected List<StructMonsterGet> easyEnemy;
    [SerializeField] protected List<StructMonsterGet> normalEnemy;
    [SerializeField] protected List<StructMonsterGet> hardEnemy;

    private void Update()
    {
        this.sizeList = this.listEnemy.Count;
    }

    public virtual void AddElement(StructMonsterGet key, int type)
    {
        if (type == 0) this.easyEnemy.Add(key);
        if (type == 1) this.normalEnemy.Add(key);
        if (type == 2) this.hardEnemy.Add(key);
    }

    public virtual void DeclareLists()
    {
        this.easyEnemy = new List<StructMonsterGet>();
        this.normalEnemy = new List<StructMonsterGet>();
        this.hardEnemy = new List<StructMonsterGet>();
        this.listEnemy = new List<List<StructMonsterGet>>();
    }

    public virtual void Declare()
    {
        this.AddList(this.easyEnemy);
        this.AddList(this.normalEnemy);
        this.AddList(this.hardEnemy);

        this.CheckRemove();
    }

    protected virtual void AddList(List<StructMonsterGet> list)
    {
        this.listEnemy.Add(list);
    }

    protected virtual void CheckRemove()
    {
        for (int i = 0; i < this.listEnemy.Count; i++)
            if (this.listEnemy[i].Count == 0) this.listEnemy.RemoveAt(i);
    }

    protected virtual int CheckType(string a)
    {
        if (a == "skeleton") return 0;
        if (a == "pumpkin") return 1;
        if (a == "witch") return 2;
        if (a == "wolf") return 3;
        if (a == "ghost") return 4;
        if (a == "dracular") return 5;
        return 0;
    }

    
}
