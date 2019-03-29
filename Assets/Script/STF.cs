using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class STF
{

    private static BallLauncher _ballLauncher;

    public static BallLauncher ballLauncher
    {
        get
        {
            return _ballLauncher ?? (
                _ballLauncher = GameObject.FindGameObjectWithTag("BallLauncher")
                .GetComponent<BallLauncher>());
        }
    }

}
