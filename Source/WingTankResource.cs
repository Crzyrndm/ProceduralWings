using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pWings
{
    public class WingTankResource : IConfigNode
    {
        public PartResourceDefinition resource;
        public float unitsPerVolume; // resource units per 1m^3 of wing
        public float ratio;

        public WingTankResource(ConfigNode node)
        {
            Load(node);
        }

        public void Load(ConfigNode node)
        {
            string resourceID = node.GetValue("name");
            if (PartResourceLibrary.Instance.resourceDefinitions.Contains(resourceID))
            {
                resource = PartResourceLibrary.Instance.resourceDefinitions[resourceID];
                float.TryParse(node.GetValue("ratio"), out ratio);
            }
        }

        public void Save(ConfigNode node) { }

        public void SetUnitsPerVolume(float ratioTotal)
        {
            if (resource.volume == 0)
                unitsPerVolume = ratio;
            else
                unitsPerVolume = ratio * 1000.0f / (resource.volume * ratioTotal);
        }
    }
}
