using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockBox : MonoBehaviour
{

    public enum LockBoxType
    {
        Open,
        Lock,
        Unlock,
        Padlock
    }

    public LockBoxType LockBoxState = LockBoxType.Lock;
    public Dictionary<LockBoxType, Sprite> LockBoxBackgrounds;
    public bool IsUnlock = false;
    [SerializeField]
    private GameObject Lock;
    [SerializeField]
    private GameObject _rewardBall;
    private SpriteRenderer _spriteRenderer;
    

    public Action<LockBoxType> action;

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

        if (!IsUnlock && LockBoxBackgrounds.ContainsKey(LockBoxType.Lock))
        {
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Lock];
        }
        else if (IsUnlock && LockBoxBackgrounds.ContainsKey(LockBoxType.Unlock))
        {
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Unlock];
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        action += ChangeLockBoxSprite;
    }

    void Start()
    {
        LockBoxBackgrounds = new Dictionary<LockBoxType, Sprite>();
        LockBoxBackgrounds.Add(LockBoxType.Open, Resources.Load<Sprite>("Sprites/KJW/puzzle_Box_Open")); // 열려 있는 상태
        LockBoxBackgrounds.Add(LockBoxType.Lock, Resources.Load<Sprite>("Sprites/KJW/puzzle_Box_Lock")); // 잠겨 있는 상태
        LockBoxBackgrounds.Add(LockBoxType.Unlock, Resources.Load<Sprite>("Sprites/KJW/puzzle_Box_Unlock")); // 풀려서 닫혀 있는 상태 
        LockBoxBackgrounds.Add(LockBoxType.Padlock, Resources.Load<Sprite>("Sprites/KJW/Padlock")); // 자물쇠
#if UNITY_EDITOR
        Debug.Log(LockBoxBackgrounds.Count);
#endif
    }

    public void ChangeLockBox()
    {
        if (!IsUnlock) // 풀리지 않았다면
        {
            _spriteRenderer.sprite = LockBoxBackgrounds[LockBoxType.Padlock];
            Lock?.SetActive(true);
        }
        else
        {
            if(LockBoxState == LockBoxType.Open)
            {
                action(LockBoxType.Unlock);
                _rewardBall?.SetActive(false);
            }
            else
            {
                action(LockBoxType.Open);
                _rewardBall?.SetActive(true);
            }
        }
    }

    void ChangeLockBoxSprite(LockBoxType type) 
    {
        if(_spriteRenderer!=null)
        {
            LockBoxState = type;
            _spriteRenderer.sprite = LockBoxBackgrounds[type];
        }
    }

}
