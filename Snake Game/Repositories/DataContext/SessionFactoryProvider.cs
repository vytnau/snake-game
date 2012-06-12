using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.Repositories.Mappings;

using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Data.SqlServerCe;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;


namespace Repositories.DataContext
{
    public class SessionFactoryProvider
    {
        private readonly static object lockObject = new object();
        private volatile static ISessionFactory sessionFactory;
        public static string ConnectionString = "Data Source=E:\\Failai\\4 semestras\\Programingo praktika\\Snake game\\ver 2\\Snake Game\\DomainModel\\DataBase\\HighScores.sdf";



      
     

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
            MsSqlCeConfiguration sqlconfig = MsSqlCeConfiguration.Standard.ConnectionString(ConnectionString);
            FluentConfiguration fc = Fluently.Configure();
            fc = fc.Database(sqlconfig);
            ISessionFactory sessionFactory = fc.Cache(c => c
               .UseQueryCache()
               .ProviderClass<HashtableCacheProvider>())
               .Mappings(m => m
               .FluentMappings.AddFromAssemblyOf<PlayerMap>())
               .ExposeConfiguration((NHibernate.Cfg.Configuration config) => new SchemaUpdate(config)
               .Execute(false, true))
               .BuildSessionFactory();
            return sessionFactory;
        }

    }


}