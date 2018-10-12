﻿#region copyright

/*
MIT License

Copyright (c) 2018 Robin A. P.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#endregion

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Enums;
using Shared.Helpers;

// ReSharper disable All

namespace Shared_Tests.Tests
{
    /* TODO Finish */
    [TestClass]
    public sealed class AccuracyTests
    {
        [TestMethod]
        public void TestAccuracyOsu()
        {
            double acc = Accuracy.GetAccuracy(582, 12, 40, 1, 900, 121, PlayModes.Osu);
        }

        [TestMethod]
        public void TestAccuracyTaiko()
        {
            double acc = Accuracy.GetAccuracy(582, 12, 40, 1, 900, 121, PlayModes.Taiko);
        }

        [TestMethod]
        public void TestAccuracyCtb()
        {
            double acc = Accuracy.GetAccuracy(582, 12, 40, 1, 900, 121, PlayModes.Ctb);
        }

        [TestMethod]
        public void TestAccuracyMania()
        {
            double acc = Accuracy.GetAccuracy(582, 12, 40, 1, 900, 121, PlayModes.Mania);
        }
    }
}