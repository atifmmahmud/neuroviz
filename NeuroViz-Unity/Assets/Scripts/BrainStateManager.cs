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
    }
}
