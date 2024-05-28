using UnityEngine;

public class ballNightmares : MonoBehaviour
{
    public int dame = 1000;
    public GameObject target;
    public RectTransform rectTrans;

    private double timeGo;
    // Start is called before the first frame update
    void Start()
    {
        timeGo = Time.time + 3f;
        rectTrans = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        RectTransform pos = target.GetComponent<RectTransform>();
        if (Time.time < timeGo) return;
        if (Vector2.Distance(rectTrans.localPosition, pos.localPosition) != 0)
            rectTrans.localPosition = Vector2.MoveTowards(rectTrans.localPosition, pos.localPosition, 35f);
        else
        {
            target.GetComponent<ObjectCell>().haveBall = false;
            ManageTitleAttack.manaTitleAtta.numberBall--;

            GameObject Ga = ManageTitleAttack.manaTitleAtta.findWariror(target);
            Ga.GetComponent<DameToWarrior>().ReceiveDame(dame);
            Destroy(gameObject);
        } 
    }
}
