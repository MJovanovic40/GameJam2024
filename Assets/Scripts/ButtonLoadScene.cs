using UnityEngine;
using UnityEngine.UI;


public class ButtonLoadScene : MonoBehaviour
{
    // Reference to the Button component on this GameObject
    private Button button;

    // The name of the scene to load
    public string sceneName;

    private void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener to the Button's onClick event
        button.onClick.AddListener(ChangeScene);
    }
    public void ChangeScene()
    {
        Debug.Log(sceneName);
        LevelManager.Instance.LoadScene(sceneName);
    }
}
