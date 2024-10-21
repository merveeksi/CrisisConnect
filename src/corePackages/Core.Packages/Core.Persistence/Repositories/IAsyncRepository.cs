using System.Linq.Expressions;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TEntityId> : IQuery<TEntity>
where TEntity : Entity<TEntityId>
{
    Task<TEntity>? GetAsync(
       Expression<Func<TEntity, bool>> predicate,
       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, Object>>? include=null,
       bool withDeleted = false,     //silinenleri getireyim mi?
       bool enableTracking = true,  //değişiklikleri takip edeyim mi?
       CancellationToken cancellationToken = default);
    
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,      //filtreleme, bana sadece şu şu şartları sağlayanları getir gibi
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,     //sıralama, bana sadece şu şu şartları sağlayanları getir gibi
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,    //ilişkili tabloları getirme, bana sadece şu şu şartları sağlayanları getir gibi
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<Paginate<TEntity>> GetListByDynamicAsync(  //dinamik sorgu
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<TEntity> AddAsync(TEntity entity);

    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities); //çoklu ekleme

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);

    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false); //permanent, kalıcı silme

    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false);
}