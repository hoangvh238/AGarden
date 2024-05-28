using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorScanner : Scanner
{
    [SerializeField] protected WarriorController warriorCtrl;

    protected override void LoadComponents()
    {
        this.LoadWarriorController();
        base.LoadComponents();
        this.LoadScanner();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadScanner();
    }

    protected virtual void LoadScanner()
    {
        this.distanceScanner = this.warriorCtrl.ScannerSO.DistanceScanner;
        this.speedScanner = this.warriorCtrl.ScannerSO.SpeedScanner;
        this.rightDirection = this.warriorCtrl.ScannerSO.RightDirection;

        Vector3 positionWarrior = this.gameObject.transform.parent.position;
        float xPosition = this.distanceMap / 2 * ((this.rightDirection) ? 1 : -1);

        this.LoadXDistanceScanner(positionWarrior, xPosition);
        this.LoadYDistanceScanner();
    }

    protected virtual void LoadXDistanceScanner(Vector3 positionWarrior, float xPosition)
    {
        float distance = Mathf.Abs(xPosition - positionWarrior.x);
        this.distanceScanner = Mathf.Min(this.distanceScanner, distance);
    }

    protected virtual void LoadYDistanceScanner()
    {

    }

    protected virtual void LoadWarriorController()
    {
        if (this.warriorCtrl != null) return;
        this.warriorCtrl = transform.parent.GetComponent<WarriorController>();
        Debug.Log(transform.name + ": Load WarriorController", gameObject);
    }

    protected override void LoadBoxScanner()
    {
        base.LoadBoxScanner();
        this.boxScanner.offset = new Vector2(this.warriorCtrl.BoxDamagedReceiverSO.OffSetX, this.warriorCtrl.BoxDamagedReceiverSO.OffSetY);
        this.boxScanner.size = new Vector2(this.warriorCtrl.BoxDamagedReceiverSO.SizeX, this.warriorCtrl.BoxDamagedReceiverSO.SizeY);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.enemyFound != null) return;
        if (collision.name == "Scanner") return;

        EnemyController enemyCtrl = collision.transform.parent.GetComponent<EnemyController>();
        if (enemyCtrl == null) return;

        this.enemyFound = collision.transform.parent;
        gameObject.SetActive(false);
    }
}
