using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotsItem : MonoBehaviour, IClickable
{
    [SerializeField] ItemType _itemType = ItemType.All;
    private bool _isTaken;
    private SlotsState _state;
    private WaitForSeconds _delay;
    private GraphicRaycaster _caster;
    private PointerEventData _pointerEvent;
    private List<RaycastResult> _hitsTargets;
    private Vector3 _offset = Vector3.zero;
    public bool IsTaken { get => _isTaken; set => _isTaken = value; }

    public void Move()
    {
        transform.position = Input.mousePosition - _offset;
    }

    public void Put()
    {
        _pointerEvent.position = Input.mousePosition;
        _caster.Raycast(_pointerEvent, _hitsTargets);
        bool success = false;
        foreach (var item in _hitsTargets)
        {
            var temp = item.gameObject.GetComponent<Slot>();
            if (temp != null)
            {
                if (!temp.IsFilled && temp.CheckForAccordance(_itemType))
                {
                    transform.parent.GetComponent<Slot>().Clear();
                    transform.SetParent(item.gameObject.transform, false);
                    transform.localPosition = -_offset;
                    temp.Fill();
                    success = true;
                    break;
                }
            }
        }

        if (!success)
        {
            transform.position = transform.parent.position;
            transform.localPosition = -_offset;
        }
        Invoke(nameof(ChangeTake), 0.15f);
        _state = SlotsState.Chill;

        _hitsTargets.Clear();
    }

    public void Remove()
    {
        
    }
     
    public void Take()
    {
        if (!_isTaken)
        {
            _state = SlotsState.MouseTrack;
            _isTaken = true;
            StartCoroutine(MouseTrack());
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _state = SlotsState.Chill;
        _delay = new WaitForSeconds(0.01f);
        _caster = transform.GetComponentInParent<GraphicRaycaster>();
        _pointerEvent = new(null);
        _hitsTargets = new();
        _offset.z = 20f;
        _offset.x = transform.gameObject.GetComponent<RectTransform>().rect.width / 2;
        _offset.y = transform.gameObject.GetComponent<RectTransform>().rect.height / 2;
    }

    private IEnumerator MouseTrack()
    {
        while (_state == SlotsState.MouseTrack) 
        {
            Move();
            if (Input.GetMouseButton(0))
            {
                
                _state = SlotsState.Chill;
                Put();

            }
            yield return _delay;
        }
        yield return null;
    }

    private void ChangeTake()
    {
        _isTaken = !_isTaken;
    }
}
