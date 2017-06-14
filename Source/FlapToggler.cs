using UnityEngine;

namespace DYJlibrary
{
    class FlapToggler : PartModule
    {
        [KSPField]
        public string flapTransform = "obj_ctrlSrf";

        [KSPField(isPersistant = true)]
        public bool FlapActive = true;

        public Transform Flap;
        Renderer cachedRenderer;

        public override void OnStart(PartModule.StartState state)
        {
            Flap = part.FindModelTransform(flapTransform);
            cachedRenderer = Flap.gameObject.GetComponent<Renderer>();
            if (FlapActive != false)
            {
                ToggleFlaps();
            }
        }

        [KSPEvent(active =true, guiActive =true, guiActiveEditor =true,guiName ="Toggle Flaps")]
        public void ToggleFlaps()
        {
            cachedRenderer.enabled = !FlapActive;
            FlapActive = !FlapActive;
        }
    }
}    