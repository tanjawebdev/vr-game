using UnityEngine;

public class cupController : MonoBehaviour
{
    [Tooltip("Drag your Canvas 'Win' GameObject here")]
    public GameObject winElement;

    void Start()
    {
        // hide the win text at the beginning
        if (winElement != null)
            winElement.SetActive(false);
    }

    // called when something enters this trigger
    private void OnTriggerEnter(Collider other)
    {
        // only react if it's the bouncy ball
        if (other.CompareTag("BouncyBall"))
        {
            if (winElement != null)
                winElement.SetActive(true);
        }
    }
}