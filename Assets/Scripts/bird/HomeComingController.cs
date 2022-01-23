using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class HomeComingController : BirdController
{
    private bool _activated;
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _activated = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (StateManager.Instance.gameState == GameState.BirdFlying)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!_activated)
                {
                    float vel = Vector3.Magnitude(_rigidbody2D.velocity);
                    Vector3 dir = Vector3.Normalize(transform.position-Input.mousePosition);
                    _rigidbody2D.velocity = dir * vel;
                    _activated = true;
                }
            }
        }
    }
}
