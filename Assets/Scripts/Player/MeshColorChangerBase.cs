using UnityEngine;

namespace MeltdownGame.Player
{
    public class MeshColorChangerBase : MonoBehaviour
    {
        [SerializeField] private Renderer[] _objectsRenderer = null;
        private MaterialPropertyBlock _propertyBlock;
        protected string _currentObjectColorId = null;
        private int _shaderColorId;
        protected Renderer[] ObjectsRenderer => _objectsRenderer;
        public Color Meshcolor;

        private void Start()
        {
            InitPropertyBlock();
            SetColorToMeshes(Meshcolor);
        }

        private void InitPropertyBlock()
        {
            _shaderColorId = Shader.PropertyToID("_Color");
            _propertyBlock = new MaterialPropertyBlock();
        }
        private void SetColorToMeshes(Color newColor)
        {
            for (int i = 0; i < ObjectsRenderer.Length; i++)
            {
                for (int j = 0; j < ObjectsRenderer[i].materials.Length; j++)
                {
                    ChangeMaterialColor(ObjectsRenderer[i], newColor, j);
                }
            }
        }
        private void ChangeMaterialColor(Renderer renderer, Color newColor, int materialIndex)
        {
            renderer.GetPropertyBlock(_propertyBlock, materialIndex);
            _propertyBlock.SetColor(_shaderColorId, newColor);
            renderer.SetPropertyBlock(_propertyBlock);
        }

    }
}