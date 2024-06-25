using UnityEngine;

public class Bug : MonoBehaviour
{
    public GameObject bugSeed;
    public void DestroyBug()
    {
        bugSeed.GetComponent<Seed>().haveBug = false;
        Destroy(gameObject);
    }
}
