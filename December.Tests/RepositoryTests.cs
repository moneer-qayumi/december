using December.Data;
using December.Interfaces;
using December.Models;
using December.Services;

namespace December.Tests
{
    public class RepositoryTests
    {
        private readonly IHelpers _services;
        private readonly IRepository _repository;

        public RepositoryTests()
        {
            _services = new Helpers();
            _repository = new Repository(_services);
        }
        [Fact]
        public void ReadFile_ShouldReturnContactList() //I want to test if the ReadFile function returns the list if the path is OK
        {
            // Arrange
            _repository.ContactsList = new List<Contact>()
            {
                new Contact(){ FirstName = "fname1", LastName = "lname1", Email = "email1", Address = "address1", PhoneNumber = 701234},
                new Contact(){ FirstName = "fname2", LastName = "lname2", Email = "email2", Address = "address2", PhoneNumber = 901543}
            };
            _repository.SaveContactList(@"..\..\..\..\ContactTests.json");

            // Act
            var actualContactList = _repository.ReadFile(@"..\..\..\..\ContactTests.json");

            // Assert
            Assert.NotNull(actualContactList);
            Assert.Equal(2, actualContactList.Count);

            Assert.Equal(_repository.ContactsList[0].FirstName, actualContactList[0].FirstName);
            Assert.Equal(_repository.ContactsList[0].LastName, actualContactList[0].LastName);
        }

        [Fact]
        public void ReadFile_ShouldReturnEmptyList_IfThePathDoesNotExist() // I want to test if the ReadFile function returns an empty list if the json file does not exist
        {
            // Arrange
            _repository.ContactsList = new List<Contact>()
            {
                new Contact(){ FirstName = "fname1", LastName = "lname1", Email = "email1", Address = "address1", PhoneNumber = 701234}
            };
            _repository.SaveContactList(@"..\..\..\..\ContactTests.json");

            // Act
            var actualContactList = _repository.ReadFile(@"..\..\..\..\WrongPath.json");

            // Assert
            Assert.Empty(actualContactList);
            Assert.NotNull(actualContactList);
            Assert.Equal(0, actualContactList.Count);

        }
    }
}