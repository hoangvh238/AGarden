using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float SpawnEnemy(StructSpawn listSpawn)
    {
        int pos1 = this.CreateRandom(-1, -1, -1);
        int pos2 = this.CreateRandom(-1, -1, pos1);
        int pos3 = this.CreateRandom(-1, pos1, pos2);

        if (this.CheckEnemy(listSpawn.enemyOne)) this.SpawnEnemy(this.GetNameObject(listSpawn.enemyOne.name), pos1);

        if (this.CheckEnemy(listSpawn.enemyTwo)) this.SpawnEnemy(this.GetNameObject(listSpawn.enemyTwo.name), pos2);

        if (this.CheckEnemy(listSpawn.enemyThree)) this.SpawnEnemy(this.GetNameObject(listSpawn.enemyThree.name), pos3);

        return listSpawn.ratetime;
    }

    protected virtual string GetNameObject(string name)
    {
        return name.Remove(name.Length - 5, 5);
    }

    protected void SpawnEnemy(string name, int pos)
    {
        MonsterSpawner.instance.SpawnMonster(name, pos);
    }

    protected bool CheckEnemy(Transform enemy)
    {
        return enemy != null;
    }

    protected int CreateRandom(int pos1, int pos2, int pos3)
    {
        int key = Random.Range(0, 5);
        while (key == pos1 || key == pos2 || key == pos3)
            key = Random.Range(0, 5);
        return key;
    }
}
