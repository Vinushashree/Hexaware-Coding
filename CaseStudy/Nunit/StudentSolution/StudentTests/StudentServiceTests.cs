using Xunit;
using Moq;
using StudentDAL.Domain;
using StudentDAL.Repository;
using StudentDAL.BusinessLogic;
using System.Collections.Generic;

namespace StudentTests
{
    public class StudentServiceTests
    {
        [Fact]
        public void GetAllStudents_ReturnsCorrectCount()
        {
            // Arrange
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(r => r.GetAll()).Returns(new List<Student>
            {
                new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" },
                new Student { RollNo = 2, Name = "Bob", Email = "bob@example.com" }
            });

            var service = new StudentService(mockRepo.Object);

            // Act
            var students = service.GetAllStudents();

            // Assert
            Assert.Equal(2, students.Count);
        }

        [Fact]
        public void AddStudent_CallsRepositoryAdd()
        {
            // Arrange
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var newStudent = new Student { RollNo = 3, Name = "Charlie", Email = "charlie@example.com" };

            // Act
            service.AddStudent(newStudent);

            // Assert
            mockRepo.Verify(r => r.Add(It.Is<Student>(s => s.RollNo == 3 && s.Name == "Charlie")), Times.Once);
        }

        [Fact]
        public void DeleteStudent_CallsRepositoryDelete()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);

            // Act
            service.DeleteStudent(1);

            // Assert
            mockRepo.Verify(r => r.Delete(1), Times.Once);
        }

        [Fact]
        public void UpdateStudent_CallsRepositoryUpdate()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var updatedStudent = new Student { RollNo = 2, Name = "Updated", Email = "updated@example.com" };

            // Act
            service.UpdateStudent(updatedStudent);

            // Assert
            mockRepo.Verify(r => r.Update(It.Is<Student>(s => s.Name == "Updated")), Times.Once);
        }
    }
}
