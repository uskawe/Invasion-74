using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro; 

public class MenuButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;
    private Vector3 originalScale;

    [Header("effect cfg")]
    public float moveAmount = 20f;   
    public float scaleAmount = 1.2f; 
    public float speed = 10f;        

    private bool isHovered = false;

    void Start()
    {
        originalPosition = transform.localPosition;
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (isHovered)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition + Vector3.right * moveAmount, Time.deltaTime * speed);
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * scaleAmount, Time.deltaTime * speed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * speed);
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * speed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}
