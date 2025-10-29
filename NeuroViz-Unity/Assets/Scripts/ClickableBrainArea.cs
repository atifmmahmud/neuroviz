using UnityEngine;
using UnityEngine.Events;

namespace NeuroViz
{
    /// <summary>
    /// A component attached to the brain areas that can be clicked to read about
    /// </summary>
    public class ClickableBrainArea : MonoBehaviour
    {
        /// <summary>
        /// The action to invoke when this area is clicked
        /// </summary>
        public UnityEvent onClick;

        /// <summary>
        /// The action to invoke when any other area is clicked
        /// </summary>
        public UnityEvent onClickAway;

        /// <summary>
        /// The enum reprenting what brain area this is <br/>
        /// This is curcial for identifying this area and displaying information properly
        /// </summary>
        public BrainArea brainArea;

        /// <summary>
        /// Set to true if this area is selected
        /// </summary>
        private bool isSelected = false;

        private void Start()
        {
            onClick.AddListener(OnClick);
            onClickAway.AddListener(OnClickAway);
        }

        /// <summary>
        /// Function called when this area is clicked on
        /// </summary>
        private void OnClick()
        {
            if (BrainStateManager.Instance.currentSelectedArea != null)
            {
                BrainStateManager.Instance.currentSelectedArea.OnClickAway();
            }
            BrainStateManager.Instance.SelectBrainArea(this);
            isSelected = true;
            var outline = this.GetComponent<Outline>();
            if (outline != null) outline.enabled = true;

        }

        /// <summary>
        /// Function called when something else is clicked <br/>
        /// Works like a "de-select"
        /// </summary>
        private void OnClickAway()
        {
            isSelected = false;
            var outline = this.GetComponent<Outline>();
            if (outline != null) outline.enabled = false;
        }
    }
}
