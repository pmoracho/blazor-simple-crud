CREATE TABLE Films (
    Id INT IDENTITY PRIMARY KEY,
    Title VARCHAR(255),
    Director VARCHAR(255),
    ReleaseDate DATETIME
)

INSERT INTO Films (Title, Director, ReleaseDate)
VALUES
    ('Pulp Fiction', 'Quentin Tarantino', '1994-10-14'),
    ('Forrest Gump', 'Robert Zemeckis', '1994-07-06'),
    ('El Resplandor', 'Stanley Kubrick', '1980-06-13'),
    ('El Señor de los Anillos: La Comunidad del Anillo', 'Peter Jackson', '2001-12-19'),
    ('El Señor de los Anillos: Las Dos Torres', 'Peter Jackson', '2002-12-18'),
    ('El Señor de los Anillos: El Retorno del Rey', 'Peter Jackson', '2003-12-17'),
    ('Matrix', 'Lana Wachowski, Lilly Wachowski', '1999-03-24'),
    ('El Silencio de los Corderos', 'Jonathan Demme', '1991-02-01'),
    ('Titanic', 'James Cameron', '1997-12-19'),
    ('E.T. el Extraterrestre', 'Steven Spielberg', '1982-06-11'),
    ('Blade Runner', 'Ridley Scott', '1982-06-25'),
    ('Star Wars: Episodio IV - Una Nueva Esperanza', 'George Lucas', '1977-05-25'),
    ('Star Wars: Episodio V - El Imperio Contraataca', 'Irvin Kershner', '1980-05-21'),
    ('Star Wars: Episodio VI - El Retorno del Jedi', 'Richard Marquand', '1983-05-25'),
    ('Jurassic Park', 'Steven Spielberg', '1993-06-11')


SELECT Title, Director, ReleaseDate
        FROM dbo.Films