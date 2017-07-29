using System;

namespace LG.Test.Domain.Entities
{
    public class EntityBase : IDisposable
    {
        public virtual int Id { get; set; }

        public void Dispose()
        {
            
        }
    }
}
