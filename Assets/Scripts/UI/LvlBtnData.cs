using UnityEngine;
using UnityEngine.UI;

public class LvlBtnData : MonoBehaviour
{
    [SerializeField] private Sprite[] starsSprites;
    private LevelData levelData;

    public void SetBtnInfo(LevelData lvldata)
    {
        levelData = lvldata;
        gameObject.GetComponentInChildren<Text>().text = levelData.LevelName;
        SetBtnStars();
        SetBtnInteractable();
    }

    public void SetBtnStars()
    {
        Image starsImg = gameObject.GetComponentsInChildren<Image>()[1];
        if (levelData.StarsCount == 0)
        {
            starsImg.enabled = false;
        }
        else
        {
            starsImg.enabled = true;
            starsImg.sprite = starsSprites[levelData.StarsCount - 1];
        }
    }

    public void SetBtnInteractable()
    {
        gameObject.GetComponent<Button>().interactable = levelData.IsLevelAvailable; 
    }

    public LevelData GetLevelData
    {
        get => levelData;
    }

}
