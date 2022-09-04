using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelLine;

namespace ParcelLineTest
{
    [TestClass]
    public class ParcelLineHelperTest
    {
        private const string FORMAT_OK = "60, 120,  100,75";
        private const string FORMAT_NOT_OK_EMPTY= "";
        private const string FORMAT_NOT_OK_EMPTY_VALUE = "60, 120,,100, 75";
        private const string FORMAT_NOT_OK_TOO_FEW_NUM = "60, 120";
        private const string FORMAT_NOT_OK_NOT_NUM = "60, 120, 100, 75, k";
        private const string FORMAT_NOT_OK_NOT_ZERO = "60, 120, 100, 0, 7";
        private const string FORMAT_NOT_OK_NOT_NEG = "60, -120, 100, 10, 7";


        [TestMethod]
        public void CommaStrInputIsValid()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_OK);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CommaStrInputNotValidZeroValue()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_NOT_OK_NOT_ZERO);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CommaStrInputNotValidNegativeValue()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_NOT_OK_NOT_NEG);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CommaStrInputNotValidEmptyValue()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_NOT_OK_EMPTY_VALUE);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CLInputNotValidEmptyInput()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_NOT_OK_EMPTY);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CommaStrInputNotValidTooFewNum()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_NOT_OK_TOO_FEW_NUM);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CommaStrInputNotValidNotNum()
        {
            bool isValid = ParcelLineHelper.ValidateParcelPipeCommaStrInput(FORMAT_NOT_OK_NOT_NUM);
            Assert.IsFalse(isValid);
        }
    }
}
