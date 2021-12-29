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
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            SetBands(mousePosition);
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
        SetBands(idlePosition.position);
    }

    void SetBands(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);
    }
}
