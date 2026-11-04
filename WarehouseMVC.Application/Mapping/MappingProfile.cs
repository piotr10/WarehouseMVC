using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace WarehouseMVC.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            /* Definicja metody ApplyMappingsFromAssembly:
            Ze wszytkich typów odczytanych w naszej aplikacji (GetExportedTypes) chcemy wziąć wszystkie interfejsy (GetInterfaces)
            generyczne odpowiadające interfejsowi IMapFrom i kiedy znajdziemy te typy to przejdziemy po nich pętlą foreach 
            i wywołamy na nich metodę "Mapping" (GetMethod("Mapping"))*/
            var types = assembly.GetExportedTypes()
                    .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                    .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

    