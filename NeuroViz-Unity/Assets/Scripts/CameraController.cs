using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroViz
{
    public class CameraController : MonoBehaviour
    {
        private Transform _cameraTransform;
        private const float MOUSE_AXIS_SENSITIVITY = 2f;
        private const float MOUSE_ROTATE_SENSITIVITY = 20f;
        private const float KEYBOARD_MOVE_SENSITIVITY = 3f;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            var mouse = Mouse.current;
            if (mouse == null) return;
            Vector3 mouseAxis = new Vector3(mouse.delta.x.ReadValue(), mouse.delta.y.ReadValue(), 0);

            // Move along axis
            if (mouse.middleButton.isPressed)
            {
                _cameraTransform.position += mouseAxis * Time.deltaTime * MOUSE_AXIS_SENSITIVITY;
            }
            // Rotate: yaw (around y-axis), and pitch (around x-axis). NO ROLL (around z-axis).
            // Allow keyboard movement ONLY when right btn pressed
            else if (mouse.rightButton.isPressed)
            {
                _cameraTransform.Rotate(-mouse.delta.y.ReadValue() * Time.deltaTime * MOUSE_ROTATE_SENSITIVITY, //
                    mouse.delta.x.ReadValue() * Time.deltaTime * MOUSE_ROTATE_SENSITIVITY, //
                    0);
                KeyboardMove();
            }
        }

        private void KeyboardMove()
        {
            var keyboard = Keyboard.current;
            if (keyboard == null) return;

            if (keyboard.wKey.isPressed)
            {
                _cameraTransform.position += _cameraTransform.forward * KEYBOARD_MOVE_SENSITIVITY * Time.deltaTime;
            }
            if (keyboard.aKey.isPressed)
            {
                _cameraTransform.position -= _cameraTransform.right * KEYBOARD_MOVE_SENSITIVITY * Time.deltaTime;
            }
            if (keyboard.sKey.isPressed)
            {
                _cameraTransform.position -= _cameraTransform.forward * KEYBOARD_MOVE_SENSITIVITY * Time.deltaTime;
            }
            if (keyboard.dKey.isPressed)
            {
                _cameraTransform.position += _cameraTransform.right * KEYBOARD_MOVE_SENSITIVITY * Time.deltaTime;
            }
            if (keyboard.qKey.isPressed)
            {
                _cameraTransform.position -= _cameraTransform.up * KEYBOARD_MOVE_SENSITIVITY * Time.deltaTime;
            }
            if (keyboard.eKey.isPressed)
            {
                _cameraTransform.position += _cameraTransform.up * KEYBOARD_MOVE_SENSITIVITY * Time.deltaTime;
            }    
        }
    }

}
