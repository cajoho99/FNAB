using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    public new string name;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int ticksBetweenAnimation;

    private int animationIndex = 0;
    private int frameCounter = 0;
    private bool animationEnabled = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animationEnabled)
        {
            if (frameCounter >= ticksBetweenAnimation)
            {
                frameCounter = 0;
                animationIndex = (animationIndex + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[animationIndex];
            }
            else
            {
                frameCounter++;
            }
        }
    }

    public void Enable()
    {
        animationEnabled = true;
        animationIndex = 0;
        frameCounter = 0;
        spriteRenderer.sprite = sprites[animationIndex];
    }

    public void Disable()
    {
        animationEnabled = false;
    }

    public void SetDefault()
    {
        spriteRenderer.sprite = sprites[0];
    }
}
