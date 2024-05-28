using UnityEngine;

public class RandNumber : AutoMonoBehaviour
{
    [Header("Number Random")]
    [SerializeField] protected int numberStart = 1;
    [SerializeField] protected int numberEnd = 1;

    public virtual int CreateNumber(int key, float rate)
    {
        if (rate > (float)1 / 3) this.numberEnd = 2;
        if (rate > (float)2 / 3) this.numberEnd = 3;

        return Mathf.Min(key, Random.Range(this.numberStart, this.numberEnd + 1));
    }
}
