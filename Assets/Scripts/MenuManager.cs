using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Panel;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Level()
    {
        Panel.GetComponent<Animator>().SetTrigger("Pop");
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

}
