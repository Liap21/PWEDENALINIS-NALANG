using UnityEngine;

public class AntiAliasing : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.material.mainTexture.filterMode = FilterMode.Trilinear;
        }
    }
}