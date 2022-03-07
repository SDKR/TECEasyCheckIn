using System;

namespace Core.Model.Base
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTimeOffset? DeletedOn { get; set; }
        Guid? DeletedById { get; set; }

    }
}
