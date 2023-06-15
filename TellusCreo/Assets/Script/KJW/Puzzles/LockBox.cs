using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockBox : MonoBehaviour
{

    enum LockBoxType
    {
        Open,
        Close,
        Unlock,
        Padlock
    }

    public bool IsUnlock = false;
    [SerializeField]
    private GameObject Lock;
    [SerializeField]
    private Dictionary<LockBoxType, Sprite> LockBoxBackgrounds;
    [SerializeField]
    private GameObject _rewardBall;
    private SpriteRenderer _spriteRenderer;

    public Action action;


    void OnMouseDown()
    {
        ChangeLockBox();
    }
    private void OnEnable()
    {
        if (_spriteRenderer == null|| LockBoxBackgrounds ==null)
        {
            return;
        }

        if (Lock != null && Lock.activeSelf) // null이 아니고 켜져있었다면 끄기
        {
            Lock.SetActive(false);
        }

        if (!IsUnlock && LockBoxBackgrounds.ContainsKey(LockBoxType.Close))
        {
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Close];
        }
        else if (IsUnlock && LockBoxBackgrounds.ContainsKey(LockBoxType.Unlock))
        {
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Unlock];
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        LockBoxBackgrounds = new Dictionary<LockBoxType, Sprite>();
        LockBoxBackgrounds.Add(LockBoxType.Open, Resources.Load<Sprite>("Sprites/KJW/puzzle_Box_Open"));
        LockBoxBackgrounds.Add(LockBoxType.Close, Resources.Load<Sprite>("Sprites/KJW/puzzle_Box_Lock"));
        LockBoxBackgrounds.Add(LockBoxType.Unlock, Resources.Load<Sprite>("Sprites/KJW/puzzle_Box_Unlock"));
        LockBoxBackgrounds.Add(LockBoxType.Padlock, Resources.Load<Sprite>("Sprites/KJW/Padlock"));
#if UNITY_EDITOR
        Debug.Log(LockBoxBackgrounds.Count);
#endif
    }

    public void ChangeLockBox()
    {
        if (!IsUnlock)
        {
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Padlock];
            Lock?.SetActive(true);
        }
        else
        {
            _rewardBall?.SetActive(true);
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Open];
        }
    }


}
