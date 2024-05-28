using UnityEngine;
using UnityEngine.EventSystems;

public class Seed : MonoBehaviour
{
    public bool haveDry = true;
    public bool haveBug = false;

    public GameObject drog;
    public TitleFarm Container;
    public AnimationClip anima;

    public double timeStart;
    public ManagerGame manager;
    public double timeDestroy;

    private bool appearDrog = false;
    private GameObject drogWater;
    int ValuePlant()
    {
        if (gameObject.name == "SeedBellNor(Clone)") return 200;
        if (gameObject.name == "SeedCauliNor(Clone)") return 350;
        if (gameObject.name == "SeedPumpkinNor(Clone)") return 500;
        if (gameObject.name == "SeedMushRoomNor(Clone)") return 300;
        return 0;
    }
    private void Start()
    {
        manager = ManagerGame.Key;
        timeStart = Time.time;
    }
    private void Update()
    {
        if (haveDry && !appearDrog)
        {
            gameObject.GetComponent<Animator>().speed = 0;
            drogWater = Instantiate(drog, transform);
            appearDrog = true;
        }
        if (haveBug)
            timeDestroy = timeDestroy + 1;
    }
    public void changeDry()
    {
        Destroy(drogWater);
        gameObject.GetComponent<Animator>().speed = 1;
        appearDrog = haveDry = false;
    }

    public void OnMouseDown()
    {
        if (haveBug || haveDry) return;
        if (Time.time - timeStart < anima.length) return;
        DestroySeed(1);
    }
    public void DestroySeed(int Key)
    {
        Container.isFull = false;
        manageTitleFarm.manageTiFarm.changeStatic(Container.gameObject, null, false);

        manageTitleFarm.manageTiFarm.numberSeed--;
        if (Key == 1) MoneyController.Instance.AddMoney(ValuePlant());
        Destroy(gameObject);
    }
}
