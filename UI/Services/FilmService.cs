using Model;
using UI.Interfaces;
using Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace UI.Services {


    public class FilmService : IFilmService
    {
        private IFilmRepository _filmRepository;
        private readonly SqlConfiguration _configuration;

        public FilmService(SqlConfiguration configuration) {
            _configuration = configuration;
            _filmRepository = new FilmRepository(configuration.ConnectionString);
        }

        Task<bool> IFilmService.DeleteFilm(int id)
        {
            return _filmRepository.DeleteFilm(id);
        }

        Task<IEnumerable<Film>> IFilmService.GetAllFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        Task<Film> IFilmService.GetFilmDetails(int id) {
            return _filmRepository.GetFilmDetails(id);
        }

        Task<bool> IFilmService.SaveFilm(Film film)
        {
            if (film.Id == 0) {
                return _filmRepository.InsertFilm(film);
            } else {
                return _filmRepository.UpdateFilm(film);
            }
        }
    }
};
