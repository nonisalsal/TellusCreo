using UnityEngine;

public class Planet : MonoBehaviour
{
    bool _triger = false;
    private void OnEnable()
    {
        if (_triger) return;
        if (GameManager.Instance != null)
        {
            _triger = true;
            GameManager.Instance.SetPlanet++;
            if (GameManager.Instance?.SetPlanet == 3)
            {
                GameManager.Instance[(int)GameManager.Puzzle.Star - GameManager.Instance.NUMBER_OF_PUZZLES] = true;
            }
        }
    }
}
