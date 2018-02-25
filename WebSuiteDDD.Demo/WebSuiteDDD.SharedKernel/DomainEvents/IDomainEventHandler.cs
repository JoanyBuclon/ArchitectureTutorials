using System;

namespace WebSuiteDDD.SharedKernel.DomainEvents
{
    public interface IDomainEventHandler
    {
        void Handle(EventArgs eventArgs);
    }
}
