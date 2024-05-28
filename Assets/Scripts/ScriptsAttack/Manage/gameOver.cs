using UnityEngine;
public class gameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject[] heartList;
    private int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (count <= 2) Destroy(heartList[count]);
        Destroy(collision.gameObject);
        count = Mathf.Min(count + 1, 3);
        if (count == 3) gameOverCanvas.SetActive(true);
    }
}
