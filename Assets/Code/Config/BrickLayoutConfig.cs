using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayoutConfig 
{

    public static List<List<string>> getLayout(TextAsset config)
    {
        List<List<string>> result = new List<List<string>>();

        result.Add(new List<string>());
        result[0].Add("0");

        foreach(char c in config.text)
        {
            if(c == '\n')
            {
                result.Add(new List<string>());
                result[result.Count - 1].Add("0");
            }
            else if(c == ',')
            {
                result[result.Count - 1].Add("0");
            }
            else if(c == '1')
            {
                result[result.Count - 1][result[result.Count - 1].Count - 1] = "1";
            }

        }
        return result;
    }

}
