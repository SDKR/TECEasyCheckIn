using System;

namespace Core.Model.Base
{
    public abstract class BaseEntity : IEntity, IEditableEntity, IDeletableEntity
    {
        public Guid Id { get ; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public Guid? ModifiedById { get; set; }
        public Guid? DeletedById { get; set; }

    }
}
