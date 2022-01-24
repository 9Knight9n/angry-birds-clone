using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public BirdConfig config;

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        // GetComponent<SpriteRenderer>().sprite = config.sprite;
        GetComponent<Rigidbody2D>().mass = config.mass;
        GetComponent<Transform>().localScale = new Vector3(config.scale, config.scale, config.scale);
        GetComponent<Rigidbody2D>().gravityScale = config.gravity;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (StateManager.Instance.gameState == GameState.BirdFlying)
        {
            transform.right = GetComponent<Rigidbody2D>().velocity.normalized;
        }

        
        if (Vector3.Magnitude(rigid.velocity) < 0.2)
        {
            
            // Debug.Log(("inside if speed : "));
            // if (StateManager.Instance.birdIndex == StateManager.Instance.config.birds.Length)
            // {
            //     StateManager.Instance.gameState = GameState.Lose;
            // }
            if (StateManager.Instance.lastBird)
            {
                if (StateManager.Instance.remainingPigs > 0)
                {
                    // Debug.Log(("Speeeeeeed before game over : " + rigid.velocity));
                    EventSystemCustom.current.onEndGame.Invoke("GAME OVER!");
                }
            }

        }
        
    }
}
