using System.Collections.Generic;
using UnityEngine;

namespace NeuroViz
{
    /// <summary>
    /// Handles the global state of the game <br/>
    ///     What area is currently selected <br/>
    ///     Current view mode, etc.
    /// </summary>
    public class BrainStateManager : MonoBehaviour
    {
        /// <summary>
        /// The brain model
        /// </summary>
        public GameObject brain;

        /// <summary>
        /// An internal reference to the current selected area; to be used by every other script to know "what's happening"
        /// </summary>
        [HideInInspector]
        public ClickableBrainArea currentSelectedArea;

        /// <summary>
        /// The scriptable object that contains all the brain area names and descriptions
        /// </summary>
        public BrainAreaDatabase brainAreaDatabase;

        /// <summary>
        /// The left cerebrum from the brain model in the scene
        /// </summary>
        public GameObject leftCerebrum;

        /// <summary>
        /// The right cerebrum from the brain model in the scene
        /// </summary>
        public GameObject rightCerebrum;

        /// <summary>
        /// The cerebellum from the brain model in the scene
        /// </summary>
        public GameObject cerebellum;

        /// <summary>
        /// Used to define what state the view of the brain is in <br/>
        ///     Default = 0: as is <br/>
        ///     Cross_Section = 1: right cerebrum deactivated so half of inside can be seen <br/>
        ///     Internal = 2: right cerebrum, left cerebrum, and cerebellum deactivated so all of inside can be seen
        /// </summary>
        public enum BrainState
        {
            Default = 0,
            Cross_Section = 1,
            Internal = 2,
        }

        /// <summary>
        /// The current state of view the brain is in
        /// </summary>
        [HideInInspector]
        public BrainState currentState = BrainState.Default;

        /// <summary>
        /// Starting position of brain if camera is at (0,0,0) <br/>
        /// Used to re-focus
        /// </summary>
        private Vector3 brainDistanceFromCamera;

        /// <summary>
        /// A local store of all the brain areas and corresponding descriptions <br/>
        /// Loaded from the scriptable object on Start() to prevent frequent lookups to scriptable object
        /// </summary>
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
            brainDistanceFromCamera = brain.transform.position;
        }

        /// <summary>
        /// Handles clicking of a brain area; updates local references, relays call to UIManager
        /// </summary>
        /// <param name="selectedArea">The ClickableArea component of the brain area that was clicked on</param>
        public void SelectBrainArea(ClickableBrainArea selectedArea)
        {
            currentSelectedArea = selectedArea;
            if (brainAreaDescriptions.ContainsKey(selectedArea.brainArea))
            {
                UIManager.Instance.DisplayBrainAreaDetails(selectedArea.brainArea.ToString(), brainAreaDescriptions[selectedArea.brainArea]);
            }
        }

        /// <summary>
        /// Load the brain area names and descriptions to a local dictionarys
        /// </summary>
        private void LoadBrainData()
        {
            foreach (BrainAreaData data in brainAreaDatabase.brainAreas)
            {
                if (data == null) continue;
                brainAreaDescriptions.Add(data.brainArea, data.longDescription);
            }
        }

        /// <summary>
        /// Handles transition of brain view states from UI buttons in game
        /// </summary>
        /// <param name="targetStateEnumInt">An integer representation of the targetState enum because we can't do enums in Unity btn onClick</param>
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
        
        /// <summary>
        /// Brings the brain back into camera view
        /// </summary>
        public void ReFocusBrain()
        {
            brain.transform.position = Camera.main.transform.position + brainDistanceFromCamera;
            Camera.main.transform.rotation = Quaternion.identity;
        }
    }
}
