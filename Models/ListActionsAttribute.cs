using System;
namespace QualcoApp.Models
{
    public class ListActionsAttribute : Attribute
    {
        public readonly string AvailableActions;
        public ListActionsAttribute(string actions) => AvailableActions = actions;
    }
}
