using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
// para obtener los valores del slider

public class MusicCtrl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Text valueText;
    public void OnSliderChanged(float value)
    {
        audioMixer.SetFloat("Volume", value - 80);
        valueText.text = value.ToString();
    }
}
