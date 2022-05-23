using Models;

namespace Services
{
    public static class DBServices<T> where T : BaseEntity
    {
        public delegate void PrintMultipleEntities(List<T> entities);
        public static void Add(List<T> entities, T entity)
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

        public static T ReturnEntityById(int? index ,List<T> entities)
        {
            T? entity = entities.SingleOrDefault(entity => entity.Id == index);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new ExceptionService("No user found");
            }
        }

        public static T? AssignEntity(int id, List<T> entities)
        {
            return entities.SingleOrDefault(entity => entity.Id == id);
        }
    }
}
