using System;

namespace GDPR.Abstractions
{
    /// <summary>
    /// Marks a property or field as containing sensitive data that requires extra protection under GDPR.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class SensitiveDataAttribute : Attribute
    {
    }
}
