using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScr : MonoBehaviour
{ 
    public int Damage
    {
        get
        {
            return _damage;
        }
    }

    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private Vector2 _ballInitialForce = new Vector2(100f, 300f);

    private bool _isActive = false;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFlying();
        }
        
    }

    private void StartFlying()
    {
        if (!_isActive)
        {
            _isActive = true;
            _rb.AddForce(_ballInitialForce);
        }        
    }

    public void Kill() {

    }
}
