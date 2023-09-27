using Model;

namespace UI.Interfaces {

    public interface IFilmService {

        Task<IEnumerable<Film>> GetAllFilms();
        Task<Film> GetFilmDetails(int id);
        Task<bool> SaveFilm(Film film);
        Task<bool> DeleteFilm(int id);

    }
};
