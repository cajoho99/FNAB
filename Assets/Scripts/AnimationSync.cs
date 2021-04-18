using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSync : MonoBehaviour
{
    private static int frameCounter = 0;

    public void FixedUpdate()
    {
        frameCounter++;
    }

    public static int GetAnimationIndex(int ticksBetweenAnimation)
    {
        return frameCounter / ticksBetweenAnimation;
    }
}
