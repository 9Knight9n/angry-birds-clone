using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class LauncherController : BirdController
{
    private float _magnifier;
    private bool activated;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _magnifier = 3f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Vector3.Magnitude(_rigidbody2D.velocity) > 0.2)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!activated)
                {
                    _rigidbody2D.velocity *= _magnifier;
                    activated = true;
                }
                
            }
        }
    }
}
