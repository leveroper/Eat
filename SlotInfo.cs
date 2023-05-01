using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotInfo : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    public Image SlotImage => image;
    [SerializeField] private int slotIndex;
    [SerializeField] private Animator animator;
    private bool full;
    private string hoverAnimation = "SlotHover";
    private string unhoverAnimation = "SlotHoverBack";
    private string clickAnimation = "clickSlot";
    private string addSlotAnimation = "AddSlot";

    void Start()
    {
        gameObject.GetComponent<Animator>();
    }
    public bool CheckIsFull()
    {
        return full;
    }
    public void SetFull(bool state)
    {
        full = state;
    }
    public void SetIndex(int index)
    {
        slotIndex = index;
    }

    public int GetIndex()
    {
        return slotIndex;
    }
    public void ClearSlot()
    {
        image.sprite = null;
        full = false;
    }
    public void SpawnItem()
    {
        animator.Play(addSlotAnimation);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.Play(clickAnimation);
    }
    public void UseSlot()
    {
        Inventory.instance.UseItem(slotIndex);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.Play(hoverAnimation);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.Play(unhoverAnimation);
    }
}
