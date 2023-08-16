using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [SerializeField]
    private bool _canBePressed;
    [SerializeField]
    private KeyCode _keyToPress;
    [SerializeField]
    private float _effectSpawnOffset = 0f;
    [SerializeField]
    private GameObject _hitEffect;
    [SerializeField]
    private GameObject _goodHitEffect;
    [SerializeField]
    private GameObject _perfectHitEffect;
    [SerializeField]
    private GameObject _missEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_keyToPress))
        {
            if (_canBePressed)
            {
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();

                switch (Mathf.Abs(transform.position.y))
                {
                    case float value when value > 0.25f:
                        GameManager.instance.NormalHit();
                        Instantiate(_hitEffect, transform.position + new Vector3(0, 0, _effectSpawnOffset), _hitEffect.transform.rotation);
                        break;
                    case float value when value > 0.15f:
                        GameManager.instance.GoodHit();
                        Instantiate(_goodHitEffect, transform.position + new Vector3(0, 0, _effectSpawnOffset), _goodHitEffect.transform.rotation);
                        break;
                    case float value when value > 0.05f:
                        GameManager.instance.PerfectHit();
                        Instantiate(_perfectHitEffect, transform.position + new Vector3(0, 0, _effectSpawnOffset), _perfectHitEffect.transform.rotation);
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            _canBePressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            _canBePressed = false;
            GameManager.instance.MissedNote();
            Instantiate(_missEffect, transform.position + new Vector3(0,0, _effectSpawnOffset), _missEffect.transform.rotation);
        }
    }
}
