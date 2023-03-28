using UnityEngine;
namespace MeltdownGame.Player
{
    public class NPCBuilder
    {
        private NPCController _prefab;
        private Color _color;
        public NPCBuilder FromNPCControllerPrefab(NPCController prefab)
        {
            _prefab = prefab;
            return this;
        }
        public NPCBuilder WithNPCColor(Color color)
        {
            _color = color;
            return this;
        }

        public NPCController Build()
        {
            var npc = Object.Instantiate(_prefab);
            npc.SetColor(_color);
            return npc;
        }
    }
}