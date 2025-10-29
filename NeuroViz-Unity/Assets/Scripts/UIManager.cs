using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroViz
{
    public class UIManager : MonoBehaviour
    {
        public GameObject uiPanel;
        public TextMeshProUGUI title;
        public TextMeshProUGUI description;

        // Singleton implementation
        [HideInInspector]
        public static UIManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            var mouse = Mouse.current;
            if (mouse == null) return;

            // Left click to interact with brain areas
            if (mouse.leftButton.wasPressedThisFrame)
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
                RaycastHit hit;
                if (Physics.Raycast(mouseRay, out hit))
                {
                    ClickableBrainArea brainAreaComponent = hit.collider.gameObject.GetComponent<ClickableBrainArea>();
                    if (brainAreaComponent == null ) { return; }
                    brainAreaComponent.onClick.Invoke();
                }
            }
        }

        public void DisplayBrainAreaDetails(string areaName, string areaDescription)
        {
            uiPanel.SetActive(true);
            title.text = areaName;
            description.text = areaDescription;
        }
    }
}

