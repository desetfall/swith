using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    private const float STANDART_LEVEL_HEIGHT = 2160.0f, PIXELS_PER_UNIT = 100.0f;
    private Camera cam;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();         
    }

    public float GetHeightScalingModifier()
    {
        return cam.orthographicSize * 2.0f / STANDART_LEVEL_HEIGHT * PIXELS_PER_UNIT;
    }

}
