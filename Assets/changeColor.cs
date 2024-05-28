using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeColor : MonoBehaviour
{
    float elapsedTime = 5f;
    [SerializeField] Image image;
    Color color;
    [SerializeField] GameObject obj;

    void Update()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime < 0)
        {
            //color.a -= 0.1f; // Decrease alpha value by 0.1 each time
            //image.tintColor = color;
            //
             Instantiate(obj,new Vector3(0,0,0), Quaternion.identity);
            elapsedTime = 5f; // Reset the timer
        }
    }
}
