using UnityEngine;

public class SpawnProcess : RandNumber
{
    [Header("ax + b = y && minutes ")]
    [SerializeField] protected int bNumber = 1;
    [SerializeField] protected float secMax = 180;

    [Header("Object Process")]
    [SerializeField] protected DaySpawnProcess daySpawnProcess;
    [SerializeField] protected ListSpawner listSpawner;

    protected override void Reset()
    { 
        base.Reset();   
        this.LoadListSpawner();
        this.CreateProcess(this.secMax, 0);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
       /* this.LoadSecMax();*/
       /* this.LoadBNumber();*/
        this.LoadDaySpawnProcess();
    }

    protected virtual void LoadDaySpawnProcess()
    {
        if (this.daySpawnProcess != null) return;
        this.daySpawnProcess = transform.parent.GetComponent<DaySpawnProcess>();
        Debug.Log(transform.name + ": Load DaySpawnProcess", gameObject);
    }

    protected virtual void LoadListSpawner()
    {
        if (this.listSpawner != null) return;
        this.listSpawner = transform.parent.GetComponentInChildren<ListSpawner>();
        Debug.Log(transform.name + ": Load ListSpawner", gameObject);
    }

    protected virtual void LoadSecMax()
    {
        if (this.secMax != -1) return;
        this.secMax = TimeController.Instance.DaySecMax;
        Debug.Log(transform.name + ": Load SecMax", gameObject);
    }

    protected virtual void LoadBNumber()
    {
        if (this.bNumber != -1) return;
        this.bNumber = ControllerSpawner.Instance.BNumber;
        Debug.Log(transform.name + ": Load bNumber", gameObject);
    }

    public virtual void CreateProcess(float timeDay, float timeNow)
    {
        if (timeNow > timeDay) return;

        float rateTime = this.CheckRateTime(timeNow);
        int minStep = this.CheckMinStep(timeNow, rateTime);

        int step = this.CreateNumber(minStep, (float) timeNow / timeDay);

        StructSpawn key = this.daySpawnProcess.CreateEnemies(step, timeNow);
        if (key == null) this.CreateProcess(timeDay, timeNow);

        key.ratetime = step * rateTime;
        this.listSpawner.AddElement(key);

        this.CreateProcess(timeDay, timeNow + step * rateTime);
    }

    protected virtual int CheckMinStep(float timeNow, float rateTime)
    {
        int key = (int) (timeNow / (this.secMax / 6));
        int value = (int) (((key + 1) * (this.secMax / 6) - timeNow) / rateTime);
        return Mathf.Max(1, value);
    }

    protected virtual float CheckRateTime(float timeNow)
    {
        int key = (int) (timeNow / (this.secMax / 6));

        float function = key * this.GetDayNumber(transform.parent.name) + this.bNumber;
        return (this.secMax / 6) / function;
    }

    public virtual int GetDayNumber(string dayPresent)
    {
        return (int)(dayPresent[dayPresent.Length - 1] - '0');
    }
}
