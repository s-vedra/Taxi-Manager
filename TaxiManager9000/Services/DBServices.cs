using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class  DBServices<T> where T : BaseEntity
    {
        public static void Add(List <T> entities, T entity)
        {
            entities.Add(entity);
        }
        public static void Remove(List<T> entities, T entity)
        {
            entities.Remove(entity);
        }
        public static void PrintEntities(List<T> entities)
        {
            entities.ForEach(entity => Console.WriteLine(entity.PrintInfo(), HelperMethods.ChangeColor(ConsoleColor.White)));
        }
  
        public static T ReturnEntity(int index, List<T> entities)
        {
            foreach (T item in entities)
            {
                if (item.Id == index)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
