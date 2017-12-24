using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class PrimitiveGenerator
    {
        [Inject]
        public GeometryObjectData GOData { get; private set; }

        List<Primitive> primitives;
        public void Init(List<Primitive> primitives)
        {
            this.primitives = primitives;
        }
        public Primitive GenPrimitive()
        {
            if (primitives == null || primitives.Count == 0)
                throw new System.Exception("not initialized exception");
            return primitives[Random.Range(0, primitives.Count)];
        }
    }
}