using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class FeuilleAnim : MonoBehaviour
{
    private float _randomAngle1;
    private float _randomAngle2;
    private float _randomDuration;
    private float _randomSpeed;

    private void Start()
    {
        ResetRandom();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down*Time.deltaTime*_randomSpeed;
        Destroy(gameObject,10f);

    }

    void ResetRandom()
    {
        _randomAngle1 = Random.Range(-350, 350);
        _randomAngle2=Random.Range(-350, 350);
        _randomDuration = Random.Range(1, 4);
        _randomSpeed = Random.Range(1.5f, 5);
        Anim();
    }

    void Anim()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(new Vector3(0, 0, _randomAngle1), _randomDuration));
        mySequence.Append(transform.DORotate(new Vector3(0, 0, _randomAngle2), _randomDuration).OnComplete(()=>ResetRandom()));
    }
}
