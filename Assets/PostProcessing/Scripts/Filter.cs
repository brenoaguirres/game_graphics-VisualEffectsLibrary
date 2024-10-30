using System;
using UnityEngine;

namespace CBPXL.Filter
{
    public class Filter : MonoBehaviour
    {
        #region REFERENCES
        [Header("Shading")]
        [SerializeField] private Shader _shader;
        [SerializeField] private FilterCreator _filterCreator;
        #endregion

        public void OnEnable()
        {
            if (_shader == null || _filterCreator == null) return;

            _filterCreator.Shader = _shader;
        }
    }
}