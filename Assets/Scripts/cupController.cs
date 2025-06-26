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
        Debug.Log("This script is on: " + gameObject.name);

        Debug.Log("TEST");
        Debug.Log(other.tag);
        Debug.Log($"Collision with: {other.gameObject.name} (tag: {other.tag})");
        Debug.Log(other.transform.root);

        // only react if it's the bouncy ball
        if (other.CompareTag("Ball"))
        {
            Debug.Log("test ball");
            Debug.Log(winElement);
            if (winElement != null)
                winElement.SetActive(true);
        }
    }
}