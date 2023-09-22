using Model;

namespace Data;
public interface IFilmRepository
{

    public Task<IEnumerable<Film>> GetAllFilms();
    public Task<Film> GetFilmDetails(int id);
    public Task<bool> InsertFilm(Film film);
    public Task<bool> UpdateFilm(Film film);
    public Task<bool> DeleteFilm(int id);

}
