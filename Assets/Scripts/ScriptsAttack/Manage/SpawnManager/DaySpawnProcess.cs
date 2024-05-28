using System.Collections.Generic;
using UnityEngine;

public class DaySpawnProcess: AutoMonoBehaviour
{
    [SerializeField] protected int numberEnemy;

    [Header("List Manager")]
    [SerializeField] protected List<StructMonsterGet> listEnemyAppear;
    [Space(25)]

    [SerializeField] protected int totalDayEnemy;
    [SerializeField] protected List<Transform> listDayEnemy;
    [Space(25)]

    [SerializeField] protected int totalNightEnemy;
    [SerializeField] protected List<Transform> listNightEnemy;

    [SerializeField] protected List<List<Transform>> listRandom;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.CheckNumberEnemy();
        this.LoadListDayEnemy();
        this.LoadListNightEnemy();
        this.listRandom = new List<List<Transform>>();
        this.listRandom.Add(this.listDayEnemy);
    }

    protected override void Awake()
    {
       //For override
    }

    protected virtual void LoadListNightEnemy()
    {
        this.listNightEnemy.Clear();
        this.totalNightEnemy = 0;

        Transform listEnemy = transform.Find("ListEnemy");
        foreach (Transform enemy in listEnemy)
            if (CheckEnemy(enemy, true))
            {
                this.listNightEnemy.Add(enemy);
                this.totalNightEnemy += enemy.gameObject.GetComponent<EnemySpawn>().NumberForCreate;
            }
    }

    protected virtual void LoadListDayEnemy()
    {
        this.listDayEnemy.Clear();
        this.totalDayEnemy = 0;

        Transform listEnemy = transform.Find("ListEnemy");
        foreach (Transform enemy in listEnemy)
            if (CheckEnemy(enemy, false))
            {
                this.listDayEnemy.Add(enemy);
                this.totalDayEnemy += enemy.gameObject.GetComponent<EnemySpawn>().NumberForCreate;
            }
    }

    protected virtual bool CheckEnemy(Transform enemy, bool isNight)
    {
        if (enemy.name == "GhostSpawn") return isNight;
        if (enemy.name == "DracularSpawn") return isNight;
        if (enemy.name == "WolfSpawn") return isNight;
        if (enemy.GetComponent<EnemySpawn>().NumberForCreate == 0) return !isNight;
        return !isNight;
    }

    protected void CheckNumberEnemy()
    {
        SpawnProcess key = GetComponentInChildren<SpawnProcess>();
        this.numberEnemy = 15 * key.GetDayNumber(gameObject.name) + ControllerSpawner.Instance.BNumber * 6;
    }

    public virtual StructSpawn CreateEnemies(int number, float time)
    {
        StructSpawn keyStruct = new StructSpawn();

        for (int i = 1; i <= number; i++)
        {
            Transform objectSpawn = this.Create(time);

            if (i == 1) keyStruct.enemyOne = objectSpawn;
            if (i == 2) keyStruct.enemyTwo = objectSpawn;
            if (i == 3) keyStruct.enemyThree = objectSpawn;
        }
        return keyStruct;
    }

    protected virtual void UpdateTotalLists(Transform objectSpawn, bool isNight)
    {
        objectSpawn.GetComponent<EnemySpawn>().DeductNumber(1);
        if (isNight) this.LoadListNightEnemy();
        else this.LoadListDayEnemy();
    }

    protected virtual Transform Create(float time)
    {
        if (time >= 120) this.listRandom.Add(this.listNightEnemy);

        if (this.totalDayEnemy <= 0) this.RemoveList(this.listDayEnemy);
        if (this.totalNightEnemy <= 0) this.RemoveList(this.listNightEnemy);

        if (this.listRandom.Count == 0) return null;
        int keyRandom = Random.Range(0, this.listRandom.Count);

        List<Transform> listChoosen = this.listRandom[keyRandom];
        int keyRandomEnemy = Random.Range(0, listChoosen.Count);

        if (keyRandom == 0) this.UpdateTotalLists(listChoosen[keyRandomEnemy], false);
        else this.UpdateTotalLists(listChoosen[keyRandomEnemy], true);

        return listChoosen[keyRandomEnemy];
    }

    protected virtual void RemoveList(List<Transform> list)
    {
        this.listRandom.Remove(list);
    }

}
