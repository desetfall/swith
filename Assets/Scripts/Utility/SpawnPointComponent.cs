using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointComponent : MonoBehaviour
{
    public Vector3 GetPositionAndDestroy()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        float scaleModify = FindObjectOfType<CameraData>().GetHeightScalingModifier();
        return new Vector3(transform.position.x * scaleModify, transform.position.y * scaleModify, 0);
    }
}
