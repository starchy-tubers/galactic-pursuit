using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Button button;
    public Sprite mute;
    public SpriteRenderer spriteRenderer;
    public Sprite unmute;

    private void start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (PauseMenu.muted == false)
            button.image.overrideSprite = unmute;
        else
            button.image.overrideSprite = mute;
    }
}