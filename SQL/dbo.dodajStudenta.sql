CREATE PROCEDURE [dbo].[DodajStudenta]
    @imie nvarchar(100),
    @nazwisko nvarchar(100),
    @idGrupy int,
    @nowyStudentId int OUTPUT
AS
BEGIN
    INSERT INTO studenci (Imie, Nazwisko, GrupaId)
    VALUES (@imie, @nazwisko, @idGrupy);

    SET @nowyStudentId = SCOPE_IDENTITY();

    RETURN;
END;
