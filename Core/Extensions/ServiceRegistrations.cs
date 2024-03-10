using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly,
            Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            //Reflection ile gelen sınıfın typlerını gez. Gezdiğimiz sınıfın type'ı, gönderilen type'dan türüyorsa
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            //Typeları gez.
            foreach (Type? item in types)
            {
                //Bu sınıf yaşam döngüsüne eklenmediyse yani null ise
                if (addWithLifeCycle == null)
                {
                    //Type'dan gelen item'ı servise scoped olarak ekle.
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }

        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, Assembly assembly)
        {
            //Reflection ile gelen sınıfın typlerını gez. Gezdiğimiz sınıfın type'ı class olacak, abstract(soyut) class olmayacak.
            var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
            //Typeları gez.
            foreach (Type? type in types)
            {
                //interfaceleri bul.
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, type);
                }
            }
            return services;
        }
    }
}
