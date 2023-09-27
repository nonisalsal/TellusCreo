using SaveIsEasy;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Save : MonoBehaviour
{

    public bool Open = true;

    //to avoid setting an empty name we use sceneFileName variable
    private string sceneFileName;
    private Scene selected;

    private void Start()
    {
        selected = SceneManager.GetSceneAt(0);
        sceneFileName = SaveIsEasyAPI.GetSceneFileNameByScene(selected);


    }

    public void save()
    {
        SaveIsEasyAPI.SaveAll(selected);
    }
    public void load()
    {

        SaveIsEasyAPI.LoadAll(selected);
    }

}
