namespace TestWebService
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestWebService.APIUtils;

    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            string endPointName = "users";
            int expectedCode = 200;

            // Act
            var actualResult = APICalls.ExecuteGetAndGetStatusCode(endPointName);

            // Assert
            Assert.AreEqual(expectedCode, actualResult, "Status code is not the same");
        }

        [TestMethod]
        public void TestGetHeader()
        {
            // Arrange
            string endPointName = "users";
            string expectedHeader = "application/json; charset=utf-8";

            // Act
            var actualResult = APICalls.ExecuteGetAndGetContentTypeHeader(endPointName);

            // Assert
            Assert.AreEqual(expectedHeader, actualResult, "Content-type header is not the same");
        }

        [TestMethod]
        public void TestGetBody()
        {
            // Arrange
            string endPointName = "users";
            int expectedUsersCount = 10;

            // Act
            var actualResult = APICalls.ExecuteGetAndGetUsersCount(endPointName);

            // Assert
            Assert.AreEqual(expectedUsersCount, actualResult, "Users count is not the same");
        }
    }
}

