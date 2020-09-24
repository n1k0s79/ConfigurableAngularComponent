using System;
using System.Linq;
using System.Reflection;

namespace QualcoApp.Models
{
    public class GenericEntityDescriptor
    {
        public string TypeName { get; set; }
        public string Title { get; set; }
        public GenericEntityField[] Fields { get; set; }

        public string[] EntityActions { get; set; }
        public string[] ListActions { get; set; }

        public static GenericEntityDescriptor FromEntity(GenericEntity entity)
        {
            var fields = entity
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(pinfo => new GenericEntityField() { Name = pinfo.Name, Value = pinfo.GetValue(entity)?.ToString() })
                .ToArray();
            return new GenericEntityDescriptor() 
            { 
                Fields = fields, 
                TypeName = entity.GetType().Name, 
                Title = entity.ToSummary().Description,
                EntityActions = GetEntityActions(entity.GetType()),
                ListActions = GetListActions(entity.GetType())
            };
        }

        private static string[] GetEntityActions(Type type)
        {
            var availableActionsAttribute = type.GetCustomAttribute(typeof(EntityActionsAttribute));
            return availableActionsAttribute != null
                ? ((EntityActionsAttribute)availableActionsAttribute).AvailableActions.Split(',').Select(t => t.Trim()).ToArray()
                : new string[] { };
        }

        internal static string[] GetListActions(Type type)
        {
            var availableActionsAttribute = type.GetCustomAttribute(typeof(ListActionsAttribute));
            return availableActionsAttribute != null
                ? ((ListActionsAttribute)availableActionsAttribute).AvailableActions.Split(',').Select(t => t.Trim()).ToArray()
                : new string[] { };
        }

        public bool HasFieldWithValue(string fieldName, string fieldValue) => Fields.Any(f => f.Name == fieldName && f.Value == fieldValue);
    }
}
