using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public class Block : MonoBehaviour
{

    private TextMeshPro countText;
    private SpriteRenderer spriteRenderer;

    private Color startColor;

    public int BlockHp = 3;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        countText = GetComponentInChildren<TextMeshPro>();
        UpdateText();
        startColor = Color.HSVToRGB(Random.Range(0.3f, 0.7f), Random.Range(0.3f, 0.7f), Random.Range(0.3f, 0.7f));
    }

    private void UpdateText()
    {
        countText.SetText(BlockHp.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, startColor, BlockHp / 10f);
    }

    public void SetHp(int hp)
    {
        BlockHp = hp;
        UpdateText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            BlockHp--;

            if(BlockHp > 0)
            {
                UpdateText();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }


}
