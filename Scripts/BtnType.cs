using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static BtnType instance { get; private set; }

    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

    public BNTType currentType;

    public Transform buttonScale;
    Vector3 defaultScale;

    bool isSound;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BNTType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;
            case BNTType.Sound:
                if (isSound)
                    isSound = !isSound;
                break;
            case BNTType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;
            case BNTType.Quit:
                Application.Quit();
                break;
            case BNTType.Continue:
                
                break;
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        CanvasGroupOff(mainGroup);
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1.0f;
        cg.interactable = true;
        cg.blocksRaycasts= true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }



    public void OnPointerEnter(PointerEventData eventdata)
    {
        buttonScale.localScale = defaultScale * 1.2f ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;

    }
}
