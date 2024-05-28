using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AutoMonoBehaviour
{
    [SerializeField] protected EnemyDamagedReceiver dameRec;
    [SerializeField] protected EnemyDamagedSender dameSen;
    [SerializeField] protected Transform model;

    [Space(20)]
    [Header("Load ObjectSO")]
    [SerializeField] protected HealthSO healthSO;
    [SerializeField] protected DameSO dameSO;
    [SerializeField] protected ScannerSO scannerSO;
    [SerializeField] protected SpeedSO speedSO;
    [SerializeField] protected BoxDamagedReceiverSO boxDamagedReceiverSO;


    public EnemyDamagedReceiver DameRec => this.dameRec;
    public EnemyDamagedSender DameSen => this.dameSen;
    public Transform Model => this.model;
    public HealthSO HealthSO => this.healthSO;
    public DameSO DameSO => this.dameSO;
    public ScannerSO ScannerSO => this.scannerSO;
    public SpeedSO SpeedSO => this.speedSO;
    public BoxDamagedReceiverSO BoxDamagedReceiverSO => this.boxDamagedReceiverSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamagedReceiver();
        this.LoadDamagedSender();
        this.LoadModel();
        this.LoadHealthSO();
        this.LoadDameSO();
        this.LoadScannerSO();
        this.LoadSpeedSO();
        this.LoadBoxDamagedReceiver();
    }

    protected virtual void LoadBoxDamagedReceiver()
    {
        if (this.boxDamagedReceiverSO != null) return;
        string resPath = "BoxDamagedReceiver/" + "BoxDamagedReceiver" + transform.name;
        this.boxDamagedReceiverSO = Resources.Load<BoxDamagedReceiverSO>(resPath);
        Debug.LogWarning(transform.name + ": Load BoxDamagedReceiverSO" + resPath, gameObject);
    }

    protected virtual void LoadSpeedSO()
    {
        if (this.speedSO != null) return;
        string resPath = "Speed/" + "Speed" + transform.name;
        this.speedSO = Resources.Load<SpeedSO>(resPath);
        Debug.LogWarning(transform.name + ": Load SpeedSO" + resPath, gameObject);
    }

    protected virtual void LoadDameSO()
    {
        if (this.dameSO != null) return;
        string resPath = "Dame/" + "Dame" + transform.name;
        this.dameSO = Resources.Load<DameSO>(resPath);
        Debug.LogWarning(transform.name + ": Load DameSO" + resPath, gameObject);
    }

    protected virtual void LoadScannerSO()
    {
        if (this.scannerSO != null) return;
        string resPath = "Scanner/" + "Scanner" + "Enemy";
        this.scannerSO = Resources.Load<ScannerSO>(resPath);
        Debug.LogWarning(transform.name + ": Load ScannerSO" + resPath, gameObject);
    }

    protected virtual void LoadHealthSO()
    {
        if (this.healthSO != null) return;
        string resPath = "Health/" + "Health" + transform.name;
        this.healthSO = Resources.Load<HealthSO>(resPath);
        Debug.LogWarning(transform.name + ": Load HealthSO" + resPath, gameObject);
    }

    protected virtual void LoadDamagedReceiver()
    {
        if (this.dameRec != null) return;
        Transform key = gameObject.transform.Find("DamagedReceiver");
        if (key == null) return;

        this.dameRec = key.GetComponent<EnemyDamagedReceiver>();
        Debug.Log(transform.name + ": Load DamagedReceiver", gameObject);
    }

    protected virtual void LoadDamagedSender()
    {
        if (this.dameSen != null) return;
        Transform key = gameObject.transform.Find("DamagedSender");
        if (key == null) return;

        this.dameSen = key.GetComponent<EnemyDamagedSender>();
        Debug.Log(transform.name + ": Load DamagedSender", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = gameObject.transform.Find("Model").transform;
        Debug.Log(transform.name + ": Load Model", gameObject);
    }
}
