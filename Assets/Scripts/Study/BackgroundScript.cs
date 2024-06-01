using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Player player;

    void darkenBackground()
    {
        spriteRenderer.color = new Color(player.Focus / 100f, player.Focus / 100f, player.Focus / 100f);
        player.DecrementFocus(4);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("darkenBackground", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
