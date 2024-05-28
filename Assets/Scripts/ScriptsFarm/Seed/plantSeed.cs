using UnityEngine;
using UnityEngine.EventSystems;

public class plantSeed : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject seed;
    [SerializeField] Canvas canva;
    [SerializeField] GameObject SeedPlant;

    int Price()
    {
        if (seed.name == "PumpkinImage") return 300;
        if (seed.name == "CauliImage") return 200;
        if (seed.name == "BellImage") return 100;
        if (seed.name == "MushroomImage") return 150;
        return 0;
    }
    public void OnDrag(PointerEventData eventData)
    {
        SeedPlant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        SeedPlant = Instantiate(seed);
        SeedPlant.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        ManagerGame.Key.DragObject = SeedPlant;

    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        ManagerGame.Key.PlaceObject(Price());
        Destroy(SeedPlant);
        ManagerGame.Key.DragObject = null;
    }
}


