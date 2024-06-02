using UnityEngine;

public class LoadWorkScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        LevelManager.Instance.LoadScene(sceneName);
    }
}
