using System;
namespace QualcoApp.Models
{
    public class EntityActionsAttribute : Attribute
    {
        public readonly string AvailableActions;
        public EntityActionsAttribute(string actions) => AvailableActions = actions;
    }
}
