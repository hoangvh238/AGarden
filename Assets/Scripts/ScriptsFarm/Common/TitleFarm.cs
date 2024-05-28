using UnityEngine;

public class TitleFarm : MonoBehaviour
{
    public bool havePond = false;
    public bool isFull = false;

    private bool pond = false;
    [SerializeField] GameObject image;

    public GameObject pondImage;
    private GameObject keyPond;
    public double timeStartPond;

    public AnimationClip animaPond;
    public ManagerGame managerGame;
    public GameObject[] imageSeeds;
    private int TypeSeed()
    {
        if (managerGame.DragObject.name == "BellImage(Clone)") return 0;
        if (managerGame.DragObject.name == "CauliImage(Clone)") return 1;
        if (managerGame.DragObject.name == "PumpkinImage(Clone)") return 2;
        if (managerGame.DragObject.name == "MushRoomImage(Clone)") return 3;
        return 0;
    }
    private void Start()
    {
        managerGame = ManagerGame.Key;
    }
    private void Update()
    {
        if (pond && Time.time - timeStartPond >= animaPond.length) isFull = true;
        if (havePond && !pond)
        {
            keyPond = Instantiate(pondImage, transform);
            pond = true; timeStartPond = Time.time;
        }
    }
    public void destroyPond()
    {
        Destroy(keyPond); havePond = pond = false;
        timeStartPond = 0; isFull = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (managerGame.DragObject != null && isFull == false)
        {
            image = Instantiate(imageSeeds[TypeSeed()], transform);
            managerGame.ContainerObject = this.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (image != null) Destroy(image);
        managerGame.ContainerObject = null;
        
    }
}
