using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Clicked on play");
    }
}
