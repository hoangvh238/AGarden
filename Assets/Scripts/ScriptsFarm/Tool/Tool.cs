using UnityEngine;
using UnityEngine.EventSystems;

public class Tool: MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject tool;
    [SerializeField] Canvas canva;
    [SerializeField] GameObject toolPresent;

    public ManagerGame manager;
    public void Start()
    {
        manager = ManagerGame.Key;
    }
    public void OnDrag(PointerEventData eventData)
    {
        toolPresent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        toolPresent = Instantiate(tool);
        toolPresent.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);

        ManagerGame.Key.DragObject = toolPresent;
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (manager.DragObject != null && manager.ContainerObject != null)
        {
            if (manager.DragObject.name == "ToolShovel(Clone)")
                manager.ContainerObject.GetComponent<Seed>().DestroySeed(0);

            if (manager.DragObject.name == "ToolCatching(Clone)")
                manager.ContainerObject.GetComponent<Bug>().destroyBug();

            if (manager.DragObject.name == "ToolWater(Clone)")
                manager.ContainerObject.GetComponent<Seed>().changeDry();
        }

        Destroy(toolPresent);
        ManagerGame.Key.DragObject = null;
    }
}


