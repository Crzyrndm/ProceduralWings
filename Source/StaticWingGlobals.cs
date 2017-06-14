using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace pWings
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class StaticWingGlobals : MonoBehaviour
    {
        public static List<WingTankConfiguration> wingTankConfigurations = new List<WingTankConfiguration>();

        public void Start()
        {
            ConfigNode node = GameDatabase.Instance.GetConfigNodes("ProceduralWingFuelSetups").FirstOrDefault();
            if (node != null)
            {
                ConfigNode[] nodes = node.GetNodes("FuelSet");
                foreach (ConfigNode n in nodes)
                {
                    wingTankConfigurations.Add(new WingTankConfiguration(n));
                }
            }
            LoadConfiguration();
        }

        // Cribbed from FAR, with thanks to ferram4
        public void LoadConfiguration()
        {
            ConfigNode node = GameDatabase.Instance.GetConfigNodes("PWingsSettings").FirstOrDefault();
            if (node == null)
            {
                return;
            }

            if (node.HasValue("keyTranslation"))
            {
                WingManipulator.keyTranslation = (KeyCode)Enum.Parse(typeof(KeyCode), node.GetValue("keyTranslation"), true);
            }

            if (node.HasValue("keyTipScale"))
            {
                WingManipulator.keyTipScale = (KeyCode)Enum.Parse(typeof(KeyCode), node.GetValue("keyTipScale"), true);
            }

            if (node.HasValue("keyRootScale"))
            {
                WingManipulator.keyRootScale = (KeyCode)Enum.Parse(typeof(KeyCode), node.GetValue("keyRootScale"), true);
            }

            if (node.HasValue("moveSpeed"))
            {
                float.TryParse(node.GetValue("moveSpeed"), out WingManipulator.moveSpeed);
            }

            if (node.HasValue("scaleSpeed"))
            {
                float.TryParse(node.GetValue("scaleSpeed"), out WingManipulator.scaleSpeed);
            }

            WingManipulator.loadedConfig = true;
        }
    }
}
