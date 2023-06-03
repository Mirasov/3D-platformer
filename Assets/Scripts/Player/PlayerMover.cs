using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _sphereRadius;
    [SerializeField] private LayerMask _groundLayer;
 
    private Vector3 _velocity;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
 
    void Start()
    {
        _velocity = Vector3.forward * _speed;
        _rigidbody = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump(_jumpForce);
        }
    }
 
    public void Jump(float jumpForce)
    {
        if(_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
 
    private void FixedUpdate()
    {
        Vector3 nextPosition = transform.position + _velocity * Time.fixedDeltaTime;
        nextPosition.y += _rigidbody.velocity.y * Time.fixedDeltaTime;
 
        _isGrounded = Physics.CheckSphere(transform.position, _sphereRadius, _groundLayer.value);
 
        _rigidbody.MovePosition(nextPosition);
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _sphereRadius);
    }
}
