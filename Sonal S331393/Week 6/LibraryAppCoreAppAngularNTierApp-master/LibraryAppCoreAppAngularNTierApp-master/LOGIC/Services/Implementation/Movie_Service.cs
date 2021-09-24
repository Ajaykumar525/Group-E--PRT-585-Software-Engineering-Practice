using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Movie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Movie movie Data
    /// </summary>
    public class Movie_Service : IMovie_Service
    {
        //Reference to our crud functions
        private IMovie_Operations _movie_operations = new Movie_Operations();

        /// <summary>
        /// Obtains all the Movie moviees that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Movie_ResultSet>>> GetAllMovies()
        {
            Generic_ResultSet<List<Movie_ResultSet>> result = new Generic_ResultSet<List<Movie_ResultSet>>();
            try
            {
                //GET ALL Movie movieES
                List<Movie> Moviees = await _movie_operations.ReadAll();
                //MAP DB Movie RESULTS
                result.result_set = new List<Movie_ResultSet>();
                Moviees.ForEach(s =>
                {
                    result.result_set.Add(new Movie_ResultSet
                    {
                        movie_id = s.MovieID,
                        name = s.Movie_Name,
                        Director = s.Director,
                        Language = s.Language,
                        Price = s.Price
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Movie moviees obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: GetAllMovies() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Movie moviees from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: GetAllMovies(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Movie_ResultSet>> GetMovieById(long id)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {
                //GET by ID Movie 
                var Movie = await _movie_operations.Read(id);

                //MAP DB Movie RESULTS
                result.result_set = new Movie_ResultSet
                {
                    name = Movie.Movie_Name,
                    movie_id = Movie.MovieID,
                    Director = Movie.Director,
                    Language = Movie.Language,
                    Price = Movie.Price
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Movie  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Movie  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new movie to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Movie_ResultSet>> AddMovie(string name, string Director, string Language, string Price)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Movie
                Movie Movie = new Movie
                {
                    Movie_Name = name,
                    Director = Director,
                    Language = Language,
                    Price = Price
                };

                //ADD Movie TO DB
                Movie = await _movie_operations.Create(Movie);

                //MANUAL MAPPING OF RETURNED Movie VALUES TO OUR Movie_ResultSet
                Movie_ResultSet movieAdded = new Movie_ResultSet
                {
                    name = Movie.Movie_Name,
                    movie_id = Movie.MovieID,
                    Director = Movie.Director,
                    Language = Movie.Language,
                    Price = Movie.Price
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Movie movie {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: AddMovie() method executed successfully.";
                result.result_set = movieAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Movie movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: AddMovie(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Movie movies name.
        /// </summary>
        /// <param name="movie_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Movie_ResultSet>> UpdateMovie(Int64 movie_id, string name, string Director, string Language, string Price)
        {
            Generic_ResultSet<Movie_ResultSet> result = new Generic_ResultSet<Movie_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Movie
                Movie Movie = new Movie
                {
                    MovieID = movie_id,
                    Movie_Name = name,
                    Director = Director,
                    Language = Language,
                    Price = Price
                    //Movie_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Movie IN DB
                Movie = await _movie_operations.Update(Movie, movie_id);

                //MANUAL MAPPING OF RETURNED Student VALUES TO OUR Movie_ResultSet
                Movie_ResultSet movieUpdated = new Movie_ResultSet
                {
                    name = Movie.Movie_Name,
                    movie_id = Movie.MovieID,
                    Director = Movie.Director,
                    Language = Movie.Language,
                    Price = Movie.Price
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Movie movie {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: UpdateMovie() method executed successfully.";
                result.result_set = movieUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Movie movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: UpdateMovie(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteMovie(long movie_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Movie IN DB
                var movieDeleted = await _movie_operations.Delete(movie_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Movie movie {0} was deleted successfully", movie_id);
                result.internalMessage = "LOGIC.Services.Implementation.Movie_Service: DeleteMovie() method executed successfully.";
                result.result_set = movieDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Movie movie supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Movie_Service: DeleteMovie(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
