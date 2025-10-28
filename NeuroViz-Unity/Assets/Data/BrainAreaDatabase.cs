using System.Collections.Generic;
using UnityEngine;

namespace NeuroViz
{
    [CreateAssetMenu(fileName = "BrainDatabase", menuName = "Neuroviz/Data/Brain")]
    public class BrainAreaDatabase : ScriptableObject
    {
        [SerializeField]
        List <BrainAreaData> brainAreas;
    }

    [System.Serializable]
    public class BrainAreaData
    {
        [SerializeField] private BrainArea brainArea;
        [SerializeField] private string shortDescription;
        [SerializeField] private string longDescription;
    }
}

