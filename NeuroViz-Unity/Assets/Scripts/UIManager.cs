using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NeuroViz
{
    /// <summary>
    /// Handles updating the UI <br/>
    /// And also clicking on brain area (TODO: move this away from this script)
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        /// <summary>
        /// A reference to the UI panel for displaying brain area description
        /// </summary>
        public GameObject uiPanel;

        /// <summary>
        /// The TMPro GUI component for the title
        /// </summary>
        public TextMeshProUGUI title;

        /// <summary>
        /// The TMPro GUI component for the description
        /// </summary>
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
            // Use position of mouse
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

        /// <summary>
        /// Display the brain data on the UI
        /// </summary>
        /// <param name="areaName">The name of the area</param>
        /// <param name="areaDescription">The long description of the area</param>
        public void DisplayBrainAreaDetails(string areaName, string areaDescription)
        {
            uiPanel.SetActive(true);
            title.text = areaName;
            description.text = areaDescription;
        }
    }
}

