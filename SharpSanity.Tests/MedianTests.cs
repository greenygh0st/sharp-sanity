﻿using System;
using System.Collections.Generic;
using Xunit;
using SharpSanity;

namespace SharpSanity.Tests
{
    public class MedianTests
    {
        [Fact]
        public void MedIsThree()
        {
            List<int> numRange = new List<int> { 1, 3, 5 };
            int med = (int)Math.Round(SaneMath.Median(numRange));
            Assert.Equal(3, med);
        }

        [Fact]
        public void MedIsFive()
        {
            List<int> numRange = new List<int> { 1, 5, 7 };
            int med = (int)Math.Round(SaneMath.Median(numRange));
            Assert.Equal(5, med);
        }

        [Fact]
        public void MedIsFour()
        {
            List<int> numRange = new List<int> { 1, 4, 6 };
            int med = (int)Math.Round(SaneMath.Median(numRange));
            Assert.Equal(4, med);
        }

        [Fact]
        public void MedIsFourishDoubleOdd()
        {
            List<double> numRange = new List<double> { 1.3, 4.2, 6 };
            double med = SaneMath.Median(numRange);
            Assert.Equal(4.2, med);
        }

        [Fact]
        public void MedIsFourishDoubleEven()
        {
            List<double> numRange = new List<double> { 1.3, 4.2, 6, 9 };
            double med = SaneMath.Median(numRange);
            Assert.Equal(5.1, med);
        }

        [Fact]
        public void MedIsFourishDoubleOddArray()
        {
            double[] numRange = new double[] { 1.3, 4.2, 6 };
            double med = SaneMath.Median(numRange);
            Assert.Equal(4.2, med);
        }

        [Fact]
        public void MedIsFourishDoubleEvenArray()
        {
            double[] numRange = new double[] { 1.3, 4.2, 6, 9 };
            double med = SaneMath.Median(numRange);
            Assert.Equal(5.1, med);
        }

        [Fact]
        public void MedDecimalArrayEven()
        {
            int[] numRange = new int[] { 1, 2, 3, 4 };
            decimal med = SaneMath.Median(numRange);
            Assert.Equal(2.5M, med);
        }

        [Fact]
        public void MedDecimalArrayOdd()
        {
            int[] numRange = new int[] { 1, 2, 3 };
            decimal med = SaneMath.Median(numRange);
            Assert.Equal(2, med);
        }
    }
}


