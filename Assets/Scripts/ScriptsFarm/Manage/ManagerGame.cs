using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public Text moneyTable;

    public GameObject DragObject;
    public GameObject ContainerObject;

    public static ManagerGame Key;

    public void Awake()
    {
        Key = this;
    }

    public void Update()
    {
        moneyTable.text = MoneyController.Instance.MoneyPresent.ToString();
    }

    public void PlaceObject(int price)
    {
        if (DragObject != null && ContainerObject != null && MoneyController.Instance.MoneyPresent >= price)
        {
            if (ContainerObject.layer == LayerMask.NameToLayer("Seed")) return;

            var key = Instantiate(DragObject.GetComponent<DragObject>().image, ContainerObject.transform);
            key.GetComponent<Seed>().Container = ContainerObject.GetComponent<TitleFarm>();

            manageTitleFarm.manageTiFarm.changeStatic(ContainerObject, key, true);

            ContainerObject.GetComponent<TitleFarm>().destroyPond();
            ContainerObject.GetComponent<TitleFarm>().isFull = true;
            MoneyController.Instance.DeductMoney(price);
        }
    }
}
