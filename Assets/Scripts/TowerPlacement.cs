using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject _tower;
    private PlayerInputActions _input;

    private GameObject _towerPlacement;

    private bool _placingTower=false;

    // Start is called before the first frame update
    void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        //_input.Player.TowerPlacement.started += TowerPlacement_started;
        _input.Player.TowerPlacement.canceled += TowerPlacement_canceled;
    }

    private void TowerPlacement_canceled(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//.ScreenPointToRay(new Vector3(Mouse.current.position.x, Mouse.current.position.y, 0));
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 6) || !hit.collider.gameObject.CompareTag("Platform"))
        {
            Destroy(_towerPlacement);
            return;
        }
        else
        {
            if (_towerPlacement != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out TowerPlatform tp))
                {
                    if (_towerPlacement != null)
                    {
                        _towerPlacement.transform.position = tp.GetPlacementPoint().position;
                        hit.collider.tag = "Occupied";
                    }
                }
                _towerPlacement = null;
            }

        }
        _placingTower = false;
    }
    /*
    private void TowerPlacement_started(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//.ScreenPointToRay(new Vector3(Mouse.current.position.x, Mouse.current.position.y, 0));
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 6))
            return;

        _towerPlacement = Instantiate(_tower,hit.point,_tower.transform.rotation);

        _placingTower = true;
    }*/

    // Update is called once per frame
    void Update()
    {
        if (_placingTower)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//.ScreenPointToRay(new Vector3(Mouse.current.position.x, Mouse.current.position.y, 0));
            if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 6))
                return;
            if(hit.collider.gameObject.TryGetComponent(out TowerPlatform tp))
            {
                if (_towerPlacement != null)
                {
                    _towerPlacement.transform.position = hit.point;
                    //_towerPlacement.transform.position = tp.GetPlacementPoint().position;
                    _towerPlacement.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
                }
            }
            else
            {
                if (_towerPlacement != null)
                {
                    _towerPlacement.transform.position = hit.point;
                    _towerPlacement.GetComponentInChildren<MeshRenderer>().material.color = Color.red;

                }
            }
        }
    }

    public void CreateRocket()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//.ScreenPointToRay(new Vector3(Mouse.current.position.x, Mouse.current.position.y, 0));
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 6))
            return;

        _towerPlacement = Instantiate(_tower, hit.point, _tower.transform.rotation);

        _placingTower = true;

    }
}
