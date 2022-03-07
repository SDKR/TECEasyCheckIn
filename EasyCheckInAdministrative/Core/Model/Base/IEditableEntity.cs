using System;

namespace Core.Model.Base
{
    public interface IEditableEntity
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset? ModifiedOn { get; set; }
        Guid? ModifiedById { get; set; }
    }
}
