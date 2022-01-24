using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{

    private float _minFallDamage;
    
    public PigConfig config;

    private float _health;
    [SerializeField]
    private GameObject _pigExplosionAnimPrefab;

    public Texture2D destroyTexture;
    // Start is called before the first frame update
    void Start()
    {
        _minFallDamage = 4;
        _health = config.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log(other.relativeVelocity.magnitude);
        
        if(other.relativeVelocity.magnitude > _minFallDamage){ //remove this 
 
            _health -= other.relativeVelocity.magnitude ; //line 1
 
        }  //remove this

        // Debug.Log("health:"+_health);
        
        if ( _health < 0 ){
 
            Die();
            
        }
        // Debug.Log(other.gameObject);
        // Vector3 otherVel = other.gameObject.GetComponent<Rigidbody2D>().velocity;
        // Debug.Log(otherVel);
        // Vector3 pigVel = GetComponent<Rigidbody2D>().velocity;
        // Debug.Log(pigVel);
        // Debug.Log(Vector3.Magnitude(pigVel-otherVel));
        // if (Vector3.Magnitude(pigVel-otherVel) > 2)
        //     Die();
    }


    private void Die()
    {
        FindObjectOfType<AudioManager>().Play("PigDeathSound");
        Instantiate(_pigExplosionAnimPrefab, transform.position, Quaternion.identity);
        StateManager.Instance.remainingPigs--;
        if (StateManager.Instance.remainingPigs == 0)
        {
            EventSystemCustom.current.onEndGame.Invoke("YOU WIN");
        }
        Destroy(this.gameObject);
    }
}
