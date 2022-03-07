using Core.Model.Base;
using System;

namespace Core.Model
{
    public class GeneralSettings : IEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeToKeepData { get; set; }
    }
}
