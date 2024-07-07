using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image itemImage;
    public TextMeshProUGUI itemCountText;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 originalSize;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false; // Raycast'i devre dışı bırak

        // Nesneyi geçici olarak büyüt
        rectTransform.sizeDelta = originalSize * 1.2f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position; // Nesnenin pozisyonunu sürükleme ile güncelle
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Raycast'i tekrar etkinleştir

        // Nesneyi eski boyutuna getir
        rectTransform.sizeDelta = originalSize;
    }

    public void OnDrop(PointerEventData eventData)
    {
        SlotUI draggedSlot = eventData.pointerDrag.GetComponent<SlotUI>();
        if (draggedSlot != null && draggedSlot != this)
        {
            // İki slot arasında yer değiştirme yap
            Transform draggedParent = draggedSlot.transform.parent;
            int draggedIndex = draggedSlot.transform.GetSiblingIndex();

            draggedSlot.transform.SetParent(transform.parent);
            draggedSlot.transform.SetSiblingIndex(transform.GetSiblingIndex());

            transform.SetParent(draggedParent);
            transform.SetSiblingIndex(draggedIndex);
        }
    }
}
