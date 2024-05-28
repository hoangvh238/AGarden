using System;

using UnityEngine;

public class Fire : MonoBehaviour, Ball
{
    public Vector2 target;
    int doOnlyOne;
    int speed;
    public void Action()
    {
        if (true) IsNormaly();
        else IsWeakly();    
    }

    public void IsNormaly()
    {
        speed += 1 / 60 * 2;
        if (target != Vector2.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if ((Vector2)(transform.position) == (Vector2)target)
            {
                if (doOnlyOne == 0)
                {
                    Destroy(this.gameObject, 1f);
                    this.transform.GetChild(0).gameObject.SetActive(false);
                    this.transform.GetChild(1).gameObject.SetActive(true);

                    doOnlyOne = 1;
                }
            }

        }
    }

    public void IsWeakly()
    {
        //
    }

    public void OnDestroy()
    {
       //
    }

    public GameObject Spawn(GameObject gameObject)
    {
       return Instantiate(gameObject, GameObject.Find("AttackScene").transform);
    }

    // Start is called before the first frame update
    void Awake()
    {
      target = Vector2.zero;
      speed = 7;
      doOnlyOne = 0;
      BallManager.InstanceSpell.FindMaxCollect.FindPlaceDrop();
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }

}
