using UnityEngine;
using UnityEngine.EventSystems;

public class WarriorCard : AutoMonoBehaviour , IPointerDownHandler, IPointerUpHandler 
{
    [SerializeField] protected WarriorCardController cardCtrl;
    [SerializeField] protected string nameWarrior;

    [SerializeField] protected GameObject objectDrag;

    public GameObject ObjectDrag => this.objectDrag;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardController();
        this.LoadNameWarrior();
        this.LoadDragObject();
        this.LoadCoolDownTime();
        this.SpawnCoolDownCard();
    }

    protected virtual void LoadCoolDownTime()
    {
        float time = this.cardCtrl.BuyAndSell.RateTimeBuy;
        Transform objectCD = WarriorCDSetActive.Instance.GetObjectByName(this.nameWarrior + "CD");
        objectCD.Find("SpellCoolDown").GetComponent<SpellCooldown>().ChangeCoolDownTime(time);
        Debug.Log(transform.name + ": Load CoolDownTime", gameObject);
    }

    protected virtual void LoadCardController()
    {
        if (this.cardCtrl != null) return;
        this.cardCtrl = transform.parent.GetComponent<WarriorCardController>();
        Debug.Log(transform.name + ": Load WarriorCardController", gameObject);
    }

    protected virtual string GetName(string name)
    {
        return name.Remove(name.Length - 4, 4);
    }

    protected virtual void LoadDragObject()
    {
        if (this.ObjectDrag != null) return;
        this.objectDrag = WarriorDragSetActive.Instance.GetObjectByName(this.nameWarrior + "Drag").gameObject;
        Debug.Log(transform.name + ": Load ObjectDrag", gameObject);
    }

    protected virtual void LoadNameWarrior()
    {
        this.nameWarrior = this.GetName(this.transform.parent.name);
    }
    
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!this.cardCtrl.BuyAndSell.RequestBuy(MoneyController.Instance.MoneyPresent)) return;
        this.CreateDragObject();
    }

    protected virtual void CreateDragObject()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        GameManager.Instance.dragObject = this.objectDrag;
        GameManager.Instance.nameObject = this.nameWarrior;
        WarriorDragSetActive.Instance.SetObjectActive(this.objectDrag.name, pos, rot, true);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        bool isSpawn = GameManager.Instance.PlaceGameObject(this.cardCtrl.BuyAndSell.CostBuy);
        if (isSpawn == true) this.SpawnCoolDownCard();

        GameManager.Instance.dragObject = null;
        GameManager.Instance.nameObject = null;
        WarriorDragSetActive.Instance.SetObjectActive(this.objectDrag.name, Vector3.zero, transform.rotation, false);
    }

    protected virtual void SpawnCoolDownCard()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        WarriorCDSetActive.Instance.SetObjectActive(this.nameWarrior + "CD", pos, rot, true);
    }
}
