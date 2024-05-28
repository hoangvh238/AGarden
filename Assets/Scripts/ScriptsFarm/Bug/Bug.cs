using UnityEngine;

public class Bug : MonoBehaviour
{
    public GameObject bugSeed;
    public void destroyBug()
    {
        bugSeed.GetComponent<Seed>().haveBug = false;
        Destroy(gameObject);
    }
}
