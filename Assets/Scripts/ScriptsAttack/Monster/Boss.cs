using UnityEngine;

public class Boss : MonoBehaviour
{
    private int[] col = { 0, 0, -1, 1 };
    private int[] row = { -1, 1, 0, 0 };
    public float speedRush = 50f;

    public double liveBoss = 6000;
    public GameObject winGameCanvs;
    public Animator anim;

    private Vector2 target;
    private double rateTime = 5f, timeNext;
    private int count = 1, countAni = 0, countSpawn = 0;

    private double startAnima = -1;
    private bool createdBall = false, spawned = false;

    public RectTransform rectTrans;
    public BoxCollider2D boxAttack;

    public GameObject[] spawnList;
    public AnimationClip[] skillSum, skillRushAttack, skillSpawnBall;
    public GameObject Ball, attack;
    void Start()
    {
        timeNext = 5f;
        rectTrans = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time < timeNext) return;
        if (count > 4) count = 1;

        if (count == 1) skillSummon();
        if (count >= 2 && count <= 2) skillRush();
        if (count == 3) skillSummon();
        if (count == 4) skillBall();

    }
    public void skillRush()
    {
        if (startAnima == -1) startAnima = Time.time;
        
        if (Time.time - startAnima >= skillRushAttack[countAni].length) {
            if (countAni == 1 && Vector2.Distance(target, rectTrans.localPosition) != 0)
            {
                target = target = ManageTitleAttack.manaTitleAtta.findMaxPos();
                rectTrans.localPosition = Vector2.MoveTowards(rectTrans.localPosition, target, speedRush);
                return;
            }

            countAni = countAni + 1;
            if (countAni == 3) attack.SetActive(true);
            else attack.SetActive(false);
            if (countAni == 4) rectTrans.localPosition = new Vector2(750, Random.Range(-300, 300));
            if (countAni >= skillRushAttack.Length)
            {
                timeNext = Time.time + rateTime;
                anim.SetBool(skillRushAttack[countAni - 1].name, false);
                count = count + 1; countAni = 0; startAnima = -1;
                return;
            }

            startAnima = Time.time;
            if (countAni > 0) anim.SetBool(skillRushAttack[countAni - 1].name, false);
            anim.SetBool(skillRushAttack[countAni].name, true);
        }
    }
    public void skillSummon()
    {
        if (startAnima == -1) startAnima = Time.time;
        if (Time.time - startAnima >= skillSum[countAni].length)
        {
            countAni = countAni + 1;
            if (countAni == 1 && spawned == false)
            {
                var key = Instantiate(spawnList[countSpawn], GameObject.Find("Spawner").transform);
                countSpawn = countSpawn + 1;
                if (countSpawn >= spawnList.Length)
                    countSpawn = 0;
                Destroy(key, 100f);
            }
            if (countAni >= skillSum.Length)
            {
                timeNext = Time.time + rateTime;
                anim.SetBool(skillSum[countAni - 1].name, false);
                count = count + 1; countAni = 0; startAnima = -1;
                return;
            }
            startAnima = Time.time;
            if (countAni > 0) anim.SetBool(skillSum[countAni - 1].name, false);
            anim.SetBool(skillSum[countAni].name, true);
        }
    }
    public void skillBall()
    {
        if (startAnima == -1) startAnima = Time.time;
        if (Time.time - startAnima >= skillSpawnBall[countAni].length)
        {
            if (countAni == 1 && createdBall == false)
            {
                createdBall = true;
                for (int i = 0; i <= 3; i++)
                {
                    GameObject tar = ManageTitleAttack.manaTitleAtta.randTitle();
                    if (tar == null) break;
                    tar.GetComponent<ObjectCell>().haveBall = true;

                    var key = Instantiate(Ball, GameObject.Find("AttackScene").GetComponent<RectTransform>());
                    Vector2 pos = new Vector2(rectTrans.localPosition.x, rectTrans.localPosition.y);

                    key.GetComponent<RectTransform>().localPosition = pos + new Vector2(col[i] * 200, row[i] * 200);
                    key.GetComponent<ballNightmares>().target = tar;
                }
            }
            countAni = countAni + 1;
            if (countAni >= skillSpawnBall.Length)
            {
                anim.SetBool(skillSpawnBall[countAni - 1].name, false);
                count = count + 1; countAni = 0; startAnima = -1; createdBall = false;
                return;
            }
            startAnima = Time.time;
            if (countAni > 0) anim.SetBool(skillSpawnBall[countAni - 1].name, false);
            anim.SetBool(skillSpawnBall[countAni].name, true);
        }
    }
    public void attackBoss(int dame)
    {
        liveBoss = liveBoss - dame;
        if (liveBoss <= 0) destroyBoss();
    }
    public void destroyBoss()
    {
        Destroy(gameObject);
        winGameCanvs.SetActive(true);
    }
}
