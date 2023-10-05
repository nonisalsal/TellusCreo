using UnityEngine;

public class ClickObject : MonoBehaviour
{
    [Header("변경 스프라이트 오브젝트")]
    [SerializeField]
    ChangeSpriteObject cSpriteObject; // changeSpriteObject 변경 할 오브젝트
    [Header("변경 할 스프라이트")]
    [SerializeField]
    Sprite sprite;
    [Header("활성화 할 오브젝트")]
    [SerializeField]
    protected GameObject activeObject;

    virtual protected void Start()
    {
        if (activeObject != null && cSpriteObject != null)
        {
            cSpriteObject.Subscribe(() => DisableObject());
        }
    }

    void DisableObject()
    {
        if (activeObject != null)
            activeObject?.SetActive(false);
    }

    void OnMouseDown()
    {
        if (cSpriteObject == null || sprite == null)
        {
#if UNITY_EDITOR
            Debug.Log("NULL");
#endif
            return;
        }

        if (activeObject != null)
        {
            activeObject.SetActive(true);
        }

        cSpriteObject.ChangeSprite = sprite;
    }
}
