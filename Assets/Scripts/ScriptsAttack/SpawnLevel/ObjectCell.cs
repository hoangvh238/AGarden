using UnityEngine;

public class ObjectCell : MonoBehaviour
{
    public bool haveBall;
    [SerializeField] protected bool isFull;
    [SerializeField] protected string ObjectShadow;

    public virtual void ChangeStatus(bool status)
    {
        this.isFull = status;
    }

    protected virtual void CreateShadow()
    {
        this.ObjectShadow = this.GetShadowByName(GameManager.Instance.dragObject.name);
        if (this.ObjectShadow == null) return;

        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        WarriorShadowSetActive.Instance.SetObjectActive(this.ObjectShadow, pos, rot, true);
    }
    
    protected virtual string GetName(string nameObject)
    {
        return nameObject.Remove(nameObject.Length - 4, 4);
    }

    protected virtual string GetShadowByName(string nameObject)
    {
        return GetName(nameObject) + "Shadow";
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.dragObject == null || this.isFull) return;
        ObjectDragController dragCtrll = collision.transform.parent.GetComponent<ObjectDragController>();
        if (dragCtrll == null) return;

        this.CreateShadow();
        GameManager.Instance.currentCell = this.gameObject;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        ObjectDragController dragCtrll = collision.transform.parent.GetComponent<ObjectDragController>();
        if (dragCtrll == null) return;
        WarriorShadowSetActive.Instance.SetObjectActive(this.ObjectShadow, Vector3.zero, transform.rotation, false);
        GameManager.Instance.currentCell = null;
    }
}
