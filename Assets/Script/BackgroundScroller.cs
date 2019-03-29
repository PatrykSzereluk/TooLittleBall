using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public float scrollSpeed = 3f;

    private float distanceToScroolLeft;
    private Vector2 currentTextureOffset;
    private float newTextureOffsetX;

    private new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {

         currentTextureOffset = renderer.material.GetTextureOffset("_MainTex");
            
         distanceToScroolLeft = Time.deltaTime * scrollSpeed;

         newTextureOffsetX = currentTextureOffset.x + distanceToScroolLeft;

         currentTextureOffset = new Vector2(newTextureOffsetX, currentTextureOffset.y);

         renderer.material.SetTextureOffset("_MainTex", currentTextureOffset);


    }
}
