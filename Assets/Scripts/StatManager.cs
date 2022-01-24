using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    private int[] index;

    private string[] labels;
    // TextMeshProUGUI
    public TextMeshProUGUI[] ui;
    // Start is called before the first frame update
    void Start()
    {
        int birdNum = StateManager.Instance.config.birds.Length;
        index = new int[birdNum];
        labels = new string[birdNum];
        // ui = new TextMeshProUGUI[birdNum];
        labels[0] = "Normal (UnityEngine.GameObject)";
        labels[1] = "Huge (UnityEngine.GameObject)";
        labels[2] = "Launcher (UnityEngine.GameObject)";
        labels[3] = "HomeComing (UnityEngine.GameObject)";
        
        UpdateStat();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStat();
    }

    private void UpdateStat()
    {
        ResetIndex();
        GameObject[] birds = StateManager.Instance.config.birds;
        for (int i = StateManager.Instance.birdIndex; i < birds.Length; i++)
        {
            for (int g = 0; g < labels.Length; g++)
            {
                if (birds[i].ToString() == labels[g])
                {
                    index[g]++;
                }
            }
        }

        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].text = index[i].ToString();
        }
    }

    private void ResetIndex()
    {
        for (int j = 0; j < index.Length; j++)
        {
            index[j] = 0;
        }
    }
}
