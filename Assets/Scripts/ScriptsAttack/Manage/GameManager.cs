using System;
using UnityEngine;

public class GameManager : AutoMonoBehaviour
{
    public string nameObject;
    public GameObject dragObject;
    public GameObject currentCell;

    [SerializeField] protected static GameManager instance;
    public static GameManager Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GameManager.instance = this;
    }

    public virtual bool PlaceGameObject(int cost)
    {
        if (this.dragObject != null && this.currentCell != null)
        {
            this.BuyObject(cost);
            return true;
        }
        return false;
    }

    protected virtual void BuyObject(int cost)
    {
        Vector3 pos = this.currentCell.transform.position;
        Quaternion rot = this.currentCell.transform.rotation;

        Transform key = WarriorSpawner.Instance.Spawn(this.nameObject, pos, rot);
        key.GetComponent<WarriorController>().PlacedRegion.ChangeRegion(this.currentCell.transform);
        key.gameObject.SetActive(true);

        MoneyController.Instance.DeductMoney(cost);

        this.currentCell.GetComponent<ObjectCell>().ChangeStatus(true);
        ManageTitleAttack.manaTitleAtta.changeStatic(this.currentCell, key.gameObject, true);
    }
}