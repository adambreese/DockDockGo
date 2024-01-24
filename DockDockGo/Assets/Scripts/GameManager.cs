using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnManager;
    private SpawnManager spawnManagerScript;
    public Button goButton;
    public Button mainMenuButton;
    public Button restartButton;
    public GameObject mainMenu;
    public GameObject menuShader;
    public GameObject lossScreen;
    
    private void Awake()
    {
        spawnManagerScript = spawnManager.GetComponent<SpawnManager>();
    }
    void Start()
    {
        goButton.onClick.AddListener(StartGame);
        mainMenuButton.onClick.AddListener(MainMenu);
        restartButton.onClick.AddListener(RestartGame);
        lossScreen.SetActive(false);
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
    }
    
    void MainMenu()
    {
        lossScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
    void RestartGame()
    {
        lossScreen.SetActive(false);
        StartGame();
    }
    public void GameOver()
    {
        lossScreen.SetActive(true);
        menuShader.SetActive(true);
    }

}
