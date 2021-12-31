using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    
    public Transform[] startBands;

    public Transform center;

    public Transform idlePosition;

    private Vector3 _currentPosition;

    private Vector3 _dir;

    [SerializeField] private float maxBandLength;

    [SerializeField] private float bottomBandLimit;

    public bool isMouseDown;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, startBands[0].position);
        lineRenderers[1].SetPosition(0, startBands[1].position);
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
            
            Debug.Log(_dir);
            

            if (Vector3.Magnitude(_dir) > maxBandLength)
            {
                
                _currentPosition = center.position + Vector3.Normalize(_dir) * maxBandLength;
                
            }
                
            _currentPosition.y = Mathf.Clamp(_currentPosition.y, bottomBandLimit, 1000);
            SetBands(_currentPosition);
        }
        else
        {
            ResetBands();
        }
        
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }
    
    private void OnMouseUp()
    {
        isMouseDown = false;
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
    }
}
