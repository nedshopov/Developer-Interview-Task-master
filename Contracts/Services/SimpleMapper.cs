using System;
using System.Linq;
using System.Reflection;

namespace Contracts.Services
{
   /// <summary>
   /// A very basic implementation of an object mapping class. No validation, no type checking etc..
   /// </summary>
   public static class SimpleMapper
   {
      public static void Map(object source, object target)
      {
         Type T1 = source.GetType();
         Type T2 = target.GetType();

         PropertyInfo[] sourceProprties = T1.GetProperties(BindingFlags.Instance | BindingFlags.Public);
         PropertyInfo[] targetProperties = T2.GetProperties(BindingFlags.Instance | BindingFlags.Public);

         foreach(var sourceProp in sourceProprties)
         {
            object osourceVal = sourceProp.GetValue(source, null);
            PropertyInfo targetProperty = targetProperties.FirstOrDefault(x => x.Name == sourceProp.Name);
            if(targetProperty != null)
            {
               targetProperty.SetValue(target, osourceVal);
            }
         }
      }
   }
}
