using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using WebApiStudent_Net_Core2.Interfaces;

namespace WebApiStudent_Net_Core2.Models.DataManager.Extensions
{
    public static class EntityExtensions
    {

        private static int DataBaseZeroValue = 0;
        public static bool IsObjectNull(this IEntity entity)
        {
            return entity == null;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }

        //public static bool IsObjectNullGeneric(this object obj)
        //{
        //    return (obj == null);
        //}

        //public static bool IsEmptyObjectGeneric(this object obj)
        //{
        //    PropertyInfo FirstObjectProperty = obj.GetType().GetProperties()[0];

        //    if (typeof(int) == FirstObjectProperty.PropertyType)
        //    {
        //        dynamic Value;
        //        try
        //        {
        //            Value = FirstObjectProperty.GetValue(obj);
        //            if (DataBaseZeroValue != Value)
        //            {
        //                return (false);
        //            }
        //        }
        //        catch (Exception Error)
        //        {

        //        }
        //    }
        //    return (true);
        //}

        public static bool IsObjectNullGeneric<T>(this T obj)
        {
            return (obj == null);
        }

        public static bool IsEmptyObjectGeneric<T>(this T obj)
        {
            PropertyInfo FirstObjectProperty = obj.GetType().GetProperties()[0];

            if (typeof(int) == FirstObjectProperty.PropertyType)
            {
                dynamic Value;
                try
                {
                    Value = FirstObjectProperty.GetValue(obj);
                    if (DataBaseZeroValue != Value)
                    {
                        return (false);
                    }
                }
                catch (Exception Error)
                {

                }
            }
            return (true);
        }
    }
}
