using System.Data.SqlClient;
using Dapper;
using Model;

namespace Data;
public class FilmRepository : IFilmRepository
{
    private string ConnectionString;

    protected SqlConnection dbConnection() {
        return new SqlConnection(ConnectionString);
    }

    public FilmRepository(string connectionString) {
        ConnectionString = connectionString;
    }

    async Task<bool> IFilmRepository.DeleteFilm(int id)
    {
        var db = dbConnection();
        var sql = @"
        DELETE  dbo.Films
                WHERE Id = @id
        ";

        var result = await db.ExecuteAsync(
                                    sql.ToString(),
                                    new {Id = id});
        return result > 0;
    }

    async Task<IEnumerable<Film>> IFilmRepository.GetAllFilms()
    {
        var db = dbConnection();
        var sql = @"
        SELECT  Id, Title, Director, ReleaseDate
                FROM dbo.Films
        ";
        return await db.QueryAsync<Film>(sql.ToString(), new {});
    }

    async Task<Film> IFilmRepository.GetFilmDetails(int id)
    {
        var db = dbConnection();
        var sql = @"
        SELECT  Id, Title, Director, ReleaseDate
                FROM dbo.Films
                WHERE Id = @id
        ";
        return await db.QueryFirstOrDefaultAsync<Film>(
                                                    sql.ToString(),
                                                    new {Id = id}
                                                    );

    }

    async Task<bool> IFilmRepository.InsertFilm(Film film)
    {
        var db = dbConnection();
        var sql = @"
        INSERT INTO Films (Title, Director, ReleaseDate)
        VALUES (@Title, @Director, @ReleaseDate)
        ";
        var result = await db.ExecuteAsync(
                                    sql.ToString(),
                                    new {film.Title,
                                        film.Director,
                                        film.ReleaseDate}
                            );

        return result > 0;
    }

    async Task<bool> IFilmRepository.UpdateFilm(Film film)
    {
        var db = dbConnection();
        var sql = @"
        UPDATE Films
            SET Title       = @Title,
                Director    = @Director,
                ReleaseDate = @ReleaseDate
            WHERE Id = @Id
        ";
        var result = await db.ExecuteAsync(
                                    sql.ToString(),
                                    new {
                                        film.Id,
                                        film.Title,
                                        film.Director,
                                        film.ReleaseDate}
                            );

        return result > 0;
    }
}
