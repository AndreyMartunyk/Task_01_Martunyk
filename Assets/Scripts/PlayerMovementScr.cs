using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScr : MonoBehaviour
{
    [SerializeField]
    private float _playerSlidingArea = 2f;
    private Vector2 _playerPos;
    private Vector2 _mousePos;
    [SerializeField]
    private float _speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _playerPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_mousePos.x, transform.position.y), _speed * Time.deltaTime);
        if (transform.position.x  < -_playerSlidingArea)
        {
            transform.position =  new Vector2(-_playerSlidingArea, transform.position.y);
        }
        else if (transform.position.x > _playerSlidingArea)
        {
            transform.position = new Vector2(_playerSlidingArea, transform.position.y);
        }
    }

    private void OnMouseUp()
    {
        
    }

}
