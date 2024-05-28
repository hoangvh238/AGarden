using UnityEngine;

public class createRain : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] float Height, Width;

    [SerializeField] float timeRate, timeNext;
    [SerializeField] AudioSource rainSound, thunderSound;
    [SerializeField] GameObject thunder;

    private GameObject cam;
    private float timeThunder = 5;
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        rainSound.Play();
    }
    void Update()
    {
        createThunder();
        if (Time.time < timeNext) return;
        timeNext = Time.time + timeRate;

        float x = Random.Range(-Width, Width) + cam.transform.position.x;
        float y = Random.Range(-Height, Height);
        var Title = Instantiate(title, new Vector2(x, y), Quaternion.identity);

        float key = Random.Range(0.6f, 1);
        Title.transform.localScale = new Vector3(key, key, 1);

        Destroy(Title, 1f);
    }
    void createThunder()
    {
        if (Time.time < timeThunder) return;
        timeThunder = Time.time + Random.Range(6f, 15f);

        var Thunder = Instantiate(thunder, new Vector2(0, 0), Quaternion.identity);

        Thunder.transform.position = cam.transform.position + new Vector3(0, 0, 10);
        thunderSound.Play();
        Destroy(Thunder, 0.5f);
    }
}
