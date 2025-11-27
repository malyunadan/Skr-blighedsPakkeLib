using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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
        [TestClass]
        public class LimitProfileTests
        {
            [TestMethod]
            public void Constructor_ShouldSetIsFragileToTrue()
            {
                // Arrange + Act
                var limitProfile = new LimitProfile(1, "Fragile", 5.0, 10.0, true);

                // Assert
                Assert.IsTrue(limitProfile.IsFragile,
                    "IsFragile should be true when constructed with isFragile = true.");
            }

            [TestMethod]
            public void Constructor_ShouldSetIsFragileToFalse()
            {
                // Arrange + Act
                var limitProfile = new LimitProfile(2, "Normal", 20.0, 45.0, false);

                // Assert
                Assert.IsFalse(limitProfile.IsFragile,
                    "IsFragile should be false when constructed with isFragile = false.");
            }
        }
    }

        