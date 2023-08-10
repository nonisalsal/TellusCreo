using UnityEngine;

public class Planet : MonoBehaviour
{
    private bool _triger = false;

    private void OnMouseEnter()
    {
        if (_triger) // 인벤토리에 해당 행성이 선택된 건지
        {
            FirePlanet();
        }
    }

    void FirePlanet()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        //TODO: 발사
        this.GetComponent<SpriteRenderer>().sprite = null; 
    }
}
