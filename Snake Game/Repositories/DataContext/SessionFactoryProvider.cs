using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using Snake_Game.Repositories.Mappings;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate.Cfg;
using NHibernate.Dialect;
using System.Data.SqlClient;

namespace Repositories.DataContext
{
    public class SessionFactoryProvider
    {
        private readonly static object lockObject = new object();
        private volatile static ISessionFactory sessionFactory;

        public static ISessionFactory SessionFactory
        {

            get
            {
                if (sessionFactory == null)
                {                    
                    lock (lockObject)
                    {
                        if (sessionFactory == null)
                        {
                          /*  var cfg = new Configuration();
                            cfg.SessionFactory()
                               .Proxy.Through<ByteCode.LinFu.ProxyFactoryFactory>()
                               .Integrate
                                   .Using<MsSql2005Dialect>()
                                   .Connected
                                       .Using(new SqlConnectionStringBuilder
                                       {
                                           DataSource = "(local)",
                                           InitialCatalog = "nhibernate",
                                           IntegratedSecurity = true
                                       });*/
                            var configuration = MsSqlConfiguration.MsSql2008.
                                ConnectionString("Data Source=E:\\Failai\\4 semestras\\Programingo praktika\\Snake game\\ver 2\\Snake Game\\DomainModel\\DataBase\\HighScores.sdf")
                                .ShowSql().ConfigureProperties(new Configuration());
                            sessionFactory = CreateSessionFactory();
                        }
                    }
                }

                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PlayerMap>())
                 .BuildConfiguration()
                 .BuildSessionFactory();
        }
    }
}