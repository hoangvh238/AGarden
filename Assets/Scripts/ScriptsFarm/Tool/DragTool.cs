using UnityEngine;

public class DragTool : MonoBehaviour
{
    public ManagerGame managerGame;
    public void Start()
    {
        managerGame = ManagerGame.Key;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (managerGame.DragObject != null)
        {
            managerGame.ContainerObject = this.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        managerGame.ContainerObject = null;
    }
}
