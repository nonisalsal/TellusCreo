using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteObject : MonoBehaviour
{

    public Sprite ChangeSprite
    {
        set
        {
            _changeSpirte = value;
            ChangeObjectSprite();
        }
    }

    [SerializeField]
    private Sprite defalutSprite; // 기존 스프라이트
    protected SpriteRenderer _spriteRenderer;
    private Sprite _changeSpirte; // 변경 할 스프라이트

    private HashSet<Action> _subscribers = new HashSet<Action>(); // 옵저버 패턴

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        NotifySubscribers();
        ChangeDefaultSprite();
    }

    public void ChangeDefaultSprite()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = defalutSprite;
        }
    }

    virtual protected void ChangeObjectSprite()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        _spriteRenderer.sprite = _changeSpirte;
    }

    public void Subscribe(Action subscriber)
    {
        _subscribers.Add(subscriber);
    }

    /// <summary>
    ///   변경 된 부분이 생겼으므로 구독중인 오브젝트들에게 알리기
    /// </summary>
    private void NotifySubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber?.Invoke();
        }
    }
}
