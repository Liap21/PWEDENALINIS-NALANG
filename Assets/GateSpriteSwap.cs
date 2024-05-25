using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpriteSwap : MonoBehaviour
{
    public List<Sprite> gateSprites;
    public SpriteRenderer gateRenderer;
    public float timeWaitForSwap = .5f;
    public Collider2D colider2d;
    public void Use()
    {
        // use coroutine like this
        StartCoroutine(SpriteSwap());
    }

    IEnumerator SpriteSwap()
    {
        foreach(Sprite sprite in gateSprites)
        {
            // change sprite
            Debug.Log("On Changed");
            gateRenderer.sprite = sprite;
            yield return new WaitForSeconds(timeWaitForSwap);
        }
        Debug.Log("On Changed done");
        colider2d.enabled = false;
        // swap done call method here.
    }
}
