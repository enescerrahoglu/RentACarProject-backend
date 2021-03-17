using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
//Core katmanı diğer katmanları referans almaz.
namespace Core.DataAccess
{
    /* T Değerine verilecek referans tipine filtreleme yapıyoruz
     class tipinde referans alabilir-IEntitiy türünde birşey yazabiliriz ve IEntity'nin kendisini de yazabilirz.
     new() koyma sebebimiz new'lenebilir nesne gelsin demek
     bu sayede IEntity yazmanın önüne geçeriz.
    */
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        // bu kod ile çeşitli fitrelemeyeyi yapabiliriz çağırdığımız yerde
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
