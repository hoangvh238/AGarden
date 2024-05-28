using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : AutoMonoBehaviour
{
    [SerializeField] protected WarriorDamagedReceiver dameRec;
    [SerializeField] protected WarriorDamagedSender dameSen;
    [SerializeField] protected AttackPlacedRegion placedRegion;
    [SerializeField] protected Scanner scanner;
    [SerializeField] protected Transform model;

    [Space(20)]
    [Header("Load ObjectSO")]
    [SerializeField] protected HealthSO healthSO;
    [SerializeField] protected DameSO dameSO;
    [SerializeField] protected ScannerSO scannerSO;
    [SerializeField] protected BoxDamagedReceiverSO boxDamagedReceiverSO;

    public Scanner Scanner => this.scanner;
    public WarriorDamagedReceiver DameRec => this.dameRec;
    public WarriorDamagedSender DameSen => this.dameSen;
    public Transform Model => this.model;
    public AttackPlacedRegion PlacedRegion => this.placedRegion;
    public HealthSO HealthSO => this.healthSO;
    public DameSO DameSO => this.dameSO;
    public ScannerSO ScannerSO => this.scannerSO;
    public BoxDamagedReceiverSO BoxDamagedReceiverSO => this.boxDamagedReceiverSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScanner();
        this.LoadDamagedReceiver();
        this.LoadDamagedSender();
        this.LoadPlacedRegion();
        this.LoadModel();
        this.LoadHealthSO();
        this.LoadDameSO();
        this.LoadScannerSO();
        this.LoadBoxDamagedReceiver();
    }

    protected virtual void LoadBoxDamagedReceiver()
    {
        if (this.boxDamagedReceiverSO != null) return;
        string resPath = "BoxDamagedReceiver/" + "BoxDamagedReceiver" + transform.name;
        this.boxDamagedReceiverSO = Resources.Load<BoxDamagedReceiverSO>(resPath);
        Debug.LogWarning(transform.name + ": Load BoxDamagedReceiverSO" + resPath, gameObject);
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
        string resPath = "Scanner/" + "Scanner" + transform.name;
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

    protected virtual void LoadPlacedRegion()
    {
        if (this.placedRegion != null) return;
        this.placedRegion = transform.Find("PlacedRegion").GetComponent<AttackPlacedRegion>();
        Debug.Log(transform.name + ": Load PlacedRegion", gameObject);
    }

    protected virtual void LoadScanner()
    {
        if (this.scanner != null) return;
        var obj = gameObject.transform.Find("Scanner");
        if (obj == null) return;

        this.scanner = obj.GetComponent<Scanner>();
        Debug.Log(transform.name + ": Load Scanner", gameObject);
    }

    protected virtual void LoadDamagedReceiver()
    {
        if (this.dameRec != null) return;
        var obj = gameObject.transform.Find("DamagedReceiver");
        if (obj == null) return;

        this.dameRec = obj.GetComponent<WarriorDamagedReceiver>();
        Debug.Log(transform.name + ": Load DamagedReceiver", gameObject);
    }

    protected virtual void LoadDamagedSender()
    {
        if (this.dameSen != null) return;
        var obj = gameObject.transform.Find("DamagedSender");
        if (obj == null) return;

        this.dameSen = obj.GetComponent<WarriorDamagedSender>();
        Debug.Log(transform.name + ": Load DamagedSender", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = gameObject.transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }
}
