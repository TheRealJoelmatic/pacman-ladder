using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnColition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("b");
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Debug.Log("s");
            Destroy(this);
        }
    }
}
