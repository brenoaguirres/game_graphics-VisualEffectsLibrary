using UnityEngine;

namespace CBPXL.MainLevel
{
    [RequireComponent(typeof(Rigidbody))]
    public class CameraMovement : MonoBehaviour
    {
        #region FIELDS
        [Header("Move Settings")]
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _rotationSpeed = 3f;
        #endregion

        #region REFERENCES
        // Move Directions
        private Vector2 _rotation = Vector2.zero;
        private Vector3 _movement = Vector3.zero;

        // Components
        private Rigidbody _rigidbody;
        #endregion

        #region UNITY METHODS
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            ResolveMovement();
        }

        private void FixedUpdate()
        {
            ApplyVelocity();
        }
        #endregion

        #region CUSTOM METHODS
        private void ResolveMovement()
        {
            _rotation += new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
            transform.eulerAngles = _rotation * _rotationSpeed;

            var xMov = Input.GetAxis("Horizontal");
            var zMov = Input.GetAxis("Vertical");

            _movement = new Vector3(xMov, 0, zMov) * _moveSpeed;
        }
        private void ApplyVelocity()
        {
            _rigidbody.linearVelocity = transform.TransformDirection(_movement);
        }
        #endregion
    }
}
