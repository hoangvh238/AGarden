using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    Light2D lightNight;
    private void Start()
    {
        lightNight = GetComponent<Light2D>();
    }
    void Update()
    { 
        if (timeGame.percentTime <= 0.25f || timeGame.percentTime >= 0.8f || TimeController.Instance.DayPresent >= 4)
            lightNight.enabled = true;
        else
            lightNight.enabled = false;
    }
}
