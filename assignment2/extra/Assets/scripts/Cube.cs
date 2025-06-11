using UnityEngine;

public class Cube : MonoBehaviour
{
    public string colorTag; // "Red", "Blue", or "Yellow"
    private Vector3 originalPosition;
    private bool isPlaced = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void OnReleased()
    {
        if (isPlaced) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider col in colliders)
        {
            Placeholder placeholder = col.GetComponent<Placeholder>();
            if (placeholder != null)
            {
                if (placeholder.colorTag == colorTag)
                {
                    transform.position = placeholder.transform.position;
                    isPlaced = true;
                    GetComponent<Rigidbody>().isKinematic = true;
                    PuzzleManager.Instance.OnCubePlaced();
                    return;
                }
                else
                {
                    SoundManager.PlayWrongSound();
                    transform.position = originalPosition;
                    return;
                }
            }
        }

        transform.position = originalPosition;
    }

    public bool IsPlaced()
    {
        return isPlaced;
    }

    public void ResetCube()
    {
        isPlaced = false;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.position = originalPosition;
    }
}
