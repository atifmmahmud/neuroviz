using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NeuroViz
{
    public class BrainStateManager : MonoBehaviour
    {
        public BrainAreaDatabase brainAreaDatabase;

        [HideInInspector]
        public BrainArea currentSelectedArea;

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

        public void SelectBrainArea(BrainArea area)
        {
            currentSelectedArea = area;
            UIManager.Instance.DisplayBrainAreaDetails(area.ToString(), brainAreaDescriptions[area]);
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
