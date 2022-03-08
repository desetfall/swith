using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlBtnListener : MonoBehaviour
{
    private MapGenerator mapGenerator;
    private Player player;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => BtnAction());
        mapGenerator = FindObjectOfType<MapGenerator>().GetComponent<MapGenerator>(); 
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void BtnAction()
    {
        LevelData levelData = gameObject.GetComponent<LvlBtnData>().GetLevelData;
        GameObject map = mapGenerator.CreateLevel(levelData);
        gameObject.GetComponentsInParent<Image>()[3].gameObject.SetActive(false);
        player.StartGame(levelData, map);   
    }
}
