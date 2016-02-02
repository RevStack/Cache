using System;
using System.Collections.Generic;
using System.Web;
using RevStack.Pattern;
using RevStack.Mvc;


namespace RevStack.Cache
{
    public class CookieRepository<TEntity, TKey> : CacheRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private const double DEFAULT_EXPIRATION = 10000;
        protected new double _hours = DEFAULT_EXPIRATION;
        protected HttpContextBase _context;
        public CookieRepository() : base()
        {
            _context = new HttpContextWrapper(HttpContext.Current);
        }
        public override double Hours
        {
            get
            {
                return _hours;
            }

            set
            {
                _hours = value;
            }
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override TEntity Get(string key)
        {
            try
            {
                var cookie = _context.Request.Cookies[key].Value;
                return Json.DeserializeObject<TEntity>(cookie);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public override IEnumerable<TEntity> Get(string key, bool isEnumerable)
        {
            try
            {
                var cookie = _context.Request.Cookies[key].Value;
                return Json.DeserializeObject<IEnumerable<TEntity>>(cookie);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override void Remove(string key)
        {
            if (_context.Request.Cookies[key] != null) _context.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
        }

        public override void Set(string key, TEntity entity)
        {
            string value = Json.SerializeObject<TEntity>(entity);
            HttpCookie cookie = new HttpCookie(key,value);
            cookie.Expires = DateTime.Now.AddHours(_hours);
            _context.Response.Cookies.Add(cookie);
        }

        public override void Set(string key, IEnumerable<TEntity> entity, bool isEnumerable)
        {
            string value = Json.SerializeObject<IEnumerable<TEntity>>(entity);
            HttpCookie cookie = new HttpCookie(key, value);
            cookie.Expires = DateTime.Now.AddHours(_hours);
            _context.Response.Cookies.Add(cookie);
        }
    }
}

