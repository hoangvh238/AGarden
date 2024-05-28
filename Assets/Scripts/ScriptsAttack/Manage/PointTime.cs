using UnityEngine;
public class PointTime : MonoBehaviour
{
    public RectTransform pointFirst;
    public RectTransform pointSecond;

    private RectTransform rect;
    public float distance;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = pointFirst.localPosition;
        distance = Vector2.Distance(pointFirst.localPosition, pointSecond.localPosition);
    }
    void Update()
    {
        float x = (float) TimeController.Instance.DaySec / 180;
        float key = x * distance;
        rect.localPosition = pointFirst.localPosition + new Vector3(key, 0, 0);
    }
}
