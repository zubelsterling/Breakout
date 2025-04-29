using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IConfigInterpreter
{
    string[][] getLayout();
}

public class BrickLayoutConfig: MonoBehaviour, IConfigInterpreter
{
    public TextAsset config;

    public string[][] getLayout()
    {
        string[][] result = { };
        return result;
    }

}
