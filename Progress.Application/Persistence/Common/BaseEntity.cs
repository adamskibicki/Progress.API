﻿namespace Progress.Application.Persistence.Common
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
