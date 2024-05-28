using UnityEngine;
using UnityEngine.Rendering.Universal;

public class timeGame : MonoBehaviour
{
    public float timePresent;
    public float timeLimit = 180;
    static public float percentTime;

    [SerializeField] protected Gradient gradient;
    [SerializeField] protected Light2D light2D;

    void Update()
    {
        this.timePresent = TimeController.Instance.DaySec;
        light2D = GameObject.Find("LightMap").GetComponent<Light2D>();
        SetGradient();
    }
    void SetGradient()
    {
        percentTime = (this.timePresent * 60 + TimeController.Instance.DaySec) / (this.timeLimit * 60) ;
        this.light2D.color = this.gradient.Evaluate(percentTime);
    }
}
