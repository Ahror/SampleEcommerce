using Autofac.Extras.Moq;
using Moq;
using System;

namespace Cart.UnitTests
{
    public abstract class BaseAutoMockedTest<T> : IDisposable
     where T : class
    {
        protected T Controller => Mocker.Create<T>();

        protected AutoMock Mocker { get; }

        protected BaseAutoMockedTest()
        {
            Mocker = AutoMock.GetLoose();
        }

        protected Mock<TDepend> GetMock<TDepend>()
            where TDepend : class
        {
            return Mocker.Mock<TDepend>();
        }

        public void Dispose()
        {
            Mocker?.Dispose();
        }
    }
}
