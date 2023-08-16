using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField]
    private float _lifetime = 1f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, _lifetime);
    }
}
