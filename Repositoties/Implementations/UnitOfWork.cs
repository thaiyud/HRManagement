﻿//using HRManagement.Models;
//using HRManagement.Repositoties.Interfaces;

//namespace HRManagement.Repositoties.Implementations
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly HrmanagementContext _context;

//        public UnitOfWork(HrmanagementContext context)
//        {
//            _context = context;
//        }

//        public IRepository<T> GetRepository<T>() where T : class
//        {
//            return new Repository<T>(_context);
//        }

//        public async Task<int> SaveChangesAsync()
//        {
//            return await _context.SaveChangesAsync();
//        }

//        public void Dispose()
//        {
//            _context.Dispose();
//        }
//    }
//}
