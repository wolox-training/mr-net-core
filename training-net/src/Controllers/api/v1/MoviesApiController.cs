using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
[Route("api/v1/[controller]")]
public class MoviesAPIController : Controller  
   {  
       // GET: api/GetAllMovies
       [HttpGet]  
       public IEnumerable<Movie> GetAllMovies()  
       {  
           List<Movie> movies = new List<Movie>  
           {  
           new Movie{  
                        ID = 1,
                        Title = "Esa",  
                        ReleaseDate = DateTime.Today,
                        Genre = "mala",  
                        Price = 10
                              },  
           new Movie{  
                        ID = 2,
                        Title = "Esa2",  
                        ReleaseDate = DateTime.Today,
                        Genre = "mala",  
                        Price = 10
                             },                
           };  
           return movies;  
       }  
   }  
   