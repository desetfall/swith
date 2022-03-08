using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    private Transform tr;
    private Vector3 targetScale, primaryScale;
    private float scaleModify = 0.7f, scaleSpeed = 0.01f;    

    void Start()
    {
        tr = transform;
        primaryScale = tr.localScale;
        targetScale = primaryScale * scaleModify;
        StartCoroutine(ScaleVectorsSwipe());
    }
    
    void Update()
    {
        tr.localScale = Vector3.Lerp(tr.localScale, targetScale, scaleSpeed);
    }

    IEnumerator ScaleVectorsSwipe()
    {
        while (true)
        {
            yield return new WaitUntil(() => tr.localScale.x <= targetScale.x + scaleSpeed);
            targetScale = primaryScale;
            yield return new WaitUntil(() => tr.localScale.x >= targetScale.x - scaleSpeed);
            targetScale = primaryScale * scaleModify;
        }
    }
}
