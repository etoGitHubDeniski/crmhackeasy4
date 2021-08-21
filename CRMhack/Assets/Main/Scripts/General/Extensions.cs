using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T GetRandomObject<T>(this T[] array)
    {
        var randomIndex = Random.Range(0, array.Length);
        return array[randomIndex];
    }
}
