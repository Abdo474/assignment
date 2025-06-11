using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject[] cubes;
    public Text successText;
    public Button restartButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        successText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void OnCubePlaced()
    {
        foreach (GameObject cube in cubes)
        {
            Cube cubeScript = cube.GetComponent<Cube>();
            if (!cubeScript.IsPlaced())
                return;
        }

        // Puzzle complete
        Debug.Log("Puzzle Completed!");
        successText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        SoundManager.PlaySuccessSound();
    }

    public void RestartPuzzle()
    {
        foreach (GameObject cube in cubes)
        {
            Cube cubeScript = cube.GetComponent<Cube>();
            cubeScript.ResetCube();
        }

        successText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }
}
