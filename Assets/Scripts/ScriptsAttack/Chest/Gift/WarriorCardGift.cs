
using UnityEngine;
using UnityEngine.EventSystems;

public class WarriorCardGift : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject objectDrag;
    public GameObject objectGame;
    public Canvas canvas;
    [SerializeField] private GameObject objectDragInstant;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        objectDragInstant.transform.position = mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstant = Instantiate(objectDrag);
        objectDragInstant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        objectDragInstant.GetComponent<Dragging>().giftCard = this;
        GameManager.Instance.dragObject = objectDragInstant;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isSpawn = GameManager.Instance.PlaceGameObject(0);
        if (isSpawn == true) Destroy(this.gameObject);
        GameManager.Instance.dragObject = null;
        Destroy(objectDragInstant);
    }

    public void DestroyDragInstant()
    {
        Destroy(objectDragInstant);
    }

}

