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

    private BallsManager _manager;
    private bool _isActive = false;
    private Rigidbody2D _ballRb;

    public void SetBallManager(BallsManager manager) {
        _manager = manager;
    }
    
    void Start()
    {
        _ballRb = gameObject.GetComponent<Rigidbody2D>();
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
            transform.parent = null;
            _ballRb.AddForce(_ballInitialForce);
        }        
    }

    public void Die() {
        _manager.KillTheBall(this);
    }

}
