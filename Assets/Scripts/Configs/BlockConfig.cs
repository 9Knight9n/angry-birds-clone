using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "BlockConfig", menuName = "Config/BlockConfig")]
public class BlockConfig : ScriptableObject
{
    public float mass;
    // public Sprite sprite;
    public float scale;
    public float gravity;
    public Color color;
}
