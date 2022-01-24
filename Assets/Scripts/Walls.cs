using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Walls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Bird.ToString()))
        {
            // Debug.Log("current"+StateManager.Instance.currentBird);
            // Debug.Log("walled"+other.gameObject);
            // if (StateManager.Instance.currentBird == other.gameObject)
            // {
            //     Debug.Log("onsode");
            //     StateManager.Instance.gameState = GameState.ReadyToLaunch;
            // }
                
            Destroy(other.gameObject);
            if (StateManager.Instance.remainingPigs > 0 && StateManager.Instance.gameState == GameState.Lose)
            {
                EventSystemCustom.current.onEndGame.Invoke("GAME OVER!");
            }
        }
    }
}
