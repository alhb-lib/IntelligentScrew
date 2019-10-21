using Z.EntityFramework.Plus;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace CSharp_prospect
{
    public class ContetxHelp
    {
        public List<T> GetListByConditions<T>(Expression<Func<T, bool>> where) where T : class
        {
            using (var db = new Model1())
            {
                return db.Set<T>().Where(where).ToList();
            }
        }

        /// <summary>
        /// 查询集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class
        {
            using (var db = new Model1())
            {
                return db.Set<T>().AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// 根据条件查询一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public T GetModelByConditions<T>(Expression<Func<T, bool>> where) where T : class
        {
            using (var db = new Model1())
            {
                T mod = db.Set<T>().SingleOrDefault(where);
                return mod;
            }
        }

        /// <summary>
        /// 根据无参数sql语句查询集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public List<T> GetListBySql<T>(string sql) where T : class
        {
            using (var db = new Model1())
            {
                return db.Database.SqlQuery<T>(sql).ToList();
            }
        }

        /// <summary>
        /// 根据sql语句查询集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public List<T> GetListBySql<T>(string sql, SqlParameter[] paras) where T : class
        {
            using (var db = new Model1())
            {
                return db.Database.SqlQuery<T>(sql, paras).ToList();
            }
        }

        /// <summary>
        /// 根据无参sql查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public T GetModelBySql<T>(string sql) where T : class
        {
            using (var db = new Model1())
            {
                return db.Database.SqlQuery<T>(sql).Cast<T>().First();
            }
        }

        /// <summary>
        /// 根据sql查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public T GetModelBySql<T>(string sql, SqlParameter[] paras) where T : class
        {
            using (var db = new Model1())
            {
                return db.Database.SqlQuery<T>(sql, paras).Cast<T>().First();
            }
        }

        /// <summary>
        /// 执行一条无参sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int ExecuteSqlCommand<T>(string sql) where T : class
        {
            using (var db = new Model1())
            {
                return db.Database.ExecuteSqlCommand(sql);
            }
        }

        /// <summary>
        /// 执行一条sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public int ExecuteSqlCommand<T>(string sql, SqlParameter[] paras) where T : class
        {
            using (var db = new Model1())
            {
                return db.Database.ExecuteSqlCommand(sql, paras);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add<T>(T model) where T : class
        {
            int res = 0;
            using (var db = new Model1())
            {
                db.Set<T>().Add(model);
                db.Configuration.ValidateOnSaveEnabled = false;
                res = db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            return res;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">对象集合</param>
        /// <returns></returns>
        public int AddRange<T>(IList<T> list) where T : class
        {
            int res = 0;
            using (var db = new Model1())
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    db.Set<T>().AddRange(list);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    res = db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;

                    transaction.Complete();
                }

            }
            return res;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update<T>(T model) where T : class
        {
            int res = 0;
            using (var db = new Model1())
            {
                if (db.Entry<T>(model).State == System.Data.Entity.EntityState.Detached)
                {
                    db.Set<T>().Attach(model);
                    db.Entry<T>(model).State = System.Data.Entity.EntityState.Modified;
                }
                db.Configuration.ValidateOnSaveEnabled = false;
                res = db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
            }
            return res;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <param name="updateModel">更新对象的内容</param>
        /// <returns></returns>
        public int UpdateRange<T>(Expression<Func<T, bool>> where, Expression<Func<T, T>> updateModel) where T : class
        {
            int res = 0;
            using (var db = new Model1())
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    db.Set<T>().Where(where).Update(updateModel);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    res = db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;

                    transaction.Complete();
                }

            }
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del<T>(int id) where T : class
        {
            int res = 0;
            using (var db = new Model1())
            {
                T mod = db.Set<T>().Find(id);
                if (mod != null)
                {
                    db.Set<T>().Remove(mod);
                    res = db.SaveChanges();
                }
            }
            return res;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public int DelRange<T>(Expression<Func<T, bool>> where) where T : class
        {
            int res = 0;
            using (var db = new Model1())
            {
                IList<T> list = db.Set<T>().Where(where).ToList();
                if (list.Count > 0)
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        db.Set<T>().RemoveRange(list);
                        db.Configuration.ValidateOnSaveEnabled = false;
                        res = db.SaveChanges();
                        db.Configuration.ValidateOnSaveEnabled = true;

                        transaction.Complete();
                    }

                }

            }
            return res;
        }
    }
}
