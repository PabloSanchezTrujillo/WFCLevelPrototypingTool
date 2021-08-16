using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float requiredHoldTime;
    [SerializeField] private UnityEvent onLongClick;
    [SerializeField] private Image fillImage;

    private bool pointerDown;
    private float pointerDownTimer;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    // Update is called once per frame
    private void Update()
    {
        if(pointerDown) {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requiredHoldTime) {
                if(onLongClick != null) {
                    onLongClick.Invoke();
                }

                Reset();
            }

            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = 0;
    }
}