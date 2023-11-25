using Cinema.Domain.Primitives;
using System.Reflection;

namespace Cinema.Domain.ProjectReferences.Test
{
    public class DomainReference
    {
        [Fact]
        public void DomainsShouldNotReferenceAnyOtherAssemblyProject()
        {
            Assembly.GetAssembly(typeof(IDomainEvent));
        }
    }
}