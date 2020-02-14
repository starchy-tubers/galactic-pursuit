using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour

{
    public Sprite healthBar3;
    public Sprite healthBar2;
    public Sprite healthBar1;
    public Sprite healthBar0;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    void Update()
    {
        int shipHealth = GameObject.Find("Ship").GetComponent<Ship>().shipHealth;
        if (shipHealth == 3)
        {
            spriteRenderer.sprite = healthBar3;
        }
        else if (shipHealth == 2)
        {
            spriteRenderer.sprite = healthBar2;
        }
        else if (shipHealth == 1)
        {
            spriteRenderer.sprite = healthBar1;
        }
        else
        {
            spriteRenderer.sprite = healthBar0;
        }
    }
}
