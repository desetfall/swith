using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _UIConrollerPanel, _UILevelsPanel;

    private bool isLeftBtnPressed, isRightBtnPressed, isJumpBtnClicked, grounded;
    private Transform tr;
    private Rigidbody2D rb;

    private bool swiped = false;

    private PlayerAnim playerAnim;
    private PlayerSwitch playerSwitch;

    private LevelData currentLevel;
    private GameObject currentMapGO;

    private MapGenerator mpg;

    private int tempStarsCount = 0;

    private Vector3 posOutOfScreen = new Vector3(0.0f, 50.0f, 0.0f);

    public LevelData GetCurrentLevel
    {
        get => currentLevel;
    }
    
    public int TempStarsCount
    {
        get => tempStarsCount;
        set
        {
            tempStarsCount = value;
        }
    }

    public bool IsSwiped
    {
        get => swiped;
        set
        {
            swiped = value;
        }
    }

    public bool IsLeftBtnPressed
    {
        get => isLeftBtnPressed;
        set
        {
            isLeftBtnPressed = value;
        }
    }

    public bool IsRightBtnPressed
    {
        get => isRightBtnPressed;
        set
        {
            isRightBtnPressed = value;
        }
    }

    public bool IsJumpBtnCleckid
    {
        get => isJumpBtnClicked;
        set
        {
            isJumpBtnClicked = value;
        }
    }

    public bool IsGrounded
    {
        get => grounded;
    }

    private void Start()
    {
        tr = transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<PlayerAnim>();
        playerSwitch = gameObject.GetComponent<PlayerSwitch>();
        mpg = FindObjectOfType<MapGenerator>().GetComponent<MapGenerator>();
    }

    private void Update()
    {
        GroundedCheck();
    }

    private void GroundedCheck()
    {
        Vector2 pos = new Vector2(tr.position.x, tr.position.y - (swiped ? -0.58f : 0.58f));
        RaycastHit2D hit = Physics2D.Raycast(pos, (swiped ? Vector2.up : -Vector2.up), 0.05f);
        grounded = hit.collider == null ? false : true;
    }

    public void StartGame(LevelData lvlData, GameObject map)
    {
        currentLevel = lvlData;
        currentMapGO = map;
        tempStarsCount = 0;
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        tr.position = currentLevel.GetSpawnPosition();
        _UIConrollerPanel.SetActive(true);
        rb.simulated = true;
    }

    public void PlayerDead()
    {
        rb.simulated = false;
        Destroy(currentMapGO);
        currentMapGO = mpg.CreateLevel(currentLevel);
        playerAnim.PlayerDeadAnim();
        if (swiped)
        {
            playerSwitch.Switch();
        }
        tempStarsCount = 0;
        InstantiatePlayer();
    }  
    
    public void EndGame()
    {
        if (swiped)
        {
            playerSwitch.Switch();
        }
        isLeftBtnPressed = false;
        isRightBtnPressed = false;
        isJumpBtnClicked = false;
        rb.simulated = false;
        tr.position = posOutOfScreen;
        Destroy(currentMapGO);
        _UIConrollerPanel.SetActive(false);
        _UILevelsPanel.SetActive(true);
    }
}
