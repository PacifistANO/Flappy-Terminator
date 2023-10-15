using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLazer : Lazer
{
    private void Update()
    {
        Move(-transform.right);
    }
}
