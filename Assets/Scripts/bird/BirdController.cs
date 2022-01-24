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

        if (StateManager.Instance.gameState == GameState.Lose)
        {
            if (Vector3.Magnitude(rigid.velocity) < 0.2)
            {
                if (StateManager.Instance.remainingPigs > 0)
                {
                    Debug.Log("Game over is called");
                    EventSystemCustom.current.onEndGame.Invoke("GAME OVER!");
                }
            }
        }
        
    }
}
