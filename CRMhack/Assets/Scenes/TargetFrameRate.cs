using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetFrameRate
{
    [RuntimeInitializeOnLoadMethod]
    public static void SetTargetFrameRate()
    {
        Application.targetFrameRate = 90;
    }
}
