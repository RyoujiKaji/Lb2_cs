using Lb2;
namespace Lb2.Tests
{
    using Xunit;

    public class PeopleTests
    {
        [Fact]
        public void Add_PersonToStack_ShouldIncreaseStackCount()
        {
            // Arrange
            var people = new People();
            var person = new Person { name = "John", surname = "Doe", Gender = "Male", 
                Year_of_birth = 1990, City = "New York", Country = "USA", Height = 180.5 };

            // Act
            people.Add(person);

            // Assert
            Assert.Single(people.GenerateData().Rows);
        }

        [Fact]
        public void Remove_PersonFromStack_ShouldDecreaseStackCount()
        {
            // Arrange
            var people = new People();
            var person1 = new Person { name = "John", surname = "Doe", Gender = "Male",
                Year_of_birth = 1990, City = "New York", Country = "USA", Height = 180.5 };
            var person2 = new Person { name = "Jane", surname = "Doe", Gender = "Female", 
                Year_of_birth = 1992, City = "Los Angeles", Country = "USA", Height = 165.0 };
            people.Add(person1);
            people.Add(person2);

            // Act
            people.Remove(0); // Удаляем первый элемент в стеке

            // Assert
            Assert.Equal("John", people.GenerateData().Rows[0][1].ToString());
        }

        [Fact]
        public void Remove_FromEmptyStack_ShouldNotThrowException()
        {
            // Arrange
            var people = new People();

            // Act & Assert
            var exception = Record.Exception(() => people.Remove(0));
            Assert.Null(exception);
        }

        [Fact]
        public void Remove_InvalidId_ShouldNotRemoveAnyPerson()
        {
            // Arrange
            var people = new People();
            var person = new Person { name = "John", surname = "Doe", Gender = "Male", 
                Year_of_birth = 1990, City = "New York", Country = "USA", Height = 180.5 };
            people.Add(person);

            // Act
            people.Remove(10); // Пытаемся удалить несуществующий элемент

            // Assert
            Assert.Single(people.GenerateData().Rows);
        }

        [Fact]
        public void GenerateData_EmptyStack_ShouldReturnEmptyDataTable()
        {
            // Arrange
            var people = new People();

            // Act
            var dataTable = people.GenerateData();

            // Assert
            Assert.Empty(dataTable.Rows);
        }
    }
}