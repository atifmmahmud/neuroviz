using System.Collections.Generic;
using UnityEngine;

namespace NeuroViz
{
    /// <summary>
    /// The scriptable object class acting as the data source for brain area and descriptions
    /// </summary>
    [CreateAssetMenu(fileName = "BrainDatabase", menuName = "Neuroviz/Data/Brain")]
    public class BrainAreaDatabase : ScriptableObject
    {
        /// <summary>
        /// A collection of all the brain areas and their descriptions
        /// </summary>
        public List <BrainAreaData> brainAreas;
    }

    /// <summary>
    /// A container class for defining a brain area
    /// </summary>
    [System.Serializable]
    public class BrainAreaData
    {
        /// <summary>
        /// An enum idenitfying the known brain areas
        /// </summary>
        public BrainArea brainArea;

        /// <summary>
        /// A short description of the brain area
        /// </summary>
        public string shortDescription;

        /// <summary>
        /// A long description of the brain area to display
        /// </summary>
        public string longDescription;
    }
}

