using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsQuality : MonoBehaviour
{
    public void SetQuality(int qualityIndex)
    {
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
