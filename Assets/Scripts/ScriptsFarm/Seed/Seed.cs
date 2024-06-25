using System.Collections;
using System.Collections.Generic;
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
    float ValuePlant(float timeToAnimation)
    {
        if (gameObject.name == "SeedBellNor(Clone)") return 200*timeToAnimation;
        if (gameObject.name == "SeedCauliNor(Clone)") return 350*timeToAnimation;
        if (gameObject.name == "SeedPumpkinNor(Clone)") return 500 * timeToAnimation;
        if (gameObject.name == "SeedMushRoomNor(Clone)") return 300*timeToAnimation;
        return 0;
    }
    private void Start()
    {
        manager = ManagerGame.Key;
        Animator animator = GetComponent<Animator>();
        timeStart = Time.time;
        timeDestroy = 400;
    }
    private void Update()
    {
        Debug.Log("Time to destroy" + this.gameObject.name + ":" + anima.length);

		if (haveDry && !appearDrog)
		{
			gameObject.GetComponent<Animator>().speed = 0;
			drogWater = Instantiate(drog, transform);
			appearDrog = true;
		}

		if (haveBug)
        {
            if (timeDestroy <= 0)
            {
				Transform parent = transform.parent;

                parent.GetComponent<TitleFarm>().ReleaseTitle();   

				var children = new List<Transform>();

				foreach (Transform child in parent)
				{
					children.Add(child);
				}

				foreach (Transform child in children)
				{
					Destroy(child.gameObject);
				}
			}

			timeDestroy = timeDestroy -1;
		}
	}
    public void ChangeDry()
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
        if (Key == 1) MoneyController.Instance.AddMoney(Mathf.FloorToInt(ValuePlant(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime)));
        Destroy(gameObject);
    }
}
