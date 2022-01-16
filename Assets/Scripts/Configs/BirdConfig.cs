using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "BirdConfig", menuName = "Config/BirdConfig")]
public class BirdConfig : ScriptableObject
{
    public float mass;
    public Sprite sprite;
    public float scale;
    public float gravity;
}
