using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using Google.GData.Documents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimPanelNiveau : MonoBehaviour
{
    private Image img;
    void Start()
    {
        
        img = GetComponent<Image>();
        
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector2(1.5f, 1.5f), 5));
        mySequence.Join(img.DOFade(0,5));
        mySequence.Join(GetComponentInChildren<TextMeshProUGUI>().DOFade(0, 5));
    }

}
