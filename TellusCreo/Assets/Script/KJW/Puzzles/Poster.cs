using UnityEngine;

public class Poster : MonoBehaviour
{
    LineRenderer _lr;
    int _prevIdx;
    int _curIdx;
    int _lineIdx;
    bool clearPuzzle;
    [SerializeField]
    bool correct;
    [SerializeField]
    int cnt;
    [SerializeField] Item uranus;

    void Start()
    {
        clearPuzzle = false;
        correct = true;
        _lineIdx = 0;
        _prevIdx = -1;
        _curIdx = -1;
        cnt = 0;
        _lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (clearPuzzle) return;

        if (cnt == transform.childCount && !clearPuzzle)
        {
            if (correct)
            {
#if UNITY_EDITOR
                Debug.Log("Clear");
#endif
                GameManager.Instance[(int)GameManager.Puzzle.Poster - GameManager.Instance.NUMBER_OF_PUZZLES] = true;
                clearPuzzle = true;
                if(uranus != null) 
                {
                InventoryManager.Instance.Add(uranus); // 천왕성 
                }
            }
            else
            {
                Invoke("InitPuzzle", 1f);
#if UNITY_EDITOR
                Debug.Log("Fail");
#endif
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider == null || hit.collider.gameObject.layer != 8 || hit.collider.GetComponent<PosterPoint>().isClicked)
            {
                return;
            }
            cnt++;
            _curIdx = hit.collider.transform.GetSiblingIndex();
            if (_prevIdx != -1 && _curIdx != _prevIdx + 1)
            {
                correct = false;
            }
            _prevIdx = _curIdx;
            _lr.positionCount++;
            _lr.SetPosition(_lineIdx++, hit.collider.transform.position);
            hit.collider.GetComponent<PosterPoint>().OnPointClick();
            SoundManager.Instance.Play("puzzle_poster_line");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            InitPuzzle();
        }
    }

    void InitPuzzle()
    {
        foreach (PosterPoint point in GetComponentsInChildren<PosterPoint>()) // PosterPoint 컴포넌트를 가진 자식 객체들을 반복합니다.
        {
            if (point.isClicked)
            {
                point.OnPointClick();
            }
        }
        _lr.positionCount = 0;
        _lineIdx = 0;
        _prevIdx = -1;
        _curIdx = -1;
        correct = true;
        cnt = 0;
    }
}
