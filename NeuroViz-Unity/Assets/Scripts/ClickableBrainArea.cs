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

        private void Start()
        {
            onClick.AddListener(OnClick);
            onClickAway.AddListener(OnClickAway);
        }

        private void OnClick()
        {
            this.GetComponent<Outline>().enabled = true;
            BrainStateManager.Instance.SelectBrainArea(this.brainArea);
        }

        private void OnClickAway()
        {
            this.GetComponent<Outline>().enabled = false;
        }
    }
}
