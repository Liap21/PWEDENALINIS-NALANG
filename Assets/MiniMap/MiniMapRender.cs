using UnityEngine;

public class AssignRenderTexture : MonoBehaviour
{
    public RenderTexture renderTexture; // Reference to your Render Texture
    public Camera miniMapCamera; // Reference to your MiniMap Camera

    void Start()
    {
        // Check if the MiniMap Camera and Render Texture are assigned
        if (miniMapCamera != null && renderTexture != null)
        {
            // Assign the Render Texture to the MiniMap Camera's target texture
            miniMapCamera.targetTexture = renderTexture;
        }
        else
        {
            Debug.LogWarning("MiniMap Camera or Render Texture is not assigned.");
        }
    }
}
