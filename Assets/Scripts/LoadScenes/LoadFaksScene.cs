using UnityEngine;

public class LoadFaksScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void LoadScene()
    {
        LevelManager.Instance.LoadScene(sceneName);
    }
}
