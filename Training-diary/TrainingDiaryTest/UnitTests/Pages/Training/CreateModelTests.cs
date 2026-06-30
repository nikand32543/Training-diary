using System;
using System.Linq;
using System.Threading.Tasks;
using Training_diary.Data;
using Training_diary.Pages.Training;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TrainingDiaryTest.UnitTests.Pages.Training
{
    public class TestCreateModel : CreateModel
    {
        public TestCreateModel(ApplicationDbContext context) : base(context) { }

        public override bool TryValidateModel(object model, string prefix)
        {
            return false; // Имитируем, что валидация не прошла
        }
    }

    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task OnPostAsync_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new TestCreateModel(context);

            pageModel.Training = new Training_diary.Model.TrainingSession();

            // Act 
            var result = await pageModel.OnPostAsync();

            // Assert
            result.Should().BeOfType<PageResult>();
            context.TrainingSessions.Count().Should().Be(0);
        }
    }
}