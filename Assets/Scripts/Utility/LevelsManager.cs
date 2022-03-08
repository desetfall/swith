using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private LevelData[] levels;
    [SerializeField] private GameObject lvlBtnPrefab;
    private Transform contentTransform;
    private GameObject[] levelButtons;

    private void Start()
    {
        levelButtons = new GameObject[levels.Length];
        contentTransform = gameObject.GetComponentInChildren<HorizontalLayoutGroup>().gameObject.transform;
        CreateLevelsListOnUI();
    }

    private void CreateLevelsListOnUI()
    {
        if (levels.Length != 0)
        {
            for (int i = 0; i < levels.Length; i++)
            {               
                GameObject btn = Instantiate(lvlBtnPrefab);
                btn.transform.SetParent(contentTransform);
                btn.GetComponent<RectTransform>().localScale = new Vector3(1.317188f, 11.825f, 1);
                btn.GetComponent<LvlBtnData>().SetBtnInfo(levels[i]);
                levelButtons[i] = btn;
            }
        }    
    }

    private void OnEnable()
    {
        UpdateStarsOnButtons();
        UpdateInteractableStatus();
    }

    private void UpdateStarsOnButtons()
    {
        if (levelButtons != null)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].GetComponent<LvlBtnData>().SetBtnStars();
            }
        }
    }

    private void UpdateInteractableStatus()
    {
        if (levelButtons != null)
        {
            for (int i = 0; i < levels.Length - 1; i++)
            {
                if (levels[i].StarsCount != 0)
                {
                    levels[i + 1].IsLevelAvailable = true;
                }
            }
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].GetComponent<LvlBtnData>().SetBtnInteractable();
            }
        }
    }
}
