using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyObjectMovement : MonoBehaviour
{
    [SerializeField] private float radius, moveSpeed;
    [SerializeField] private bool isX, isY, flipX, flipY;
    private Transform tr;
    private float rightTargetPos, leftTargetPos, upTargetPos, downTargetPos;
    private float leftRightSpeed, upDownSpeed;
    private const float ZERO_SPEED = 0.0f;

    private void Start()
    {
        tr = transform;
        ChangeValuesBasedOnScaleOffset();       
        CalculateSpeed();
        CalculateTargetPositions();
        if (isX)
            StartCoroutine(LeftRightSpeedSwipe());
        if (isY)
            StartCoroutine(UpDownSpeedSwipe());
    }

    private void ChangeValuesBasedOnScaleOffset()
    {
        float scaleModifier = FindObjectOfType<CameraData>().GetComponent<CameraData>().GetHeightScalingModifier();
        radius *= scaleModifier;
        moveSpeed *= scaleModifier;
    }

    private void CalculateSpeed()
    {
        leftRightSpeed = isX ? flipX ? -moveSpeed : moveSpeed : ZERO_SPEED;
        upDownSpeed = isY ? flipY ? -moveSpeed : moveSpeed : ZERO_SPEED;
    }

    private void CalculateTargetPositions()
    {
        Vector3 startPos = tr.position;
        if (isX)
        {
            rightTargetPos = startPos.x + radius;
            leftTargetPos = startPos.x - radius;
        }
        if (isY)
        {
            upTargetPos = startPos.y + radius;
            downTargetPos = startPos.y - radius;
        }
    }

    private void Update()
    {
        Vector3 currentPos = tr.position;
        tr.position = new Vector3(currentPos.x + leftRightSpeed * Time.deltaTime, currentPos.y + upDownSpeed * Time.deltaTime, currentPos.z);
    }

    private IEnumerator LeftRightSpeedSwipe()
    {
        while (true)
        {
            yield return new WaitUntil(() => tr.position.x >= rightTargetPos || tr.position.x <= leftTargetPos);
            leftRightSpeed = -leftRightSpeed;
            yield return new WaitUntil(() => tr.position.x <= rightTargetPos || tr.position.x >= leftTargetPos);
        }
    }

    private IEnumerator UpDownSpeedSwipe()
    {
        while (true)
        {
            yield return new WaitUntil(() => tr.position.y >= upTargetPos || tr.position.y <= downTargetPos);
            upDownSpeed = -upDownSpeed;
            yield return new WaitUntil(() => tr.position.y <= upTargetPos || tr.position.y >= downTargetPos);  
        }
    }
}
