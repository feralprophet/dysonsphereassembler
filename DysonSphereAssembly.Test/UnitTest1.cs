using System.Collections.Generic;
using Dyson_Sphere_Assembly_Line_Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DysonSphereAssembly.Test
{
    [TestClass]
    public class BuildTests
    {
        //public Component _componentToBuild = new Component
        //{
        //    NumberProduced = 1,
        //    TimeToCreate = 2
        //};

        //public Component _component1 = new Component
        //{
        //    NumberProduced = 2,
        //    TimeToCreate = 1
        //};
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void given_a_build_when_updating_desired_then_build_inputs_should_update()
        {
            var build = new Build();
            //build.ComponentToBuild = new BuildComponent()
            //{
            //    Component = new InputComponent { Component = _componentToBuild, AmountNeeded = 1},
            //    BuilderMachine = new Machine {MachineType = MachineType.Assembler, Name = "", ProductionModifier = 1.0m},
            //    InputComponents = new List<BuildComponent>
            //    {
            //        new BuildComponent()
            //        {
            //            Component = new InputComponent(){Component = _component1, AmountNeeded = 2},
            //            BuilderMachine = new Machine(){ MachineType = MachineType.Assembler, Name = "", ProductionModifier = 1.0m}
            //        }
            //    }
            //};

            //build.DesiredPerMinute = 60;

            //var component1Needed = build.ComponentToBuild.InputComponents[0].NeededPerMinute;

            //Assert.IsTrue(build.DesiredPerMinute *2 == build.ComponentToBuild.InputComponents[0].NeededPerMinute);
        }

        [TestMethod]
        public void
            given_a_build_when_component_produces_two_and_input_requires_two_and_time_is_one_second_then_number_per_minute_should_equal_build_per_minute()
        {
            var build = new Build();
            //build.ComponentToBuild = new BuildComponent()
            //{
            //    Component = new InputComponent { Component = _componentToBuild, AmountNeeded = 1 },
            //    BuilderMachine = new Machine { MachineType = MachineType.Assembler, Name = "", ProductionModifier = 1.0m },
            //    InputComponents = new List<BuildComponent>
            //    {
            //        new BuildComponent()
            //        {
            //            Component = new InputComponent(){Component = _component1, AmountNeeded = 2},
            //            BuilderMachine = new Machine(){ MachineType = MachineType.Assembler, Name = "", ProductionModifier = 1.0m}
            //        }
            //    }
            //};

            //build.DesiredPerMinute = 60;
            //var buildPerMinute = build.ComponentToBuild.InputComponents[0].NumberPerMinuteFromBuilder;
            //var neededPerMinute = build.ComponentToBuild.InputComponents[0].NeededPerMinute;

            //Assert.IsTrue(buildPerMinute == neededPerMinute);
        }
    }
}
