using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite mute;
    public Button button;
    public Sprite unmute;
    void start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (PauseMenu.muted == false)
        {
            button.image.overrideSprite = unmute;
        }
        else
        {
            button.image.overrideSprite = mute;
        }
    }
}
