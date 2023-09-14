using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzle : MonoBehaviour
{
    bool isClear;
    
    public bool WireClear { get { return isClear; } }
    public int cnt;
    public GameObject[] objs;
    void Start()
    {
        isClear = false;
        cnt = 0;
    }
    [SerializeField] private List<Item> wires = new List<Item>();
    void Update()
    {
        if (cnt == objs.Length)
        {
            if (objs != null)
            {
                foreach (var obj in objs)
                {
                    string objNumber = obj.name.Substring(obj.name.Length - 1);
                    string childNumber = obj.transform.GetChild(0).name.Substring(obj.transform.GetChild(0).name.Length - 1);

                    if (objNumber != childNumber)
                    {
                        ReturnWiresToInventory();
                        break;
                    }
                    isClear = true;
                }

                if (isClear)
                {
                    GameManager.Instance[(int)GameManager.Puzzle.LightSwitch-GameManager.Instance.NUMBER_OF_PUZZLES] = true;
                    GameManager.Instance[(int)GameManager.Puzzle.Wire-GameManager.Instance.NUMBER_OF_PUZZLES] = true;
                    cnt = 0;
                }
            }
        }
    }

    void ReturnWiresToInventory()
    {
        foreach (var obj in objs)
        {
            var child = obj.transform.GetChild(0);
            Destroy(child.gameObject);
        }
        cnt = 0;
        isClear = false;

        foreach(Item wire in wires)
        {
            InventoryManager.Instance.Add(wire);
        }
    }
}
