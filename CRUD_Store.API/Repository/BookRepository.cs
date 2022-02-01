﻿using CRUD_Store.API.Data;
using CRUD_Store.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Store.API.Repository
{
    public class BookRepository :IBookRepository
    {
        private readonly BookStroreContext _context;

        public BookRepository(BookStroreContext context) {
            _context = context;
        }

        public async Task<List<BookModel>> GetAllBooksAsync() {

            var records =await  _context.Books.Select(x=> new BookModel() { 
                
                Id =x.Id,
                Title =x.Title,
                Descrption =x.Descrption
                
            }).ToListAsync();

            return  records;
        
        }

        //single book instead of List we are using single 
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {

            var records = await _context.Books.Where(x =>x.Id ==bookId).Select(x => new BookModel()
            {

                Id = x.Id,
                Title = x.Title,
                Descrption = x.Descrption

            }).FirstOrDefaultAsync();

            return records;

        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {

            var book = new Books()
            {
                Title =bookModel.Title,
                Descrption =bookModel.Descrption,

            };

            _context.Books.Add(book);
           await _context.SaveChangesAsync();

            return book.Id;
        }


        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(bookId);

            //if (book != null) {
            //  book.Title = bookModel.Title;
            //book.Descrption = bookModel.Descrption;
            //  await _context.SaveChangesAsync();
            // }

            var book = new Books()
            {
                Id = bookId,
                Title = bookModel.Title,
                Descrption = bookModel.Descrption,

            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();


        }


        public async Task updateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {

            var book = await _context.Books.FindAsync(bookId);
            if (book != null) {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {

            var book = new Books() { 
                Id =bookId
                
            };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }

    }


}
