using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using NameSorter.Interfaces;
using System.Collections.Generic;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Test_NameBuilderConstruct() {
            var feed = new List<string>(){
                "Orson Milka Iddins",
                "Erna Dorey Battelle",
                "Flori Chaunce Franzel",
                "Odetta Sue Kaspar",
                "Roy Ketti Kopfen",
                "Madel Bordie Mapplebeck",
                "Selle Bellison",
                "Iin Bellison",
                "Leonerd Adda Mitchell Monaghan",
                "Debra Micheli",
                "Hailey Avie Annakin"};

            IDataSubstringList expect = new DataSubstringList(new List<DataSubstring>() {
                new DataSubstring(0, "Orson Milka Iddins"),
                new DataSubstring(1, "Erna Dorey Battelle"),
                new DataSubstring(2, "Flori Chaunce Franzel"),
                new DataSubstring(3, "Odetta Sue Kaspar"),
                new DataSubstring(4, "Roy Ketti Kopfen"),
                new DataSubstring(5, "Madel Bordie Mapplebeck"),
                new DataSubstring(6, "Selle Bellison"),
                new DataSubstring(7, "Iin Bellison"),
                new DataSubstring(8, "Leonerd Adda Mitchell Monaghan"),
                new DataSubstring(9, "Debra Micheli"),
                new DataSubstring(10, "Hailey Avie Annakin")
            });

            INameListBuilder result = new NameListBuilder(feed);
            Assert.AreEqual(expect.GetType(), result.GetList().GetType());
            Assert.AreEqual(expect.GetList().GetType(), result.GetList().GetList().GetType());
            Assert.AreEqual(expect.GetList().Count, result.GetList().GetList().Count);
            for (int i = 0; i < expect.GetList().Count; i++) {
                Assert.AreEqual(expect.GetNameAtIndex(i), result.GetList().GetNameAtIndex(i));
            }
        }

        [TestMethod]
        public void Test_Order() {
            var feed = new List<string>(){
                "Orson Milka Iddins",
                "Erna Dorey Battelle",
                "Flori Chaunce Franzel",
                "Odetta Sue Kaspar",
                "Roy Ketti Kopfen",
                "Madel Bordie Mapplebeck",
                "Selle Bellison",
                "Iin Leo Bellison",
                "Iin Bellison",
                "Leonerd Adda Mitchell Monaghan",
                "Debra Micheli",
                "Hailey Avie Annakin"};

            IDataSubstringList expect = new DataSubstringList(new List<DataSubstring>() {
                new DataSubstring(0, "Hailey Avie Annakin"),
                new DataSubstring(1, "Erna Dorey Battelle"),
                new DataSubstring(2, "Iin Bellison"),
                new DataSubstring(3, "Iin Leo Bellison"),
                new DataSubstring(4, "Selle Bellison"),
                new DataSubstring(5, "Flori Chaunce Franzel"),
                new DataSubstring(6, "Orson Milka Iddins"),
                new DataSubstring(7, "Odetta Sue Kaspar"),
                new DataSubstring(8, "Roy Ketti Kopfen"),
                new DataSubstring(9, "Madel Bordie Mapplebeck"),
                new DataSubstring(10, "Debra Micheli"),
                new DataSubstring(11, "Leonerd Adda Mitchell Monaghan")
            });

            INameListBuilder result = new NameListBuilder(feed);
            result.Order();
            for (int i = 0; i < expect.GetList().Count; i++) {
                Assert.AreEqual(expect.GetNameAtIndex(i), result.GetList().GetNameAtIndex(i));
            }
        }
    }
}
