using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownFrog : MonoBehaviour
{
    public float targetSize = 2.0f; // The target size for the x dimension
    public float duration = 0.2f;   // Duration of the resize
    public float waitTime = 0.2f;   // Time to wait before returning to the original size

    [SerializeField] private BoxCollider2D boxCollider;
    private float originalSize;
    private float originalOffsetX;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D component not found!");
            return;
        }
        originalSize = boxCollider.size.x;
        originalOffsetX = boxCollider.offset.x;
        StartCoroutine(ResizeColliderLoop());
    }

    private IEnumerator ResizeColliderLoop()
    {
        while (true)
        {
            // Smoothly increase the x size and offset
            yield return StartCoroutine(ChangeSizeAndOffset(originalSize, targetSize, originalOffsetX, originalOffsetX + (targetSize - originalSize) / 2, duration));

            // Wait for the specified time
            yield return new WaitForSeconds(waitTime);

            // Smoothly return to the original size and offset
            yield return StartCoroutine(ChangeSizeAndOffset(targetSize, originalSize, originalOffsetX + (targetSize - originalSize) / 2, originalOffsetX, duration));

            // Wait for the specified time before starting again
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator ChangeSizeAndOffset(float startSize, float endSize, float startOffset, float endOffset, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float newSize = Mathf.Lerp(startSize, endSize, elapsed / duration);
            float newOffset = Mathf.Lerp(startOffset, endOffset, elapsed / duration);
            Vector2 newColliderSize = new Vector2(newSize, boxCollider.size.y);
            Vector2 newColliderOffset = new Vector2(newOffset, boxCollider.offset.y);
            boxCollider.size = newColliderSize;
            boxCollider.offset = newColliderOffset;
            yield return null;
        }

        // Ensure the final size and offset are set
        boxCollider.size = new Vector2(endSize, boxCollider.size.y);
        boxCollider.offset = new Vector2(endOffset, boxCollider.offset.y);
    }
}
