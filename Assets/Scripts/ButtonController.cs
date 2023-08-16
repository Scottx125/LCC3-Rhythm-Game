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
    [SerializeField]
    private float _startOffset;

    private GameObject _beatScroller;
    private List<Renderer> buttonObjects;
    private bool _firstPress;
    // Start is called before the first frame update
    void Start()
    {
        buttonObjects = GetComponentsInChildren<Renderer>().ToList();
        _beatScroller = FindObjectOfType<BeatScroller>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonForPress))
        {
            SetMaterial(pressedMat);
            if (_creatorMode)
            {
                Instantiate(_objToSpawn, transform.position, _objToSpawn.transform.rotation, _beatScroller.transform);
                if (!_firstPress)
                {
                    _startOffset = Mathf.Abs(_beatScroller.transform.position.y); 
                    _firstPress = true;
                }
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
