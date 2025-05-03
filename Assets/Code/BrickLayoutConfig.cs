using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayoutConfig : MonoBehaviour
{
    public TextAsset[] configFiles;
    private TextAsset currentConfig;

    private void Awake()
    {
        //subscribe to load level
    }

    public List<List<string>> getLayout(int level)
    {
        List<List<string>> result = new List<List<string>>();

        int clampedLevel = level < configFiles.Length ? level : configFiles.Length - 1;

        currentConfig = configFiles[level];// TODO clamp this value to prevent null reference

        result.Add(new List<string>());

        foreach(char c in currentConfig.text)
        {
            if(c == '\n')
            {
                result.Add(new List<string>());
            }
            if(c == ',')
            {
                //ignore commas
            }
            else
            {
                result[result.Count-1].Add(c.ToString());
            }
        }

        return result;
    }

}
