using System;

namespace ISS.Application.Attributes
{
    public class IsIdentityAttribute : Attribute
    {
        public bool IsIdentity { get; set; } = true;
        public IsIdentityAttribute() { }
    }
}
