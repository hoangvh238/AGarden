using UnityEngine;
using UnityEngine.UI;

public class managerWeather : MonoBehaviour
{
    [SerializeField] GameObject[] weatherList;
    [SerializeField] GameObject rain;
    [SerializeField] timeGame numberTime;
    [SerializeField] Text numberDay;

    private GameObject weather, Rain;
    static public managerWeather manaWeather;
    void Start()
    {
        manaWeather = this;
        changeWeather();
    }
    public void changeWeather()
    {
        numberDay.text = "Day " + TimeController.Instance.DayPresent.ToString();
        if (TimeController.Instance.DayPresent == 1) Destroy(Rain);
        Destroy(weather);
        createWeather();
    }
    void createWeather()
    {
        weather = Instantiate(weatherList[TimeController.Instance.DayPresent - 1], new Vector2(0, 0), Quaternion.identity);
        numberTime = weather.GetComponent<timeGame>();

        if (TimeController.Instance.DayPresent == 4)
            Rain = Instantiate(rain, new Vector2(0, 0), Quaternion.identity);
    }
}
