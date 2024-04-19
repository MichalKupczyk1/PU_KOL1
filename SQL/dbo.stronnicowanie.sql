CREATE PROCEDURE [dbo].[PobierzHistorieZeStronnicowaniem]
    @strona int,
    @iloscNaStrone int
AS
BEGIN
    DECLARE @pominieteRekordy int;

    SET @pominieteRekordy = @strona * @iloscNaStrone;

    SELECT Id, Imie, Nazwisko, GrupaId, TypAkcji, Data
    FROM (
        SELECT ROW_NUMBER() OVER (ORDER BY Id) AS rn, *
        FROM Historia
    ) AS numbered
    WHERE rn > @pominieteRekordy AND rn <= @pominieteRekordy + @iloscNaStrone;

    RETURN 0;
END;
