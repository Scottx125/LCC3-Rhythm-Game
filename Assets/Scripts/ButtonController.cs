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

    private List<Renderer> buttonObjects;
    // Start is called before the first frame update
    void Start()
    {
        buttonObjects = GetComponentsInChildren<Renderer>().ToList();
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonForPress))
        {
            SetMaterial(pressedMat);
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
