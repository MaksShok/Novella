using _Project.Scripts.InteractableEnvironmentModule.InteractableActions;
using UnityEngine;

namespace _Project.Scripts.Misc
{
    public class MouseClickable : MonoBehaviour
    {
        [SerializeField] 
        private Collider2D _targetCollider;
        
        [SerializeField] 
        private BaseInteractableAction _unlockChest;

        private Camera sceneCamera;

        private void Awake()
        {
            sceneCamera = Camera.main;
            if (!sceneCamera)
                Debug.LogError("Не найдена камера с тегом 'MainCamera'");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                CheckClick();
        }

        private void CheckClick()
        {
            Vector3 mousePos = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && hit.collider == _targetCollider)
            {
                _unlockChest.Action();
            }
        }
    }
}