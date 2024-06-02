using UnityEngine;

public class LoadHomeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        LevelManager.Instance.LoadScene(sceneName);
    }
}
