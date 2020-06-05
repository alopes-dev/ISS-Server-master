using System;

namespace CRUDMaker.CrudCreator.Models
{
    public class IsIdentityAttribute : Attribute
    {
        public bool IsIdentity { get; set; } = true;
        public IsIdentityAttribute() { }
    }
}