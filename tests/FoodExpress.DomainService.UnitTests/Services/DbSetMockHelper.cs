using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace FoodExpress.DomainService.UnitTests.Services
{
    public static class DbSetMockHelper
    {
        public static Mock<DbSet<T>> CreateMockDbSet<T>(List<T> data) where T : class
        {
            var queryableData = data.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryableData.GetEnumerator());

            // Simulate asynchronous add by updating the underlying list.
            mockSet.Setup(s => s.AddAsync(It.IsAny<T>(), It.IsAny<CancellationToken>()))
                .Returns((T entity, CancellationToken cancellationToken) =>
                {
                    data.Add(entity);
                    // Return a dummy EntityEntry<T>. In real tests you may want to create a more complete fake.
                    var entry = Mock.Of<EntityEntry<T>>(e => e.Entity == entity);
                    return new ValueTask<EntityEntry<T>>(Task.FromResult(entry));
                });

            return mockSet;
        }
    }
}
