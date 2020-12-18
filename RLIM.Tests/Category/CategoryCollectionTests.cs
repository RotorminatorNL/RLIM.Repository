using Microsoft.VisualStudio.TestTools.UnitTesting;
using RLIM.BusinessLogic.MessageToUI;
using RLIM.ContractLayer;
using RLIM.Tests;
using System.Collections.Generic;

namespace RLIM.BusinessLogic.Tests
{
    [TestClass()]
    public class CategoryCollectionTests
    {
        [TestMethod()]
        public void Create_CategoryIsValid_ShouldReturnSuccessMessage()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());

            IAdmin expected = new Success("Category","Create");

            // Act
            IAdmin actual = categoryCollection.Create("Test Category");

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod()]
        public void Create_CategoryIsInvalid_ShouldReturnErrorMessage()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());

            IAdmin expected = new Error("Category", "Create");

            // Act
            IAdmin actual = categoryCollection.Create("");

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod()]
        public void Create_TwoEqualCategories_ShouldReturnAlreadyExistingMessage()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());
            categoryCollection.Create("Test Category");

            IAdmin expected = new AlreadyExisting("Category");

            // Act
            IAdmin actual = categoryCollection.Create("Test Category");

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod()]
        public void Get_CategoryWithGivenIDExists_ShouldReturnCategoryDTOCorrespondingToGivenID()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());

            categoryCollection.Create("Test Category");
            categoryCollection.Create("Second Test Category");

            Category expected = new Category(new CategoryDTO { ID = 2, Name = "Second Test Category" });

            // Act
            Category actual = categoryCollection.Get(2);

            // Assert
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod()]
        public void Get_CategoryWithGivenIDDoesNotExists_ShouldReturnStandardEmptyCategoryDTO()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());

            categoryCollection.Create("Test Category");
            categoryCollection.Create("Second Test Category");

            Category expected = new Category(new CategoryDTO { ID = 0, Name = "No Category" });

            // Act
            Category actual = categoryCollection.Get(3);

            // Assert
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod()]
        public void GetAll_CreatedTwoCategories_ShouldReturnListOfCreatedCategories()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());

            CategoryDTO categoryDTO1 = new CategoryDTO { ID = 1, Name = "Test Category" };
            CategoryDTO categoryDTO2 = new CategoryDTO { ID = 2, Name = "Second Test Category" };

            categoryCollection.Create(categoryDTO1.Name);
            categoryCollection.Create(categoryDTO2.Name);

            List<Category> expected = new List<Category>
            {
                new Category(categoryDTO1),
                new Category(categoryDTO2)
            };

            // Act
            List<Category> actual = categoryCollection.GetAll();

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].ID, actual[0].ID);
            Assert.AreEqual(expected[0].Name, actual[0].Name);
            Assert.AreEqual(expected[1].ID, actual[1].ID);
            Assert.AreEqual(expected[1].Name, actual[1].Name);
        }

        [TestMethod()]
        public void Delete_CategoryWithGivenIDDoesExist_ShouldReturnSuccessMessage()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());
            categoryCollection.Create("Test Category");

            IAdmin expected = new Success("Category", "Delete");

            // Act
            IAdmin actual = categoryCollection.Delete(1);

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }

        [TestMethod()]
        public void Delete_CategoryWithGivenIDDoesNotExist_ShouldReturnErrorMessage()
        {
            // Arrange
            CategoryCollection categoryCollection = new CategoryCollection(new TestCategoryDAL());
            categoryCollection.Create("Test Category");

            IAdmin expected = new Error("Category", "Delete");

            // Act
            IAdmin actual = categoryCollection.Delete(2);

            // Assert
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Title, actual.Title);
        }
    }
}