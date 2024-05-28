using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : AutoMonoBehaviour
{
    [SerializeField] protected int dayPresent = 1;
    [SerializeField] protected int dayMax = 5;

    [SerializeField] protected float dayMili;
    [SerializeField] protected float dayMiliMax = 60;

    [SerializeField] protected float daySec;
    [SerializeField] protected float daySecMax = 180;

    [SerializeField] protected static TimeController instance;

    public static TimeController Instance => instance;
    public int DayMax => this.dayMax;
    public int DayPresent => this.dayPresent;
    public float DaySecMax => this.daySecMax;
    public float DaySec => this.daySec;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        TimeController.instance = this;
    }

    protected virtual void Update()
    {
        this.IncreaseMili();
        this.IncreaseDay();
    }

    protected virtual void IncreaseMili()
    {
        this.dayMili = this.dayMili + 1;
        if (this.dayMili < this.dayMiliMax) return;

        this.daySec = this.daySec + 1;
        this.dayMili = 0;
    }

    protected virtual void IncreaseDay()
    {
        if (this.daySec < this.daySecMax) return;
        this.dayPresent = this.dayPresent + 1;
        this.daySec = 0;

        this.ChangeDay();
    }

    protected virtual void ChangeDay()
    {
        managerWeather.manaWeather.changeWeather();
        ControllerSpawner.Instance.SpawnProcess.CreateProcess(180, 0);
    }
}
