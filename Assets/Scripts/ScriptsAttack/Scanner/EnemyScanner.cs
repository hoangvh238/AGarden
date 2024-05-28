using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : Scanner
{
    [SerializeField] protected EnemyController enemyCtrl;

    protected override void LoadComponents()
    {
        this.LoadEnemyController();
        base.LoadComponents();
        this.LoadScanner();
        this.LoadBoxScanner();
    }

    protected override void LoadBoxScanner()
    {
        base.LoadBoxScanner();
        this.boxScanner.offset = new Vector2(this.enemyCtrl.BoxDamagedReceiverSO.OffSetX, this.enemyCtrl.BoxDamagedReceiverSO.OffSetY);
        this.boxScanner.size = new Vector2(this.enemyCtrl.BoxDamagedReceiverSO.SizeX, this.enemyCtrl.BoxDamagedReceiverSO.SizeY);
    }

    protected virtual void LoadScanner()
    {
        this.distanceScanner = this.enemyCtrl.ScannerSO.DistanceScanner;
        this.speedScanner = this.enemyCtrl.ScannerSO.SpeedScanner;
        this.rightDirection = this.enemyCtrl.ScannerSO.RightDirection;

        Vector3 positionEnemy = this.gameObject.transform.parent.position;
        float xPosition = this.distanceMap / 2 * ((this.rightDirection) ? 1 : -1);

        this.LoadXDistanceScanner(positionEnemy, xPosition);
        this.LoadYDistanceScanner();
    }

    protected virtual void LoadXDistanceScanner(Vector3 positionEnemy, float xPosition)
    {
        float distance = Mathf.Abs(xPosition - positionEnemy.x);
        this.distanceScanner = Mathf.Min(this.distanceScanner, distance);
    }

    protected virtual void LoadYDistanceScanner()
    {

    }

    protected virtual void LoadEnemyController()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyController>();
        Debug.Log(transform.name + ": Load EnemyController", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.enemyFound != null) return;
        if (collision.name == "Scanner") return;

        WarriorController warriorCtrl = collision.transform.parent.GetComponent<WarriorController>();
        if (warriorCtrl == null) return;

        this.enemyFound = collision.transform.parent;
        gameObject.SetActive(false);
    }
}
