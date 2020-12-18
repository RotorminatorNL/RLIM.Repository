using Microsoft.VisualStudio.TestTools.UnitTesting;
using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.Tests;

namespace RLIM.BusinessLogic.Tests
{
    [TestClass()]
    public class CategoryTests
    {
        [TestMethod()]
        public void SetName_RenamingCateogryToValidName_ShouldSetNameOfCategory()
        {
            // Arrange
            Category category = new Category(new CategoryDTO { ID = 1, Name = "Test" });

            string expected = "Test Category";

            // Act
            category.SetName("Test Category");

            // Assert
            Assert.AreEqual(expected, category.Name);
        }

        [TestMethod()]
        public void SetName_RenamingCateogryToInvalidName_NameShouldRemainTheSame()
        {
            // Arrange
            Category category = new Category(new CategoryDTO { ID = 1, Name = "Test" });

            string expected = "Test";

            // Act
            category.SetName("");

            // Assert
            Assert.AreEqual(expected, category.Name);
        }

        [TestMethod()]
        public void Update_RenamingCateogryToUniqueName_ShouldReturnSuccessMessage()
        {
            // Arrange
            TestCategoryDAL testCategoryDAL = new TestCategoryDAL();

            CategoryCollection categoryCollection = new CategoryCollection(testCategoryDAL);
            categoryCollection.Create("Example Category");
            categoryCollection.Create("Test");

            Category category = categoryCollection.Get(2);
            category.SetName("Test Category");

            IAdmin expected = new Success("Category", "Update");

            // Act
            IAdmin actual = category.Update(testCategoryDAL, testCategoryDAL);

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod()]
        public void Update_RenamingCateogryToExistingName_ShouldReturnAlreadyExistingMessage()
        {
            // Arrange
            TestCategoryDAL testCategoryDAL = new TestCategoryDAL();

            CategoryCollection categoryCollection = new CategoryCollection(testCategoryDAL);
            categoryCollection.Create("Example Category");
            categoryCollection.Create("Test");

            Category category = categoryCollection.Get(2);
            category.SetName("Example Category");

            IAdmin expected = new AlreadyExisting("Category");

            // Act
            IAdmin actual = category.Update(testCategoryDAL, testCategoryDAL);

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }
    }
}