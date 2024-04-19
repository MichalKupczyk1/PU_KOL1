CREATE TRIGGER Trigger_UsuwanieStudenta
ON Studenci
AFTER DELETE
AS
BEGIN
    DECLARE @Imie varchar(100);
    DECLARE @Nazwisko varchar(100);
    DECLARE @GrupaId int;
    DECLARE @TypAkcji int;
    DECLARE @Data datetime;

    SELECT @Imie = Imie, @Nazwisko = Nazwisko, @GrupaId = GrupaId FROM deleted;

    SET @TypAkcji = 1;

    SET @Data = GETDATE();

    INSERT INTO Historia (Imie, Nazwisko, GrupaId, TypAkcji, Data)
    VALUES (@Imie, @Nazwisko, @GrupaId, @TypAkcji, @Data);
END;
