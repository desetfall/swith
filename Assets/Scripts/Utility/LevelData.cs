using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private string levelName;
    [SerializeField]
    private bool levelAvailable;
    [SerializeField]
    private int starsCount;
    [SerializeField]
    private GameObject levelMap;

    public int StarsCount
    {
        get => starsCount;
        set
        {
            starsCount = value;
        }
    }

    public string LevelName
    {
        get => levelName;      
    }

    public bool IsLevelAvailable
    {
        get => levelAvailable;
        set
        {
            levelAvailable = value;
        }
    }

    public GameObject LevelMap
    {
        get => levelMap;
    }

    public Vector3 GetSpawnPosition()
    {       
        return levelMap.GetComponentInChildren<SpawnPointComponent>().GetPositionAndDestroy();
    }
}
