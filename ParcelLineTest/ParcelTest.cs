using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcelLine;
using System;

namespace ParcelLineTest
{
    [TestClass]
    public class ParcelTest
    {
        private const string PARCEL_FITS = "60, 120, 100, 75";
        private const string PARCEL_ALSO_FITS = "100, 35, 75, 50, 80, 100, 37";
        private const string PARCEL_DOES_NOT_FIT = "70, 50, 60, 60, 55,90";
        private const string PARCEL_SQUARE_PIPE_SQUARE_FIT = "2,2,2,2";
        private const string PARCEL_PIPE_SAME_FIT = "2,3,2,3";
        private const string PARCEL_PIPE_SAME_REV_FIT = "2,3,3,2";
        private const string PARCEL_PIPE_ARG_EXCEPTION = "1,2,k";

        [TestMethod]
        public void ParcelFits()
        {
            Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_FITS);
            Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_FITS);

            Assert.IsTrue(pipe.CanParcelFit(parcel));
        }

        [TestMethod]
        public void ParcelAlsoFits()
        {
            Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_ALSO_FITS);
            Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_ALSO_FITS);

            Assert.IsTrue(pipe.CanParcelFit(parcel));
        }

        [TestMethod]
        public void ParcelDoesNotFit()
        {
            Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_DOES_NOT_FIT);
            Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_DOES_NOT_FIT);

            Assert.IsFalse(pipe.CanParcelFit(parcel));
        }

        [TestMethod]
        public void ParcelSquarePipeSquareFit()
        {
            Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_SQUARE_PIPE_SQUARE_FIT);
            Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_SQUARE_PIPE_SQUARE_FIT);

            Assert.IsTrue(pipe.CanParcelFit(parcel));
        }

        [TestMethod]
        public void ParcelSquarePipeSameFit()
        {
            Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_PIPE_SAME_FIT);
            Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_PIPE_SAME_FIT);

            Assert.IsTrue(pipe.CanParcelFit(parcel));
        }

        [TestMethod]
        public void ParcelSquarePipeSameRevFit()
        {
            Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_PIPE_SAME_REV_FIT);
            Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_PIPE_SAME_REV_FIT);

            Assert.IsTrue(pipe.CanParcelFit(parcel));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParcelArgumentException()
        {
                Parcel parcel = ParcelLineHelper.GetParcelFromCommaStrInput(PARCEL_PIPE_ARG_EXCEPTION);
                Pipe pipe = ParcelLineHelper.GetPipeFromCommaStrInput(PARCEL_PIPE_ARG_EXCEPTION);
                pipe.CanParcelFit(parcel);
        }


    }
}
