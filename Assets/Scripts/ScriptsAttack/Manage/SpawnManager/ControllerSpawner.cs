using UnityEngine;

public class ControllerSpawner : AutoMonoBehaviour
{
    [SerializeField] protected int bNumber = 1;
    private static ControllerSpawner instance;

    [SerializeField] protected Spawn spawn;
    [SerializeField] protected RandNumber randNumber;
    [SerializeField] protected SpawnProcess spawnProcess;
    [SerializeField] protected GameObject dayPresent;

    public int BNumber { get => this.bNumber; }
    public static ControllerSpawner Instance => instance;
    public GameObject DayPresent { get => this.dayPresent; }
    public RandNumber RandNumber { get => this.randNumber; }
    public SpawnProcess SpawnProcess { get => this.spawnProcess; }
    public Spawn Spawn { get => this.spawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawn();
        ControllerSpawner.instance = this;
    }

    protected virtual void LoadSpawn()
    {
        if (this.spawn != null) return;
        this.spawn = transform.Find("Spawn").GetComponent<Spawn>();
        Debug.Log(transform.name + ": Load Spawn", gameObject);
    }

    private void Update()
    {
        Transform createEnemy = transform.Find("CreateEnemy");
        this.dayPresent = createEnemy.Find("Day " + TimeController.Instance.DayPresent.ToString()).gameObject;
    }
}
