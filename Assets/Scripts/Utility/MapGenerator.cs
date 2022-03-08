using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private CameraData camData;

    public GameObject CreateLevel(LevelData lvldata)
    {
        GameObject map = Instantiate(lvldata.LevelMap);
        float modify = camData.GetHeightScalingModifier();
        map.transform.localScale = new Vector3(map.transform.localScale.x * modify, map.transform.localScale.y * modify, map.transform.localScale.z * modify);
        return map;
    }
}
