using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kuca"))
        {
            Debug.Log("Kolizija");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kuca"))
        {
            Debug.Log("Kolizija");

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kuca"))
        {
            Debug.Log("Kolizija");

        }
    }
}
