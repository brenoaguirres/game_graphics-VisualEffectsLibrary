using System;
using UnityEngine;

namespace CBPXL.Filter
{
    public class FilterCreator : MonoBehaviour
    {
        #region FIELDS
        [Header("Shading")]
        [SerializeField] private Shader _shader;
        private Material _material;
        #endregion

        #region PROPERTIES
        public Shader Shader
        {
            get { return _shader; }
            set
            {
                _shader = value;
                CreateMaterial();
            }
        }
        #endregion
        
        #region UNITY METHODS
        public void Awake()
        {
            CreateMaterial();
        }

        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (_shader == null) return;
            Debug.Log("test");
            Graphics.Blit(source, destination, _material);
        }
        #endregion
        
        #region CUSTOM METHODS

        public void CreateMaterial()
        {
            if (_shader == null) return;
            
            _material = new Material(_shader);
        }
        #endregion
    }
}