using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CameraMove : MonoBehaviour
{
    
    private float dragSpeed = 0.02f;
    private Vector3 previousPosition = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if ( true
            // SlingShot.slingshotState == SlingshotState.Idle 
            // && GameManager.CurrentGameState == GameState.Playing
            )
        {
            // drag start
            if (Input.GetMouseButtonDown(0))
            {
                // dragSpeed = 0f;
                previousPosition = Input.mousePosition;
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
                float newX = Mathf.Clamp(transform.position.x + deltaX, 0, 11.36336f);
                float newY = Mathf.Clamp(transform.position.y + deltaY, 0, 2.715f);
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
