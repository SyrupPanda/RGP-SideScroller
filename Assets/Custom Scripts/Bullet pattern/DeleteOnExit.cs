using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnExit : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
