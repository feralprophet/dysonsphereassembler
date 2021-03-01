using Dyson_Sphere_Assembly_Line_Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DysonSphereAssembly.Test
{
    [TestClass]
    public class InputCalculatorTests
    {
        [TestMethod]
        public void given_a_belt_speed_of_1800_and_a_recipetime_of_1_seconds_and_an_input_of_1_and_a_modifier_of_1_when_calculated_the_result_is_30()
        {
            var inputCalculator = new InputCalculator();
            inputCalculator.InputAmount = 1;
            inputCalculator.MachineModifier = 1;
            inputCalculator.RecipeTime = 1;
            inputCalculator.BeltSpeed = 1800;

            var result = inputCalculator.CalculateMachinesNeeded();

            Assert.IsTrue(result == 30m);
        }
        [TestMethod]
        public void given_a_belt_speed_of_1800_and_a_recipetime_of_2_seconds_and_an_input_of_2_and_a_modifier_of_1_when_calculated_the_result_is_30()
        {
            var inputCalculator = new InputCalculator();
            inputCalculator.InputAmount = 2;
            inputCalculator.MachineModifier = 1;
            inputCalculator.RecipeTime = 2;
            inputCalculator.BeltSpeed = 1800;

            var result = inputCalculator.CalculateMachinesNeeded();

            Assert.IsTrue(result == 30m);
        }
        [TestMethod]
        public void given_a_belt_speed_of_1800_and_a_recipetime_of_6_seconds_and_an_input_of_10_and_a_modifier_of_1_when_calculated_the_result_is_18()
        {
            var inputCalculator = new InputCalculator();
            inputCalculator.InputAmount = 10;
            inputCalculator.MachineModifier = 1;
            inputCalculator.RecipeTime = 6;
            inputCalculator.BeltSpeed = 1800;

            var result = inputCalculator.CalculateMachinesNeeded();

            Assert.IsTrue(result == 18m);
        }
        [TestMethod]
        public void given_a_belt_speed_of_1800_and_a_recipetime_of_6_seconds_and_an_input_of_10_and_a_modifier_of_1_5_when_calculated_the_result_is_12()
        {
            var inputCalculator = new InputCalculator();
            inputCalculator.InputAmount = 10;
            inputCalculator.MachineModifier = 1.5m;
            inputCalculator.RecipeTime = 6;
            inputCalculator.BeltSpeed = 1800;

            var result = inputCalculator.CalculateMachinesNeeded();

            Assert.IsTrue(result == 12m);
        }
    }
}
