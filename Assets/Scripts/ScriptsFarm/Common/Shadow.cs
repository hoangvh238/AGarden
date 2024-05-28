using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    SpriteRenderer opacity;
    [SerializeField] float Key;
    private void Start()
    {
        opacity = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Key = 0;
        if (timeGame.percentTime >= (float)1 / 10 || timeGame.percentTime >= (float)8 / 10)
        {
             Key = timeGame.percentTime * 255;
        }

        if (timeGame.percentTime > 0.5f) Key = 0.5f * 255 - Mathf.Abs(timeGame.percentTime - 0.5f) * 255;
        opacity.color = new Color32(101, 83, 83, (byte) Key);
    }
}
