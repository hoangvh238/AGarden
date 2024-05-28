using UnityEngine;

public class FrameRateController : AutoMonoBehaviour
{
    [SerializeField] protected int frameRate = 60;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        Application.targetFrameRate = this.frameRate;
    }
}
