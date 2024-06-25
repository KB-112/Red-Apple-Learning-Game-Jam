
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    public Sprite unselectedSprite;
    public Sprite selectedSprite;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = selectedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = unselectedSprite;
    }
}
