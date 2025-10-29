using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NeuroViz
{
    public class BrainStateManager : MonoBehaviour
    {
        [HideInInspector]
        public ClickableBrainArea currentSelectedArea;
        public BrainAreaDatabase brainAreaDatabase;

        public GameObject leftCerebrum;
        public GameObject rightCerebrum;
        public GameObject cerebellum;

        public enum BrainState
        {
            Default = 0,
            Cross_Section = 1,
            Internal = 2,
        }

        [HideInInspector]
        public BrainState currentState = BrainState.Default;
        private Dictionary<BrainArea, string> brainAreaDescriptions = new Dictionary<BrainArea, string>();

        // Singleton implementation
        [HideInInspector]
        public static BrainStateManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            LoadBrainData();
        }

        public void SelectBrainArea(ClickableBrainArea selectedArea)
        {
            currentSelectedArea = selectedArea;
            if (brainAreaDescriptions.ContainsKey(selectedArea.brainArea))
            {
                UIManager.Instance.DisplayBrainAreaDetails(selectedArea.brainArea.ToString(), brainAreaDescriptions[selectedArea.brainArea]);
            }
        }

        private void LoadBrainData()
        {
            foreach (BrainAreaData data in brainAreaDatabase.brainAreas)
            {
                if (data == null) continue;
                brainAreaDescriptions.Add(data.brainArea, data.longDescription);
            }
        }

        public void TransitionToBrainState(int targetStateEnumInt)
        {
            BrainState targetState = (BrainState)targetStateEnumInt;
            switch (targetState)
            {
                case BrainState.Default:
                    rightCerebrum.SetActive(true);
                    leftCerebrum.SetActive(true);
                    cerebellum.SetActive(true);
                    break;
                case BrainState.Cross_Section:
                    rightCerebrum.SetActive(false);
                    leftCerebrum.SetActive(true);
                    cerebellum.SetActive(true);
                    break;
                case BrainState.Internal:
                    rightCerebrum.SetActive(false);
                    leftCerebrum.SetActive(false);
                    cerebellum.SetActive(false);
                    break;
                default:
                    break;
            }
            currentState = targetState;
        }
    }
}
