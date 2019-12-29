using MarsRover.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test
{
    [TestFixture]
    public class PlateauTests
    {
        Result result;
        Plateau plateau;

        [Test]
        public void Create_Plateau_Should_Throw_Exception()
        {
            result = new Result();
            plateau = new Plateau(5, -5, result);
            Assert.AreEqual(result.IsSuccess, false);
        }

        [Test]
        public void Create_Plateau_Get_Success()
        {
            result = new Result();
            plateau = new Plateau(5, 5, result);
            Assert.AreEqual(result.IsSuccess, true);
        }
    }
}
