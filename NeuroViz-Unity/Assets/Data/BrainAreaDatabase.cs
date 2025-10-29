using System.Collections.Generic;
using UnityEngine;

namespace NeuroViz
{
    [CreateAssetMenu(fileName = "BrainDatabase", menuName = "Neuroviz/Data/Brain")]
    public class BrainAreaDatabase : ScriptableObject
    {
        public List <BrainAreaData> brainAreas;
    }

    [System.Serializable]
    public class BrainAreaData
    {
        public BrainArea brainArea;
        public string shortDescription;
        public string longDescription;
    }
}

