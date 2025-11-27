using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkrøblighedsPakkeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkrøblighedsPakkeLib.Tests
{
    [TestClass()]
    public class LimitProfileTests
    {
        [TestMethod()]
        public void SetFragile_souldUpdateIsFraglieToTrue()
        {
            // Arrange
            var limitProfile = new LimitProfile();
            //act 
            limitProfile.SetFragile(true);
            //assert
            Assert.IsTrue(limitProfile.IsFragile,"IsFragile should be true after calling SetFragile(true.");
        }

        [TestMethod()]
        public void SetFragile_souldUpdateIsFraglieToFalse()
        {
            // Arrange
            var limitProfile = new LimitProfile();
            //act 
            limitProfile.SetFragile(false);
            //assert
            Assert.IsFalse(limitProfile.IsFragile, "IsFragile should be false after calling SetFragile(false.");
        }


    }
}