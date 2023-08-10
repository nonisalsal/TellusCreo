using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; // Replace with appropriate namespace for your SRP
using UnityEngine.SceneManagement;

public class ChangeGraphicPipeline : MonoBehaviour
{
    public static ChangeGraphicPipeline Instance { get; private set; }

    const string targetSceneName = "Attic";
    public UniversalRenderPipelineAsset renderPipelineAsset;

    private void Awake()
    {
        // Create the singleton instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        ApplyRenderSettings(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            ApplyRenderSettings(true);
        }
        else
        {
            ApplyRenderSettings(false);
        }
    }

    private void ApplyRenderSettings(bool flag)
    {
        if (flag) // Attic이면
        {
            GraphicsSettings.renderPipelineAsset = renderPipelineAsset;
        }
        else
        {
            GraphicsSettings.renderPipelineAsset = null;
        }
    }
}
