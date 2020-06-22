using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUExamen.Transactions
{
    public class LibroBLL
    {
        public static Libro Get(int? id)
        {
            Entities db = new Entities();
            return db.Libroes.Find(id);
        }

        public static void Create(Libro l)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libroes.Add(l);
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

        public static void Update(Libro libro)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Libroes.Attach(libro);
                        db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
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
                        Libro libro = db.Libroes.Find(id);
                        db.Entry(libro).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Libro> List()
        {
            Entities db = new Entities();
            return db.Libroes.ToList();
        }
    }
}
