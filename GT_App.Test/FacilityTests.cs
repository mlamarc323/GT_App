using System;
using System.Collections;
using System.Collections.Generic;
using GT_App.Controllers;
using GT_App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GT_App.Test
{
    [TestClass]
    public class FacilityTests
    {
        [TestMethod]
        public void GetFacilitesTest()
        {
            IEnumerable<Facility> target;
            target = FacilityController.GetAllFacilities();
            Assert.IsNotNull(target);
        }
    }
}
