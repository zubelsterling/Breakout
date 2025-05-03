using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayoutConfig 
{

    public static List<List<string>> getLayout(TextAsset config)
    {
        List<List<string>> result = new List<List<string>>();

        result.Add(new List<string>());

        foreach(char c in config.text)
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
