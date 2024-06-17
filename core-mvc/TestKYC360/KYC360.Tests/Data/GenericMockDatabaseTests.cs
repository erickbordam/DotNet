using System;
using System.Collections.Concurrent;
using KYC360.Commons.Models;
using KYC360.Core.Data;
using KYC360.Core.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace KYC360.Tests.Data
{
    public class GenericMockDatabaseTests
    {
        private readonly Mock<ILogger<GenericMockDatabase<Entity, string>>> _mockLogger;
        private readonly ConcurrentDictionary<string, Entity> _mockDictionary;
        private readonly GenericMockDatabase<Entity, string> _database;

        public GenericMockDatabaseTests()
        {
            _mockLogger = new Mock<ILogger<GenericMockDatabase<Entity, string>>>();
            _mockDictionary = new ConcurrentDictionary<string, Entity>();
            _database = new GenericMockDatabase<Entity, string>(
                _mockLogger.Object, 
                maxRetryAttempts: 3, 
                initialDelay: 100, 
                maxDelay: 800, 
                backoffFactor: 2.0,
                _mockDictionary);
        }

        [Fact]
        public void AddItem_ShouldRetryAndEventuallySucceed()
        {
            // Arrange
            var entity = new Entity { Id = "test-entity" };
            var attempt = 0;

            // Simulate failures for the first two attempts and success on the third
            Func<bool> tryAdd = () =>
            {
                attempt++;
                if (attempt < 3)
                {
                    return false; // Simulate failure
                }
                else
                {
                    _mockDictionary.TryAdd(entity.Id, entity);
                    return true; // Simulate success
                }
            };

            // Override the method to use our custom logic
            bool CustomTryAdd(string key, Entity value)
            {
                return tryAdd();
            }

            // Use reflection to set the private _items field to use CustomTryAdd
            var field = typeof(GenericMockDatabase<Entity, string>).GetField("_items", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(_database, _mockDictionary);

            // Act
            var result = _database.AddItem(entity);

            // Assert
            Assert.True(result);
            Assert.Equal(3, attempt); // Ensure it took 3 attempts
            _mockLogger.Verify(l => l.LogInformation(It.IsAny<string>()), Times.AtLeastOnce);
            _mockLogger.Verify(l => l.LogWarning(It.IsAny<string>()), Times.Exactly(2));
            _mockLogger.Verify(l => l.LogError(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void AddItem_ShouldFailAfterMaxAttempts()
        {
            // Arrange
            var entity = new Entity { Id = "test-entity" };
            var attempt = 0;

            // Simulate failure for all attempts
            Func<bool> tryAdd = () =>
            {
                attempt++;
                return false;
            };

            // Override the method to use our custom logic
            bool CustomTryAdd(string key, Entity value)
            {
                return tryAdd();
            }

            // Use reflection to set the private _items field to use CustomTryAdd
            var field = typeof(GenericMockDatabase<Entity, string>).GetField("_items", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(_database, _mockDictionary);

            // Act
            var result = _database.AddItem(entity);

            // Assert
            Assert.False(result);
            Assert.Equal(3, attempt); // Ensure it took 3 attempts
            _mockLogger.Verify(l => l.LogInformation(It.IsAny<string>()), Times.Never);
            _mockLogger.Verify(l => l.LogWarning(It.IsAny<string>()), Times.Exactly(3));
            _mockLogger.Verify(l => l.LogError(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void UpdateItem_ShouldRetryAndEventuallySucceed()
        {
            // Arrange
            var entity = new Entity { Id = "test-entity" };
            _mockDictionary.TryAdd(entity.Id, entity);
            var attempt = 0;

            // Simulate failures for the first two attempts and success on the third
            Func<bool> tryUpdate = () =>
            {
                attempt++;
                return attempt >= 3;
            };

            // Override the method to use our custom logic
            bool CustomTryUpdate(string key, Entity newValue, Entity comparisonValue)
            {
                return tryUpdate();
            }

            // Use reflection to set the private _items field to use CustomTryUpdate
            var field = typeof(GenericMockDatabase<Entity, string>).GetField("_items", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(_database, _mockDictionary);

            // Act
            var result = _database.UpdateItem(entity.Id, entity);

            // Assert
            Assert.True(result);
            Assert.Equal(3, attempt); // Ensure it took 3 attempts
            _mockLogger.Verify(l => l.LogInformation(It.IsAny<string>()), Times.AtLeastOnce);
            _mockLogger.Verify(l => l.LogWarning(It.IsAny<string>()), Times.Exactly(2));
            _mockLogger.Verify(l => l.LogError(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void DeleteItem_ShouldRetryAndEventuallySucceed()
        {
            // Arrange
            var entity = new Entity { Id = "test-entity" };
            _mockDictionary.TryAdd(entity.Id, entity);
            var attempt = 0;

            // Simulate failures for the first two attempts and success on the third
            Func<bool> tryRemove = () =>
            {
                attempt++;
                return attempt >= 3;
            };

            // Override the method to use our custom logic
            bool CustomTryRemove(string key, out Entity value)
            {
                value = entity;
                return tryRemove();
            }

            // Use reflection to set the private _items field to use CustomTryRemove
            var field = typeof(GenericMockDatabase<Entity, string>).GetField("_items", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            field.SetValue(_database, _mockDictionary);

            // Act
            var result = _database.DeleteItem(entity.Id);

            // Assert
            Assert.True(result);
            Assert.Equal(3, attempt); // Ensure it took 3 attempts
            _mockLogger.Verify(l => l.LogInformation(It.IsAny<string>()), Times.AtLeastOnce);
            _mockLogger.Verify(l => l.LogWarning(It.IsAny<string>()), Times.Exactly(2));
            _mockLogger.Verify(l => l.LogError(It.IsAny<string>()), Times.Never);
        }
    }
}
