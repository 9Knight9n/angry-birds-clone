using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public BirdConfig config;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = config.sprite;
        GetComponent<Rigidbody2D>().mass = config.mass;
        GetComponent<Transform>().localScale = new Vector3(config.scale, config.scale, config.scale);
        GetComponent<Rigidbody2D>().gravityScale = config.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
