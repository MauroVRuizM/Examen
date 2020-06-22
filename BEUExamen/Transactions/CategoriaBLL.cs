using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUExamen.Transactions
{
    public class CategoriaBLL
    {
        public static Categoria Get(int? id)
        {
            Entities db = new Entities();
            return db.Categorias.Find(id);
        }

        public static void Create(Categoria c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Categorias.Add(c);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Update(Categoria categoria)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Categorias.Attach(categoria);
                        db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Categoria categoria = db.Categorias.Find(id);
                        db.Entry(categoria).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Categoria> List()
        {
            Entities db = new Entities();
            return db.Categorias.ToList();
        }
    }
}
