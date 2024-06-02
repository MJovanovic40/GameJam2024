using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private LoadWorkScene loadWorkScene;
    [SerializeField] private LoadHomeScene loadHomeScene;
    [SerializeField] private LoadFaksScene loadFaksScene;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Work"))
        {
            loadWorkScene.LoadScene();
        }

        if (collision.gameObject.CompareTag("Kuca"))
        {
            loadHomeScene.LoadScene();
        }

        if (collision.gameObject.CompareTag("Faks"))
        {
            Debug.Log(loadFaksScene);
            loadFaksScene.LoadScene();
        }
    }
}
