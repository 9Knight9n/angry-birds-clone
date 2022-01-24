using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;

    [HideInInspector]
    public Vector3 StartingPosition;


    private float minCameraX;
    private float maxCameraX;
    private float minCameraY;
    private float maxCameraY;

    [HideInInspector]
    private GameObject _birdToFollow;
    private Rigidbody2D _birdToFollowRigid;

    // Use this for initialization
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        maxCameraX = StateManager.Instance.config.MapMaxX;
        minCameraX = StateManager.Instance.config.MapMinX;
        maxCameraY = StateManager.Instance.config.MapMaxY;
        minCameraY = StateManager.Instance.config.MapMinY;
        StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_birdToFollow != null)
        {
            // Debug.Log("inside 1");
            if (StateManager.Instance.gameState == GameState.BirdFlying) //bird will be destroyed if it goes out of the scene
            {
                // Debug.Log(BirdToFollow.position);
                SetPos();

                // Debug.Log(Vector3.Magnitude(_birdToFollowRigid.velocity));

                if (Vector3.Magnitude(_birdToFollowRigid.velocity) < 0.2 )
                {
                    // Debug.Log("ran");
                    GetNewBird();
                }
            }
        }
        else
        {
            GetNewBird(true);
        }
    }
    

    public void GetNewBird(bool noSetPos=false)
    {
        StateManager.Instance.gameState = GameState.ReadyToLaunch;
        if (StateManager.Instance.currentBird)
        {
            // Debug.Log("inside");
            _birdToFollow = StateManager.Instance.currentBird;
            _birdToFollowRigid = _birdToFollow.GetComponent<Rigidbody2D>();
            if (!noSetPos)
            {
                Invoke("SetPos", 1);
            }
            
        }
        else
        {
            _birdToFollow = null;
        }
    }

    void SetPos()
    {
        Vector3 pos = _birdToFollow.transform.position;
        float x = Mathf.Clamp(pos.x, minCameraX, maxCameraX);
        float y = Mathf.Clamp(pos.y, minCameraY, maxCameraY);
        transform.position = new Vector3(x, y, StartingPosition.z);
    }


}
