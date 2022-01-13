﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public float minStretchToShoot;
    
    public LineRenderer[] lineRenderers;
    
    public Transform[] startBands;

    public Transform center;

    public Transform idlePosition;

    private Vector3 _currentPosition;

    private Vector3 _dir;

    [SerializeField] private float maxBandLength;

    [SerializeField] private float bottomBandLimit;

    public GameObject birdPrefab;

    // private GameObject _bird;

    private Rigidbody2D _birdRigid;
    
    private Collider2D _birdCollider;
    
    public float force;


    void CreateBird()
    {
        // _bird = Instantiate(birdPrefab);
        _birdRigid = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
        _birdCollider = _birdRigid.GetComponent<Collider2D>();
        _birdCollider.enabled = false;

        _birdRigid.isKinematic = true;
        
        GetComponent<Collider2D>().enabled = true;

        ResetBands();
    }
    
    
    public bool isMouseDown;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StateManager.Instance.gameState);
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, startBands[0].position);
        lineRenderers[1].SetPosition(0, startBands[1].position);

        CreateBird();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            _currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _dir= _currentPosition - center.position;
            
            // Debug.Log(_dir);
            

            if (Vector3.Magnitude(_dir) > maxBandLength)
            {
                
                _currentPosition = center.position + Vector3.Normalize(_dir) * maxBandLength;
                
            }
                
            _currentPosition.y = Mathf.Clamp(_currentPosition.y, bottomBandLimit, 1000);
            SetBands(_currentPosition);
            
            if (_birdCollider)
            {
                _birdCollider.enabled = true;
            }
            
        }
        else
        {
            ResetBands();
        }
        
    }
    
    
    void Shoot()
    {
        _birdRigid.isKinematic = false;
        Vector3 birdForce = (_currentPosition - center.position) * force * -1;
        _birdRigid.velocity = birdForce;


        _birdRigid = null;
        _birdCollider = null;
        GetComponent<Collider2D>().enabled = false;
        Invoke("CreateBird", 2);
    }

    private void OnMouseDown()
    {
        StateManager.Instance.gameState = GameState.Dragging;
        _birdCollider.enabled = true;
        isMouseDown = true;
    }
    
    private void OnMouseUp()
    {
        if (Vector3.Magnitude(_currentPosition-idlePosition.position) > minStretchToShoot)
        {
            StateManager.Instance.gameState = GameState.BirdFlying;
            Shoot();
        }
        else
        {
            StateManager.Instance.gameState = GameState.ReadyToLaunch;
            _birdCollider.enabled = false;
            // Destroy(_birdRigid);
            // CreateBird();
        }
        
        isMouseDown = false;
        ResetBands();
    }

    void ResetBands()
    {
        _currentPosition = idlePosition.position;
        SetBands(_currentPosition);
    }

    void SetBands(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (_birdRigid)
        {
            Vector3 dir = position - center.position;
            _birdRigid.transform.position = position + dir.normalized * -0.4f;
            _birdRigid.transform.right = -dir.normalized;
        }
    }
}
