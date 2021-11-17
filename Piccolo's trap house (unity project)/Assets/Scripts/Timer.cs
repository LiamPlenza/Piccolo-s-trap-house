using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 300f;
    [SerializeField] Text countDownText;
    void Start()
    {
        currentTime = startingTime;
        countDownText.text = " 00 : 00 ";
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
            currentTime = 0;
    }
}
