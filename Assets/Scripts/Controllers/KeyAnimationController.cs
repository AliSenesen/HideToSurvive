using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using DG.Tweening;
using UnityEngine;

public class KeyAnimationController : MonoBehaviour
{
    public Tween KeyTween;
    
    void Start()
    {
        TweenAnim();
    }

    private void TweenAnim()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveY(2.35f, 1).SetEase(Ease.Linear));
        seq.Join(transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        seq.SetLoops(-1);

        KeyTween = seq;
    }
    
    
}