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
        public delegate void PrintMultipleEntities(List<T> entities);
        public static void Add(List <T> entities, T entity)
        {
            entities.Add(entity);
        }
        public static void Remove(List<T> entities, T entity)
        {
            entities.Remove(entity);
        }
        public static void PrintEntity(T entity)
        {
            Console.WriteLine(entity.PrintInfo());
        }
        public static void PrintEntities(List<T> entities, PrintMultipleEntities printMultiple)
        {
            printMultiple(entities);
        }
  
        public static T ReturnEntity(List<T> entities)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter ID: ");
                    int index = Console.ReadLine().Parsing();
                    T? entity = entities.SingleOrDefault(entity => entity.Id == index);
                    if (entity != null)
                    {
                        return entity;
                    }
                    else
                    {
                        throw new ExceptionService("User entered invalid message type");
                    }
                }
                catch (ExceptionService)
                {
                    Console.WriteLine("Nothing found");
                    continue;
                }
            }
        }

        public static T? AssignEntity(int id, List<T> entities)
        {
           return entities.SingleOrDefault(entity => entity.Id == id);
        }
    }
}
