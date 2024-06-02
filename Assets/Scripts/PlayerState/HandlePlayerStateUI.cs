using UnityEngine;
using UnityEngine.UI;

public class HandlePlayerStateUI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image fullImageHealth;
    [SerializeField] ImageHandler playerStateHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.Stamina);
        playerStateHandler.UpdateHealthBar(player.Health);
        playerStateHandler.UpdateStaminaBar(player.Stamina);
        playerStateHandler.UpdateFocusBar(player.Focus);
    }
}
