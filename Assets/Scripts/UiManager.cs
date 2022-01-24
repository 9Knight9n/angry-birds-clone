using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UiManager : MonoBehaviour
{

    public Button nextBtn;
    public Button resetBtn;
    public Button menuBtn;
    public GameState state;
    public Text gameStateText;
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        gameStateText.gameObject.SetActive(false);
        nextBtn.gameObject.SetActive(false);
        resetBtn.gameObject.SetActive(false);
        EventSystemCustom.current.onEndGame.AddListener(UpdateText);
    }
    
    void Update()
    {
        // if (StateManager.Instance.gameState == GameState.Lose)
        // {
        //     
        // }
        
    }

    public void UpdateText(string text)
    {
        Debug.Log("Hi I am called");
        gameStateText.gameObject.SetActive(true);
        nextBtn.gameObject.SetActive(true);
        resetBtn.gameObject.SetActive(true);
        gameStateText.text = text;
        Time.timeScale = 0;
    }

    public void OnNextBtn()
    {
        Debug.Log(scene.name);
        if (scene.name == "Level3")
            OnMenuBtn();
        else
            SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void OnResetBtn()
    {
        Debug.Log("Restarted");
        
        SceneManager.LoadScene(scene.name);
    }
    public void OnMenuBtn()
    {
        Debug.Log("to menu");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    
    
}
