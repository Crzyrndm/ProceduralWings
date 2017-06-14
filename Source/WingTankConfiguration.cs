using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pWings
{
    public class WingTankConfiguration : IConfigNode
    {
        public string GUIName;
        public Dictionary<string, WingTankResource> resources = new Dictionary<string, WingTankResource>();

        public WingTankConfiguration(ConfigNode node)
        {
            Load(node);
        }

        public void Load(ConfigNode node)
        {
            float ratioTotal = 0;

            GUIName = node.GetValue("name");
            ConfigNode[] nodes = node.GetNodes("Resource");
            foreach (ConfigNode n in nodes)
            {
                var res = new WingTankResource(n);
                if (res.resource != null)
                {
                    resources.Add(res.resource.name, res);
                    ratioTotal += res.ratio;
                }
            }
            foreach (KeyValuePair<string, WingTankResource> kvp in resources)
            {
                kvp.Value.SetUnitsPerVolume(ratioTotal);
            }
        }

        public void Save(ConfigNode node) { }
    }
}
