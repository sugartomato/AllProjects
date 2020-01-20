using System;
using System.Collections;
using System.Collections.Generic;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DHDWeb.DataAdapter
{
    public static class MongoDBHelper<T> where T:Models.ModelBase
    {

        private static MongoClient _propDBClient = null;
        private static MongoClient DBClient
        { 
            get
            { 
                if(_propDBClient == null)
                {
                    _propDBClient = new MongoClient("mongodb://localhost/DHD");
                }
                return _propDBClient;
            }
        }

        private static IMongoDatabase _propDB = null;
        private static IMongoDatabase DB
        {
            get
            {
                if (_propDB == null) _propDB = DBClient.GetDatabase("DHD");
                return _propDB;
            }
        }

        private static IMongoCollection<T> _propCol = null;
        private static IMongoCollection<T> Col
        {
            get
            {
                return DB.GetCollection<T>(GetCollectionName());
            }
        }


        private static String GetCollectionName()
        {
            var type = typeof(T);
            return type.Name;
        }

        #region 插入

        public static Boolean Insert(List<T> models)
        {
             Col.InsertMany(models);
            return true;
        }

        public static Boolean Insert(T model)
        {
            Col.InsertOne(model);
            return true;
        }



        #endregion


        #region 更新

        public static Boolean Update(UpdateDefinition<T> update, FilterDefinition<T> filter)
        {
            //Col.FindOneAndUpdate();
            UpdateResult result = Col.UpdateMany(filter, update);
            return result.ModifiedCount > 0 ? true : false;
        }


        #endregion


        #region 查询

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>The all.</returns>
        public static List<T> GetAll()
        {
            return GetAll(FilterDefinition<T>.Empty, null);

        }


        /// <summary>
        /// 获取指定条件下的所有数据
        /// </summary>
        /// <returns>The all.</returns>
        /// <param name="filter">Filter.</param>
        public static List<T> GetAll(FilterDefinition<T> filter)
        {
            return GetAll(filter, null);

        }

        public static List<T> GetAll(FilterDefinition<T> filter, FindOptions options)
        {

            return Col.Find(filter, options).ToList();
        }

        /// <summary>
        /// 根据id获取对应数据
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public static T GetByID(String id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.ID, id);
            return GetFirst(filter, null);
        }

        /// <summary>
        /// 获取符合条件的第一条数据
        /// </summary>
        /// <returns>The first.</returns>
        /// <param name="filter">Filter.</param>
        public static T GetFirst(FilterDefinition<T> filter, FindOptions options)
        {
            
            return  Col.Find(filter,options).First();
        }

        #endregion


        #region 删除

        public static Boolean Clear()
        {
            Int64 currentCount = Col.CountDocuments(FilterDefinition<T>.Empty);
            DeleteResult result = Col.DeleteMany(FilterDefinition<T>.Empty);
            if(result.DeletedCount > 0)
            { return true; }
            return false;
        }


        #endregion

    }
}
