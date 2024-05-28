using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPar : MonoBehaviour
{
    [System.Obsolete]
    public void SetEffect (Color color)
    {
        this.GetComponent<ParticleSystem>().startColor = color;
    }
}
