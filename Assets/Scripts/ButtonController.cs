using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Material unpressedMat;
    [SerializeField]
    private Material pressedMat;
    [SerializeField]
    private KeyCode buttonForPress;
    [SerializeField]
    private GameObject _objToSpawn;
    [SerializeField]
    private bool _creatorMode;

    private Transform _beatScroller;
    private List<Renderer> buttonObjects;
    // Start is called before the first frame update
    void Start()
    {
        buttonObjects = GetComponentsInChildren<Renderer>().ToList();
        _beatScroller = FindObjectOfType<BeatScroller>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonForPress))
        {
            SetMaterial(pressedMat);
            if (_creatorMode)
            {
                Instantiate(_objToSpawn, transform.position, _objToSpawn.transform.rotation, _beatScroller);
            }
        }
        if (Input.GetKeyUp(buttonForPress))
        {
            SetMaterial(unpressedMat);
        }
    }
    private void SetMaterial(Material mat)
    {
        foreach (Renderer r in buttonObjects)
        {
            r.material = mat;
        }
    }
}
