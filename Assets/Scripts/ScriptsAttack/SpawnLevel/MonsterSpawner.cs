using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> monsterPrefab;
    // 0 skeleton 1 pumpkin 2 witch 3 wolf 4 ghost 5 dracula
    static public MonsterSpawner instance;
    private void Awake()
    {
        instance = this;    
    }

    public void SpawnMonster(string nameObject, int positionSpawn)
    {  
        Vector3 pos = this.transform.GetChild(positionSpawn).transform.position;
        Quaternion rota = this.transform.GetChild(positionSpawn).rotation;

        Transform monsterClone = EnemySpawner.Instance.Spawn(nameObject, pos, rota);
        monsterClone.gameObject.SetActive(true);
    }
}


