using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    public GameObject levelManager;
    private LevelManager levelManagerScript;
    public Button goButton;
    public Button mainMenuButton;
    public Button restartButton;
    public TextMeshProUGUI levelText;
    public GameObject mainMenu;
    public GameObject menuShader;
    public GameObject lossScreen;
    public GameObject hud;
    public bool gameOver;
    
    private void Awake()
    {
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
        levelManagerScript = levelManager.GetComponent<LevelManager>();
    }
    void Start()
    {
        goButton.onClick.AddListener(StartGame);
        mainMenuButton.onClick.AddListener(MainMenu);
        restartButton.onClick.AddListener(RestartGame);
        lossScreen.SetActive(false);
        hud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        mainMenu.SetActive(false);
        menuShader.SetActive(false);
        spawnManagerScript.SpawnNewPlayerShip();
        spawnManagerScript.SpawnNewStation();
        spawnManagerScript.SpawnWinFab();
        hud.SetActive(true);
        gameOver = false;
        levelText.text = "Level " + levelManagerScript.GetLevel();
    }
    public void GameOver()
    {
        gameOver = true;
        lossScreen.SetActive(true);
        menuShader.SetActive(true);
        hud.SetActive(false);
    }

    void MainMenu()
    {
        spawnManagerScript.DeleteAllObjects();
        lossScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
    void RestartGame()
    {
        spawnManagerScript.DeleteAllObjects();
        lossScreen.SetActive(false);
        StartGame();
    }

    public void NextLevel()
    {
        levelManagerScript.UpdateLevel();
        levelText.text = "Level " + levelManagerScript.GetLevel();
        hud.SetActive(true);
        //StartGame();
    }

}
