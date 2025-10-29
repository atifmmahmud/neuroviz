using UnityEngine;
using UnityEngine.Events;

namespace NeuroViz
{
    public class ClickableBrainArea : MonoBehaviour
    {
        public UnityEvent onClick;
        public UnityEvent onClickAway;
        public BrainArea brainArea;

        private string brainAreaTitle;
        private string brainAreaDescription;
        private bool isSelected = false;

        private void Start()
        {
            onClick.AddListener(OnClick);
            onClickAway.AddListener(OnClickAway);
        }

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

        private void OnClickAway()
        {
            isSelected = false;
            var outline = this.GetComponent<Outline>();
            if (outline != null) outline.enabled = false;
        }
    }
}
