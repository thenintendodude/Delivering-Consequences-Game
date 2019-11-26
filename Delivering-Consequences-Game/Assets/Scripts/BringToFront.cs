using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour
{
    private void OnEnable()
    {
        // will make the object be the last in hierarchy, so it will be on top
        transform.SetAsLastSibling();
    }
}
