using System;
using System.Collections.Generic;
using NUnit.Framework;
using TextMatch.Models;
using TextMatch.Services;

namespace TextMach.Test
{
    [TestFixture]
    public class MatchServiceTests
    {
        private readonly MatchService _sut;

        public MatchServiceTests()
        {
            _sut = new MatchService();
        }
      
        [Test]
        public void AllIndicesOf_ShouldReturnListOfIndices_EqualTo_ExpectedResult_WhenTextStringIsNotNullOrEmpty()
        {
            //Arrange
            var obj = new TextString
            {
                Text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea",
                SubText = "Polly"
            };
            var expectedResult = new List<int>
            {
                0,
                25,
                50
            };

            //Act
            var result = _sut.AllIndicesOf(obj);
            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result);
        }
        
        [Test]
        public void AllIndicesOf_ShouldThrowArgumentNullException_WhenSubTextIsNullOrEmpty()
        {
            //Arrange
            var obj = new TextString
            {
                Text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea",
                SubText = null
            };
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _sut.AllIndicesOf(obj));
        }
    }
}