using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// seems the immediate problem is that the script is not
/// converting to binary at all.
/// 
/// also the binary rebuilding part is just string concatenating a 2 for every 1.
/// </summary>
public class CodeQuestion : MonoBehaviour
{
    //script is intended to do 3 things,
    // -convert int to binary
    // -reverse binary
    // -binary to int
    public static int FormatNumber(int number)
    {
        var binaryRep = string.Empty;
        var result = 0;

        while (number > 0)
        {
            binaryRep = (number % 2) + binaryRep;
            number = number / 2;
        }


        int len = binaryRep.Length;

        for (int i = 0; i < len; i++)
        {
            if (binaryRep[i] == '1')
                result += (int)Math.Pow(2, i);
        }
        return result;
    }

    //alternative solution using Convert.ToString
    public static int FormatNumberAlternate(int number)
    {
        var binaryRep = string.Empty;
        int result = 0;

        binaryRep = Convert.ToString(number, 2);

        int len = binaryRep.Length;

        for (int i = 0; i < len; i++)
        {
            if (binaryRep[i] == '1')
                result += (int)Math.Pow(2, i);
        }
        return result;
    }

}
