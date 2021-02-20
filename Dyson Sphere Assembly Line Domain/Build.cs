using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dyson_Sphere_Assembly_Line_Domain
{
    public class Build
    {
        private int _desiredPerMinute = 0;
        public BuildComponent ComponentToBuild { get; set; }
        public int DesiredPerMinute
        {
            get { return _desiredPerMinute; }
            set
            {
                if (value != _desiredPerMinute)
                {
                    _desiredPerMinute = value;
                    ComponentToBuild.BuildTargetPerMinute = _desiredPerMinute;
                }
            }
        }

        public void RecalculateBuildAmount()
        {
            foreach (var buildComponent in ComponentToBuild.InputComponents)
            {
                buildComponent.BuildTargetPerMinute = _desiredPerMinute;
            }
        }
    }
}
