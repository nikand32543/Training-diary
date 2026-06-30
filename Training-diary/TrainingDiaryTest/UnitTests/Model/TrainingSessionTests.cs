using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_diary.Model;

namespace TrainingDiaryTest.UnitTests.Model
{
    public class TrainingSessionTests
    {
        [Fact]
        public void TrainingSession_WithValidData_ShouldBeValid()
        {
            // Arrange — Создаем объект тренировки с полностью корректными значениями
            var session = new TrainingSession
            {
                Name = "Утренняя пробежка",       // Обязательное поле из EFmodel
                ExerciseType = "Бег",             // Обязательное поле
                DurationMinutes = 45,             // Корректная длительность
                CaloriesBurned = 400,
                Date = DateTime.Now,
                AthleteId = 1                     // Привязка к ID атлета
            };

            var context = new ValidationContext(session);
            var result = new List<ValidationResult>();

            // Act — Запускаем встроенный валидатор .NET
            var isValid = Validator.TryValidateObject(session, context, result, true);

            // Assert — Проверяем, что ошибок нет
            Assert.True(isValid);
            Assert.Empty(result);
        }

        [Fact]
        public void TrainingSession_WithEmptyExerciseType_ShouldBeInvalid()
        {
            // Arrange — Специально оставляем тип упражнения пустым
            var session = new TrainingSession
            {
                Name = "Силовая тренировка",
                ExerciseType = "",                
                DurationMinutes = 60,
                CaloriesBurned = 300,
                Date = DateTime.Now,
                AthleteId = 1
            };

            var context = new ValidationContext(session);
            var results = new List<ValidationResult>();

            // Act — Валидируем объект
            var isValid = Validator.TryValidateObject(session, context, results, true);

            // Assert — Ожидаем, что валидация провалилась
            Assert.False(isValid);

            // Проверяем, что ошибка указывает именно на незаполненное поле ExerciseType
            Assert.Contains(results, r => r.MemberNames.Contains("ExerciseType"));
        }
    }
}
