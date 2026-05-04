using System;

namespace GDPR.Abstractions
{
    /// <summary>
    /// Marks a property or field as containing personal data subject to GDPR.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class PersonalDataAttribute : Attribute
    {
    }
}
