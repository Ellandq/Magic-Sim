using System.Collections.Generic;
using UnityEngine;

namespace UI.Screens.SkillTree
{
    public class SkillNode : MonoBehaviour
    {
        [SerializeField] private SkillTree subTree;

        [SerializeField] private List<SkillNode> childNodes;
    }
}