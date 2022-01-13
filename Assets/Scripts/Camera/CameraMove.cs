using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CameraMove : MonoBehaviour
{
    
    private float dragSpeed = 0.02f;
    private Vector3 previousPosition = Vector3.zero;
    [SerializeField] private float maxX; // 30
    [SerializeField] private float minX; // -3
    [SerializeField] private float maxY; // 2 
    [SerializeField] private float minY; // -2.4


    private void Start()
    {
        maxX = StateManager.Instance.config.MapMaxX;
        minX = StateManager.Instance.config.MapMinX;
        maxY = StateManager.Instance.config.MapMaxY;
        minY = StateManager.Instance.config.MapMinY;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( StateManager.Instance.gameState == GameState.ReadyToLaunch || StateManager.Instance.gameState == GameState.BirdFlying)
        {
            // drag start
            if (Input.GetMouseButtonDown(0))
            {
                // dragSpeed = 0f;
                previousPosition = Input.mousePosition;
                if (StateManager.Instance.gameState == GameState.BirdFlying)
                {
                    StateManager.Instance.gameState = GameState.ReadyToLaunch;
                }
            }
            //we calculate time difference in order for the following code
            //NOT to run on single taps ;)
            else if (Input.GetMouseButton(0))
            {
                //find the delta of this point with the previous frame
                Vector3 input = Input.mousePosition;
                float deltaX = (previousPosition.x - input.x)  * dragSpeed;
                float deltaY = (previousPosition.y - input.y) * dragSpeed;
                //clamp the values so that we drag within limits
                float newX = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
                float newY = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
                //move camera
                transform.position = new Vector3(
                    newX,
                    newY,
                    transform.position.z);

                previousPosition = input;
            }
        }
    }

    

    // public SlingShot SlingShot;
}
