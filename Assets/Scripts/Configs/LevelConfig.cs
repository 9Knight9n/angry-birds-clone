using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LevelConfig", menuName = "Config/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public float MapMaxX;
    public float MapMinX;
    public float MapMaxY;
    public float MapMinY;
    public int remainedPigs;

    public GameObject[] birds;
}
